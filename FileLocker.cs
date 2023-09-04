using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FileLocker : Form
    {
        static string EncryptionKey = ""; // Initialize to an empty string
        static string Salt = ""; // Initialize to an empty string

        public FileLocker()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void FileLocker_Load(object sender, EventArgs e)
        {
            // Get the list of all available drives
            string[] drives = Directory.GetLogicalDrives();

            // Add each drive to the ComboBox
            foreach (string drive in drives)
            {
                comboBoxDrives.Items.Add(drive);
            }

            // Optional: Select the first drive by default
            if (comboBoxDrives.Items.Count > 0)
            {
                comboBoxDrives.SelectedIndex = 0;
            }
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }

        private void LoadItemsIntoTreeView(TreeNode parentNode)
        {
            if (parentNode.Tag is string folderPath)
            {
                try
                {
                    // Get all items (both folders and files) in the current folder
                    string[] items = Directory.GetFileSystemEntries(folderPath);

                    foreach (string item in items)
                    {
                        if (Directory.Exists(item))
                        {
                            // It's a folder, create a TreeNode for the folder
                            DirectoryInfo subfolderInfo = new DirectoryInfo(item);
                            TreeNode subfolderNode = new TreeNode(subfolderInfo.Name);
                            subfolderNode.Tag = item; // Store the full path of the folder

                            // Use Invoke to add the folder TreeNode to the parent TreeNode on the UI thread
                            treeView1.Invoke((MethodInvoker)delegate
                            {
                                parentNode.Nodes.Add(subfolderNode);
                            });

                            // Recursively load subfolders and files
                            LoadItemsIntoTreeView(subfolderNode);
                        }
                        else
                        {
                            // It's a file, create a TreeNode for the file
                            TreeNode fileNode = new TreeNode(Path.GetFileName(item));
                            fileNode.Tag = item; // Store the full path of the file

                            // Use Invoke to add the file TreeNode to the parent TreeNode on the UI thread
                            treeView1.Invoke((MethodInvoker)delegate
                            {
                                parentNode.Nodes.Add(fileNode);
                            });
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // Handle access denied
                }
            }
        }

        private void LoadRootFolder(string folderPath)
        {
            treeView1.Nodes.Clear(); // Clear existing nodes

            try
            {
                // Create a TreeNode for the specified folder
                TreeNode rootNode = new TreeNode(folderPath);
                rootNode.Tag = folderPath; // Store the full path of the folder

                // Use Invoke to add the folder TreeNode to the TreeView on the UI thread
                treeView1.Invoke((MethodInvoker)delegate
                {
                    treeView1.Nodes.Add(rootNode);
                });

                // Load all items (folders and files) recursively
                LoadItemsIntoTreeView(rootNode);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, such as access denied or other errors
                MessageBox.Show("Error loading folder: " + ex.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string folderPath = textBox1.Text;

            if (Directory.Exists(folderPath))
            {
                backgroundWorker1.RunWorkerAsync(folderPath);
            }
            else
            {
                MessageBox.Show("The specified directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string folderPath = e.Argument as string;
            LoadRootFolder(folderPath);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the selected node's tag, which contains the path
            object selectedPath = e.Node.Tag;

            if (selectedPath != null)
            {
                // Update textBox4.Text with the selected path
                textBox4.Text = selectedPath.ToString();
            }
        }

        // Encrypt a file using AES
        private void EncryptFile(string inputFile, string outputFile)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(Salt);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                using (CryptoStream csEncrypt = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                {
                    fsInput.CopyTo(csEncrypt);
                }
            }
        }

        // Decrypt a file using AES
        private void DecryptFile(string inputFile, string outputFile)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(Salt);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                using (CryptoStream csDecrypt = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
                {
                    csDecrypt.CopyTo(fsOutput);
                }
            }
        }

        private void LockFile(string filePath)
        {
            string encryptedFilePath = filePath + ".encrypted";

            try
            {
                EncryptFile(filePath, encryptedFilePath);
                File.Delete(filePath);

                MessageBox.Show($"File locked: {filePath}", "File Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UnlockFile(string encryptedFilePath, string originalFilePath)
        {
            try
            {
                DecryptFile(encryptedFilePath, originalFilePath);
                File.Delete(encryptedFilePath);

                MessageBox.Show($"File unlocked: {originalFilePath}", "File Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Encrypt a folder and its contents
        private void LockFolder(string folderPath)
        {
            try
            {
                // Generate AES key and IV from the provided key and salt
                byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);
                byte[] saltBytes = Encoding.UTF8.GetBytes(Salt);

                using (Aes aesAlg = Aes.Create())
                using (Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(keyBytes, saltBytes, 10000))
                {
                    aesAlg.Key = keyDerivation.GetBytes(32); // 256 bits key
                    aesAlg.IV = keyDerivation.GetBytes(16); // 128 bits IV

                    // Create an encrypted folder path
                    string encryptedFolderPath = folderPath + ".encrypted";

                    // Encrypt the folder and its contents
                    CryptoHelper.EncryptDirectory(folderPath, encryptedFolderPath, aesAlg.Key, aesAlg.IV);

                    // Delete the original folder
                    Directory.Delete(folderPath, true);

                    MessageBox.Show($"Folder locked: {folderPath}", "Folder Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Decrypt a folder and its contents
        private void UnlockFolder(string encryptedFolderPath, string originalFolderPath)
        {
            try
            {
                // Generate AES key and IV from the provided key and salt
                byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);
                byte[] saltBytes = Encoding.UTF8.GetBytes(Salt);

                using (Aes aesAlg = Aes.Create())
                using (Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(keyBytes, saltBytes, 10000))
                {
                    aesAlg.Key = keyDerivation.GetBytes(32); // 256 bits key
                    aesAlg.IV = keyDerivation.GetBytes(16); // 128 bits IV

                    // Create the decrypted folder path
                    string decryptedFolderPath = originalFolderPath;

                    // Decrypt the folder and its contents
                    CryptoHelper.DecryptDirectory(encryptedFolderPath, decryptedFolderPath, aesAlg.Key, aesAlg.IV);

                    // Delete the encrypted folder
                    Directory.Delete(encryptedFolderPath, true);

                    MessageBox.Show($"Folder unlocked: {originalFolderPath}", "Folder Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string folderToLock = textBox4.Text;

            if (Directory.Exists(folderToLock))
            {
                LockFolder(folderToLock);
            }
            else
            {
                MessageBox.Show("The specified directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string folderToUnlock = textBox4.Text;

            if (Directory.Exists(folderToUnlock))
            {
                //UnlockFolder(folderToUnlock);
            }
            else
            {
                MessageBox.Show("The specified directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button6_Click(object sender, EventArgs e)
        {
            string fileToLock = textBox4.Text;

            if (File.Exists(fileToLock))
            {
                LockFile(fileToLock);
            }
            else
            {
                MessageBox.Show("The specified file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fileToUnlock = textBox4.Text;

            if (File.Exists(fileToUnlock))
            {
                // UnlockFile(fileToUnlock);
            }
            else
            {
                MessageBox.Show("The specified file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GenerateKeys()
        {
            // Generate a random AES key (256 bits)
            byte[] aesKey = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(aesKey);
            }

            // Generate a random salt (128 bits)
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Display the AES key and salt in their respective textboxes
            txtKey.Text = BitConverter.ToString(aesKey).Replace("-", "");
            txtSalt.Text = BitConverter.ToString(salt).Replace("-", "");
        }

        private void SetEncryptionKeyAndSalt()
        {
            // Set the EncryptionKey and Salt fields from the textboxes
            EncryptionKey = txtKey.Text;
            Salt = txtSalt.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GenerateKeys();
            SetEncryptionKeyAndSalt();
        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBoxDrives.SelectedItem.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.label8.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string folderName = textBox2.Text;
            string targetPath = textBox4.Text.ToString();
            if (!string.IsNullOrWhiteSpace(folderName))
            {
                try
                {
                    string folderPath = Path.Combine(targetPath, folderName);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                        MessageBox.Show($"Folder '{folderName}' created successfully.", "Successfully Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Folder '{folderName}' already exists.", "Failed To Create Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please enter a folder name.");
            }
        }
    }
}