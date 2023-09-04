namespace WindowsFormsApp1
{
    partial class EncryptedTextLocker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textToEncrypt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.encryptMessage = new System.Windows.Forms.TextBox();
            this.encrypBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.decryptMessage = new System.Windows.Forms.TextBox();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.textToDecrypt = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textToEncrypt
            // 
            this.textToEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.textToEncrypt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textToEncrypt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(209)))), ((int)(((byte)(175)))));
            this.textToEncrypt.Location = new System.Drawing.Point(6, 19);
            this.textToEncrypt.Multiline = true;
            this.textToEncrypt.Name = "textToEncrypt";
            this.textToEncrypt.Size = new System.Drawing.Size(544, 288);
            this.textToEncrypt.TabIndex = 0;
            this.textToEncrypt.Text = "Enter some text to encrypt here!";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.encryptMessage);
            this.groupBox1.Controls.Add(this.encrypBtn);
            this.groupBox1.Controls.Add(this.textToEncrypt);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 508);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "╼╼╼╼╼╼╼╼";
            // 
            // encryptMessage
            // 
            this.encryptMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.encryptMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.encryptMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(209)))), ((int)(((byte)(175)))));
            this.encryptMessage.Location = new System.Drawing.Point(6, 342);
            this.encryptMessage.Multiline = true;
            this.encryptMessage.Name = "encryptMessage";
            this.encryptMessage.Size = new System.Drawing.Size(544, 160);
            this.encryptMessage.TabIndex = 2;
            // 
            // encrypBtn
            // 
            this.encrypBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.encrypBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.encrypBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(249)))));
            this.encrypBtn.Location = new System.Drawing.Point(0, 313);
            this.encrypBtn.Name = "encrypBtn";
            this.encrypBtn.Size = new System.Drawing.Size(544, 23);
            this.encrypBtn.TabIndex = 1;
            this.encrypBtn.Text = "Encrypt Text";
            this.encrypBtn.UseVisualStyleBackColor = false;
            this.encrypBtn.Click += new System.EventHandler(this.encrypBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.decryptMessage);
            this.groupBox2.Controls.Add(this.decryptBtn);
            this.groupBox2.Controls.Add(this.textToDecrypt);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.groupBox2.Location = new System.Drawing.Point(574, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(556, 508);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "╼╼╼╼╼╼╼╼";
            // 
            // decryptMessage
            // 
            this.decryptMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.decryptMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.decryptMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(209)))), ((int)(((byte)(175)))));
            this.decryptMessage.Location = new System.Drawing.Point(6, 342);
            this.decryptMessage.Multiline = true;
            this.decryptMessage.Name = "decryptMessage";
            this.decryptMessage.Size = new System.Drawing.Size(544, 160);
            this.decryptMessage.TabIndex = 2;
            // 
            // decryptBtn
            // 
            this.decryptBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.decryptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decryptBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(249)))));
            this.decryptBtn.Location = new System.Drawing.Point(6, 313);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(544, 23);
            this.decryptBtn.TabIndex = 1;
            this.decryptBtn.Text = "Decrypt Text";
            this.decryptBtn.UseVisualStyleBackColor = false;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // textToDecrypt
            // 
            this.textToDecrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.textToDecrypt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textToDecrypt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(209)))), ((int)(((byte)(175)))));
            this.textToDecrypt.Location = new System.Drawing.Point(6, 19);
            this.textToDecrypt.Multiline = true;
            this.textToDecrypt.Name = "textToDecrypt";
            this.textToDecrypt.Size = new System.Drawing.Size(544, 288);
            this.textToDecrypt.TabIndex = 0;
            this.textToDecrypt.Text = "Enter an encrypted string here!";
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(249)))));
            this.saveBtn.Location = new System.Drawing.Point(1136, 301);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(224, 39);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save Encrypted Text To File";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(249)))));
            this.btnClear.Location = new System.Drawing.Point(1136, 436);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(224, 39);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Encrypted Text Field[s]";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(249)))));
            this.button1.Location = new System.Drawing.Point(1136, 481);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clear Decrypted Text Field[s]";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(249)))));
            this.button2.Location = new System.Drawing.Point(1136, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 39);
            this.button2.TabIndex = 6;
            this.button2.Text = "Load .txt File [Encryption]";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(8)))), ((int)(((byte)(49)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(249)))));
            this.button3.Location = new System.Drawing.Point(1136, 391);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(224, 39);
            this.button3.TabIndex = 7;
            this.button3.Text = "Load .txt File [Decryption]";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // EncryptedTextLocker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(2)))), ((int)(((byte)(4)))));
            this.ClientSize = new System.Drawing.Size(1367, 526);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Hack NF", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncryptedTextLocker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EncryptedTextLocker";
            this.Load += new System.EventHandler(this.EncryptedTextLocker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textToEncrypt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox encryptMessage;
        private System.Windows.Forms.Button encrypBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox decryptMessage;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.TextBox textToDecrypt;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}