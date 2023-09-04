#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion
#region namespace WindowsFormsApp1 
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region Form1
        public Form1()
        {
            InitializeComponent();
        }
        #endregion
        #region Nothing Happens
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }
        #endregion
        #region Application Loaders
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowInTaskbar = true;
                PassLocker pL = new PassLocker();
                pL.ShowInTaskbar = true;
                pL.ShowDialog();
                pL.StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowInTaskbar = true;
                FileLocker fL = new FileLocker();
                fL.ShowInTaskbar = true;
                fL.ShowDialog();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowInTaskbar = true;
                EncryptedTextLocker etL = new EncryptedTextLocker();
                etL.ShowInTaskbar = true;
                etL.ShowDialog();
            }
            catch (Exception z)
            {
                MessageBox.Show(z.ToString());
                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowInTaskbar = true;
                PersoanlLocker pcL = new PersoanlLocker();
                pcL.ShowInTaskbar = true;
                pcL.ShowDialog();
            }
            catch (Exception y)
            {
                MessageBox.Show(y.ToString());
                throw;
            }
        }
        #endregion
    }
}
#endregion