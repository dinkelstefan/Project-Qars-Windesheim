using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Qars.Models.DBObjects;
using Qars.Models;

namespace Qars.Views
{
    public partial class TermsOfService : Form
    {
        public VisualDemo qarsapp { get; set; }
        public TermsOfService()
        {
            InitializeComponent();
            List<ToS> toslist = new DBConnect().selectToS();

            richTextBox1.Text = toslist[0].ToSInfo;
            date.Text = toslist[0].date;
            edit.Visible = false;

        }
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = false;
            save.Visible = true;
            userView.Visible = true;
            edit.Visible = false;
        }
        private void save_Click(object sender, EventArgs e)
        {
            string allText = richTextBox1.Text;
            ToS tos = new ToS();
            tos.ToSID = 0;
            tos.ToSInfo = allText;
            tos.date = DateTime.Now.ToString();
            date.Text = DateTime.Now.ToString();
            DBConnect db = new DBConnect();
            db.InsertToS(tos);
        }

        private void userView_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            save.Visible = false;
            edit.Visible = true;
            userView.Visible = false;
        }


    }
}

