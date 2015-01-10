using Qars;
using Qars.Models;
using Qars.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars_Admin.Views
{
    public partial class signInForm : Form
    {

        public signInForm()
        {
            InitializeComponent();
            this.usernameTextBox.Text = "admin";
            this.passwordTextBox.Text = "QuintorQARS1234";
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {

            this.SignInButton.Enabled = false;
            this.usernameTextBox.Enabled = false;
            this.passwordTextBox.Enabled = false;

            // make a DBConnect class
            DBConnect databaseConnect = new DBConnect();


            // get the username and password from the login box;
            string username = this.usernameTextBox.Text;
            string password = this.passwordTextBox.Text;


            User checkedUser = databaseConnect.CheckUser(username, password);

            if (checkedUser.accountLevel >= 0)
            {
                AdminForm admin = new AdminForm(checkedUser, databaseConnect);
                admin.Show();
                this.Hide();
            }
            else
            {
                this.passwordTextBox.Clear();
                this.SignInButton.Enabled = true;
                this.usernameTextBox.Enabled = true;
                this.passwordTextBox.Enabled = true;
            }
        }
    }
}
