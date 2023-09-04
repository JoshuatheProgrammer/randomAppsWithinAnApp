using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class PassLocker : Form
    {
        public PassLocker()
        {
            InitializeComponent();
        }

        private void PassLocker_Load(object sender, EventArgs e)
        {
            CheckPassList.Start();
            CheckPassList.Interval = 555;

            string folderPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\.data" ;
            string dataFolderPath = Path.Combine(folderPath); // Path to the "Data" folder
            string filePath = Path.Combine(folderPath, "be146b37a00983092b5487f2371e8bd6ddb89e875c8b16e1316c732921455ebb.txt");
            //string filePath2 = Path.Combine(folderPath, "ReadMe.txt");

            if (!Directory.Exists(dataFolderPath))
            {
                Directory.CreateDirectory(dataFolderPath);
            }
            // Check if the file already exists, and create it if it doesn't
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "| Application[s] : app |  Username[s] : username |<-->|  Password[s] : password |");
            }
            else
            {
                // Check if the folder already exists, and create it if it doesn't {.data folder}
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
        }
        private List<string> LoadUsernamesAndPasswords(string filePath)
        {
            List<string> usernamePasswordList = new List<string>();

            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    // Split each line into username and password
                    string[] parts = line.Split(new[] { "|<-->|" }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length == 2)
                    {
                        string username = parts[0];
                        string password = parts[1];

                        // Add the combination to the list
                        usernamePasswordList.Add(username + "|<-->|" + password);
                    }
                    else
                    {
                        // Handle invalid lines if needed
                        Console.WriteLine($"Skipping invalid line: {line}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle file reading errors if needed
                MessageBox.Show("An error occurred while reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return usernamePasswordList;
        }

        private void CheckPassList_Tick(object sender, EventArgs e)
        {
            string folderPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\.data"; // Replace with your actual computer username
            string filePath = Path.Combine(folderPath, "be146b37a00983092b5487f2371e8bd6ddb89e875c8b16e1316c732921455ebb.txt");
            try
            {
                List<string> usernamePasswordList = LoadUsernamesAndPasswords(filePath);

                // Clear the ListBox
                listBox1.Items.Clear();

                // Add the loaded usernames and passwords to the ListBox
                foreach (string combination in usernamePasswordList)
                {
                    listBox1.Items.Add(combination);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string application = textBox3.Text;

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(application))
            {
                // Combine username and password with the "::" separator
                string entry = $"\n| {application} | Username : {username} |<-->| Password : {password} |";

                // Replace with your actual file path
                string folderPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\.data"; // Replace with your actual computer username
                string filePath = Path.Combine(folderPath, "be146b37a00983092b5487f2371e8bd6ddb89e875c8b16e1316c732921455ebb.txt");

                try
                {
                    // Append the entry to the file
                    File.AppendAllText(filePath, entry + Environment.NewLine);

                    // Clear textboxes
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                }
                catch (Exception ex)
                {
                    // Handle file writing errors if needed
                    MessageBox.Show("An error occurred while writing to the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Check If You Have An Application/Username or Email/Password Filled Out!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Cluster Fawk 
            if (comboBox1.Text == "Google")
            {
                label1.Text = "Email";
                textBox3.Text = "Google";
                button1.Text = "Add Email + Password";
            }
            if (comboBox1.Text == "Other Mail")
            {
                label1.Text = "Email";
                textBox3.Text = "Other Mail";
                button1.Text = "Add Email + Password";
            }
            if (comboBox1.Text == "YouTube")
            {
                label1.Text = "Email";
                textBox3.Text = "YouTube";
                button1.Text = "Add Email + Password";
            }
            if (comboBox1.Text == "Twitter")
            {
                label1.Text = "Email";
                textBox3.Text = "Twitter";
                button1.Text = "Add Email + Password";
            }
            if (comboBox1.Text == "Facebook")
            {
                label1.Text = "Email";
                textBox3.Text = "Facebook";
                button1.Text = "Add Email + Password";
            }
            if (comboBox1.Text == "Steam")
            {
                label1.Text = "Username";
                textBox3.Text = "Steam";
                button1.Text = "Add Username + Password";
            }
            if (comboBox1.Text == "Epic Games")
            {
                label1.Text = "Username";
                textBox3.Text = "Epic Games";
                button1.Text = "Add Username + Password";
            }
            if (comboBox1.Text == "Orgin")
            {
                label1.Text = "Username";
                textBox3.Text = "Orgin";
                button1.Text = "Add Username + Password";
            }
            if (comboBox1.Text == "Riot Client")
            {
                label1.Text = "Username";
                textBox3.Text = "Riot Client";
                button1.Text = "Add Username + Password";
            }
            if (comboBox1.Text == "Apple ID")
            {
                label1.Text = "Email";
                textBox3.Text = "Apple ID";
                button1.Text = "Add Email + Password";
            }
            if (comboBox1.Text == "Amazon")
            {
                label1.Text = "Email";
                textBox3.Text = "Amazon";
                button1.Text = "Add Email + Password";
            }
            if (comboBox1.Text == "Best Buy")
            {
                label1.Text = "Email";
                textBox3.Text = "Best Buy";
                button1.Text = "Add Email + Password";
            }
            if (comboBox1.Text == "Misc.")
            {
                label1.Text = "Email / Username / ETC";
                textBox3.Text = "Misc.";
                button1.Text = "Add Email/User + Password";
            }if (comboBox1.Text == "Clear")
            {
                label1.Text = "Username";
                textBox3.Clear();
                button1.Text = "Add Username + Password";
                comboBox1.Text = "";
            }
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /// Clears Data in password file
            string folderPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\.data"; // Replace with your actual computer username
            string filePath = Path.Combine(folderPath, "be146b37a00983092b5487f2371e8bd6ddb89e875c8b16e1316c732921455ebb.txt");
            string dataFolderPath = Path.Combine(folderPath, ".data"); // Path to the "Data" folder
            string filePath2 = Path.Combine(folderPath, "ReadMe.txt");

            File.WriteAllText(filePath, "");
            File.WriteAllText(filePath, "| Application[s] : app |  Username[s] : username |<-->|  Password[s] : password |");
            
        }
    }
}