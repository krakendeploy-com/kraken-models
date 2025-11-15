using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Kraken.Models;

public static class SecureTokenStore
{
    public static string GetRefreshBlobPath(string rootPath)
    {
        return Path.Combine(rootPath, "refresh.blob");
    }

    public static void SaveRefreshToken(string platform, string rootPath, string refreshToken)
    {
        Directory.CreateDirectory(rootPath);
        var blobPath = GetRefreshBlobPath(rootPath);

        byte[] cipher;

        if (platform == "win-x64")
        {
            var plain = Encoding.UTF8.GetBytes(refreshToken);
            cipher = ProtectedData.Protect(plain, null, DataProtectionScope.LocalMachine);
        }
        else
        {
            var (key, keyPath) = LoadOrCreateLinuxKey();
            cipher = EncryptAesGcm(key, Encoding.UTF8.GetBytes(refreshToken));
            TryChmod600(keyPath);
        }

        File.WriteAllBytes(blobPath, cipher);
        TryChmod600(blobPath);
    }

    public static string? LoadRefreshToken(string platform, string rootPath)
    {
        var blobPath = GetRefreshBlobPath(rootPath);
        if (!File.Exists(blobPath)) return null;

        var cipher = File.ReadAllBytes(blobPath);

        if (platform == "win-x64")
        {
            var plain = ProtectedData.Unprotect(cipher, null, DataProtectionScope.LocalMachine);
            return Encoding.UTF8.GetString(plain);
        }
        else
        {
            var (key, _) = LoadOrCreateLinuxKey();
            var plain = DecryptAesGcm(key, cipher);
            return Encoding.UTF8.GetString(plain);
        }
    }

    // ===== Linux AES-GCM helpers =====
    private static (byte[] key, string keyPath) LoadOrCreateLinuxKey()
    {
        var dir = "/var/lib/kraken/keys";
        Directory.CreateDirectory(dir);
        var keyPath = Path.Combine(dir, "refresh.key");

        if (File.Exists(keyPath))
            return (File.ReadAllBytes(keyPath), keyPath);

        var key = RandomNumberGenerator.GetBytes(32); // 256-bit
        File.WriteAllBytes(keyPath, key);
        return (key, keyPath);
    }

    private static byte[] EncryptAesGcm(byte[] key, byte[] plaintext)
    {
        var nonce = RandomNumberGenerator.GetBytes(12);
        var tag = new byte[16];
        var cipher = new byte[plaintext.Length];

        using var aes = new AesGcm(key);
        aes.Encrypt(nonce, plaintext, cipher, tag);

        var blob = new byte[12 + 16 + cipher.Length];
        Buffer.BlockCopy(nonce, 0, blob, 0, 12);
        Buffer.BlockCopy(tag, 0, blob, 12, 16);
        Buffer.BlockCopy(cipher, 0, blob, 28, cipher.Length);
        return blob;
    }

    private static byte[] DecryptAesGcm(byte[] key, byte[] blob)
    {
        var nonce = new byte[12];
        var tag = new byte[16];
        var cipher = new byte[blob.Length - 28];

        Buffer.BlockCopy(blob, 0, nonce, 0, 12);
        Buffer.BlockCopy(blob, 12, tag, 0, 16);
        Buffer.BlockCopy(blob, 28, cipher, 0, cipher.Length);

        var plain = new byte[cipher.Length];
        using var aes = new AesGcm(key);
        aes.Decrypt(nonce, cipher, tag, plain);
        return plain;
    }

    private static void TryChmod600(string path)
    {
        try
        {
            if (OperatingSystem.IsLinux())
                Process.Start(new ProcessStartInfo("/bin/chmod", $"600 \"{path}\"")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true
                })?.WaitForExit();
        }
        catch
        {
            /* best effort */
        }
    }
}