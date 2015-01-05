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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            //RegisterForm registerform = new RegisterForm();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            bool logInResult = db.LogInUser(UsernameTextBox.Text, PasswordTextBox.Text); //validate input
            if (logInResult == true)
            {
                this.Dispose();
            }
            else
            {
                UsernameLabel.ForeColor = Color.Red;
                PasswordLabel.ForeColor = Color.Red;

            }
        }


    }
}
