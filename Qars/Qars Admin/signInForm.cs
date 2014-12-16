﻿using Qars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars_Admin
{
    public partial class signInForm : Form
    {

        public signInForm()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, EventArgs e) {

            this.SignInButton.Enabled = false;
            this.usernameTextBox.Enabled = false;
            this.passwordTextBox.Enabled = false;

            // make a DBConnect class
            DBConnect databaseConnect = new DBConnect();


            // get the username and password from the login box;
            string username = this.usernameTextBox.Text;
            string password = this.passwordTextBox.Text;


            Console.WriteLine(databaseConnect.CheckUser(username, password));

            this.passwordTextBox.Clear();
            this.SignInButton.Enabled = true;
            this.usernameTextBox.Enabled = true;
            this.passwordTextBox.Enabled = true;

        }
    }
}