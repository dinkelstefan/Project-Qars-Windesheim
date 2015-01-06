using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    public partial class LogInForm : Form
    {
        public int userID { get; set; }
        public VisualDemo qarsApplication { get; set; }
        public LogInForm(VisualDemo qarsapp, int UserID)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.qarsApplication = qarsapp;
            this.userID = userID;
            InitializeComponent();
        }

        private void LoggingInButton_Click(object sender, EventArgs e)
        {
            bool validusername = false;
            bool validpassword = false;
            Regex usernameRegex = new Regex("^[\\Sa-zA-Z0-9]{6,25}$");
            Regex passwordRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,255}$");

            if (usernameRegex.IsMatch(UsernameTextBox.Text))
            {
                validusername = true;
            }
            if (passwordRegex.IsMatch(PasswordTextBox.Text))
            {
                validpassword = true;
            }

            if (validusername == true && validpassword == true)
            {
                DBConnect db = new DBConnect();
                int logInResult = db.LogInUser(UsernameTextBox.Text, PasswordTextBox.Text);

                if (logInResult != 0)
                {
                    userID = logInResult;
                    this.Dispose();
                    qarsApplication.userID = logInResult;//Return to the form and let the user be logged in, assign the new user ID and stuff
                }
                else
                {
                    LogInFailureLabel.Visible = true;
                    UsernameLabel.ForeColor = Color.Red;
                    passwordLabel2.ForeColor = Color.Red;
                }
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
            registerform.ShowDialog();
        }
        private void CancelButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public int returnUserID()
        {
            return userID;
        }
    }
}

