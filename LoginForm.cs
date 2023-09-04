using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Maximum Characters For Usernames : 15", textBox1);
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Maximum Characters For Passwords : 255", textBox2);
        }
    }
}
