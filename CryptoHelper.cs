using System;
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public class CryptoHelper
    {
        public static void EncryptDirectory(string sourceDirectory, string destinationDirectory, byte[] key, byte[] iv)
        {
            foreach (string file in Directory.GetFiles(sourceDirectory))
            {
                string encryptedFile = Path.Combine(destinationDirectory, Path.GetFileName(file) + ".encrypted");
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;
                    using (FileStream fsIn = new FileStream(file, FileMode.Open))
                    using (FileStream fsOut = new FileStream(encryptedFile, FileMode.Create))
                    using (CryptoStream cs = new CryptoStream(fsOut, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        fsIn.CopyTo(cs);
                    }
                }
            }

            foreach (string subdirectory in Directory.GetDirectories(sourceDirectory))
            {
                string newDestination = Path.Combine(destinationDirectory, Path.GetFileName(subdirectory));
                EncryptDirectory(subdirectory, newDestination, key, iv);
            }
        }

        public static void DecryptDirectory(string sourceDirectory, string destinationDirectory, byte[] key, byte[] iv)
        {
            foreach (string file in Directory.GetFiles(sourceDirectory))
            {
                string decryptedFile = Path.Combine(destinationDirectory, Path.GetFileNameWithoutExtension(file));
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;
                    using (FileStream fsIn = new FileStream(file, FileMode.Open))
                    using (FileStream fsOut = new FileStream(decryptedFile, FileMode.Create))
                    using (CryptoStream cs = new CryptoStream(fsIn, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        cs.CopyTo(fsOut);
                    }
                }
            }

            foreach (string subdirectory in Directory.GetDirectories(sourceDirectory))
            {
                string newDestination = Path.Combine(destinationDirectory, Path.GetFileName(subdirectory));
                DecryptDirectory(subdirectory, newDestination, key, iv);
            }
        }
    }
}