using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    public partial class LogInForm : Form
    {
        public VisualDemo qarsApplication { get; set; }
        public LogInForm(VisualDemo qarsapp)
        {
            this.qarsApplication = qarsapp;
            InitializeComponent();
        }

        private void LoggingInButton_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            bool logInResult = db.LogInUser(UsernameTextBox.Text, PasswordTextBox.Text); //validate input

            if (logInResult == true)
            {
                this.Dispose();
                MessageBox.Show("Gelukt");
                //Return to the form and let the user be logged in, assign the new user ID and stuff
            }
            else
            {
                LogInFailureLabel.Visible = true;
                UsernameLabel.ForeColor = Color.Red;
                passwordLabel2.ForeColor = Color.Red;
            }
        }

        private void RegisterButton_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            RegisterForm registerform = new RegisterForm();
            registerform.Show();
        }

        private void CancelButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

