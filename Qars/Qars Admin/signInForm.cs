﻿using System;
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

            AdminForm admin = new AdminForm();
            admin.Show();
            this.Hide();
        }
    }
}
