using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class EncryptedTextLocker : Form
    {
        public EncryptedTextLocker()
        {
            InitializeComponent();
        }

        private void encrypBtn_Click(object sender, EventArgs e)
        {
            string key = "0123456789abcdef0123456789abcdef"; // 32-byte key (256 bits)

            string inputText = textToEncrypt.Text;

            if (!string.IsNullOrEmpty(inputText))
            {
                string encryptedText = AESCrypto.Encrypt(inputText, key);
                encryptMessage.Text = encryptedText;
            }
            else
            {
                MessageBox.Show("Please enter some text to encrypt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public class AESCrypto
        {
            public static string Encrypt(string plainText, string key)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(key);

                    aesAlg.GenerateIV(); // Generate a new IV for each encryption

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] encryptedBytes;

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            csEncrypt.Write(inputBytes, 0, inputBytes.Length);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }

                    // Combine the IV and ciphertext
                    byte[] combinedBytes = new byte[aesAlg.IV.Length + encryptedBytes.Length];
                    Array.Copy(aesAlg.IV, 0, combinedBytes, 0, aesAlg.IV.Length);
                    Array.Copy(encryptedBytes, 0, combinedBytes, aesAlg.IV.Length, encryptedBytes.Length);

                    return Convert.ToBase64String(combinedBytes);
                }
            }
            public static string Decrypt(string cipherText, string key)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(key);

                    // Separate the IV and ciphertext from the combined string
                    byte[] combinedBytes = Convert.FromBase64String(cipherText);
                    byte[] iv = new byte[aesAlg.IV.Length];
                    byte[] encryptedBytes = new byte[combinedBytes.Length - aesAlg.IV.Length];
                    Array.Copy(combinedBytes, iv, iv.Length);
                    Array.Copy(combinedBytes, iv.Length, encryptedBytes, 0, encryptedBytes.Length);

                    aesAlg.IV = iv;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }

        }

            private void decryptBtn_Click(object sender, EventArgs e)
        {
            string key = "0123456789abcdef0123456789abcdef"; // 32-byte key (256 bits)

            string inputText = textToDecrypt.Text;

            if (!string.IsNullOrEmpty(inputText))
            {
                string decryptedText = AESCrypto.Decrypt(inputText, key);
                decryptMessage.Text = decryptedText;
            }
            else
            {
                MessageBox.Show("Please enter some text to decrypt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(encryptMessage.Text))
            {
                MessageBox.Show("No text to save. Please encrypt some text first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string contentToSave = decryptMessage.Text;

                File.WriteAllText(filePath, contentToSave);
                MessageBox.Show("Text saved successfully.", "Save Was Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textToEncrypt.Text) && string.IsNullOrEmpty(encryptMessage.Text))
            {
                MessageBox.Show("Error nothing found to clear", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                textToEncrypt.Clear();
                encryptMessage.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textToDecrypt.Text) && string.IsNullOrEmpty(decryptMessage.Text))
            {
                MessageBox.Show("Error nothing found to clear", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                textToDecrypt.Clear();
                decryptMessage.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Read the contents of the file and display it in the TextBox
                    string fileContents = File.ReadAllText(filePath);
                    textToEncrypt.Text = fileContents;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Read the contents of the file and display it in the TextBox
                    string fileContents = File.ReadAllText(filePath);
                    textToDecrypt.Text = fileContents;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EncryptedTextLocker_Load(object sender, EventArgs e)
        {

        }
    }
}
