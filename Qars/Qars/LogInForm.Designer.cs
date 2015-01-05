namespace Qars
{
    partial class LogInForm
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
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LogInButton = new System.Windows.Forms.Button();
            this.LogInFailureLabel = new System.Windows.Forms.Label();
            this.LoggingInButton = new System.Windows.Forms.Button();
            this.CancelButton2 = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.passwordLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(104, 24);
            this.UsernameTextBox.MaxLength = 50;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.UsernameTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(104, 59);
            this.PasswordTextBox.MaxLength = 255;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(12, 27);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(87, 13);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Gebruikersnaam:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(0, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(100, 23);
            this.PasswordLabel.TabIndex = 0;
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(237, 24);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(75, 55);
            this.LogInButton.TabIndex = 4;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = true;
            // 
            // LogInFailureLabel
            // 
            this.LogInFailureLabel.AutoSize = true;
            this.LogInFailureLabel.BackColor = System.Drawing.SystemColors.Control;
            this.LogInFailureLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogInFailureLabel.ForeColor = System.Drawing.Color.Black;
            this.LogInFailureLabel.Location = new System.Drawing.Point(36, 6);
            this.LogInFailureLabel.Name = "LogInFailureLabel";
            this.LogInFailureLabel.Size = new System.Drawing.Size(256, 15);
            this.LogInFailureLabel.TabIndex = 7;
            this.LogInFailureLabel.Text = "Verkeerde gebruikersnaam/wachtwoord combinatie!\r\n";
            this.LogInFailureLabel.Visible = false;
            // 
            // LoggingInButton
            // 
            this.LoggingInButton.Location = new System.Drawing.Point(236, 28);
            this.LoggingInButton.Name = "LoggingInButton";
            this.LoggingInButton.Size = new System.Drawing.Size(75, 51);
            this.LoggingInButton.TabIndex = 8;
            this.LoggingInButton.Text = "Log In";
            this.LoggingInButton.UseVisualStyleBackColor = true;
            this.LoggingInButton.Click += new System.EventHandler(this.LoggingInButton_Click);
            // 
            // CancelButton2
            // 
            this.CancelButton2.Location = new System.Drawing.Point(12, 91);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 9;
            this.CancelButton2.Text = "Annuleer";
            this.CancelButton2.UseVisualStyleBackColor = true;
            this.CancelButton2.Click += new System.EventHandler(this.CancelButton2_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(236, 91);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(75, 23);
            this.RegisterButton.TabIndex = 10;
            this.RegisterButton.Text = "Registreer";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click_1);
            // 
            // passwordLabel2
            // 
            this.passwordLabel2.AutoSize = true;
            this.passwordLabel2.Location = new System.Drawing.Point(12, 62);
            this.passwordLabel2.Name = "passwordLabel2";
            this.passwordLabel2.Size = new System.Drawing.Size(71, 13);
            this.passwordLabel2.TabIndex = 11;
            this.passwordLabel2.Text = "Wachtwoord:";
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 126);
            this.Controls.Add(this.passwordLabel2);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.LoggingInButton);
            this.Controls.Add(this.LogInFailureLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LogInForm";
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Label LogInFailureLabel;
        private System.Windows.Forms.Button LoggingInButton;
        private System.Windows.Forms.Button CancelButton2;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label passwordLabel2;
    }
}