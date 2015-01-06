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

//voor lettertype
//https://social.msdn.microsoft.com/Forums/en-US/052e51ed-85a2-47b2-a359-cedb8317d1cc/make-string-to-bold-letters?forum=csharplanguage

namespace Qars
{
    public partial class TermsOfService : Form
    {
        public VisualDemo qarsapp { get; set; }
        public TermsOfService(VisualDemo qarsapp)
        {
            this.qarsapp = qarsapp;
            InitializeComponent();
            List<ToS> toslist = new DBConnect().selectToS();
            string path = toslist[0].ToSInfo;
            richTextBox1.Text = path;
            date.Text = toslist[0].date;
            if (qarsapp.userID == 4)
            {
                edit.Visible = true;
            }

        }


        List<int> posUnderlined = new List<int>();
        List<int> posItalic = new List<int>();
        List<int> posBolded = new List<int>();

        List<string> result = new List<string>();
        List<string> allItalic = new List<string>();
        List<string> boldedText = new List<string>();    //elke combi krijgt een andere vorm van <>  eerst makkelijke
        List<string> italicText = new List<string>();
        List<string> underlinedText = new List<string>();
        List<string> temporaryList = new List<string>();



        List<string> uniqueBoldedText = new List<string>();
        List<string> uniqueItalicText = new List<string>();
        List<string> uniqueUnderlinedText = new List<string>();



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = false;
            save.Visible = true;
            delete.Visible = true;
            userView.Visible = true;
            edit.Visible = false;

        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat alle inhoud verwijderd wordt?", "verwijderen", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                richTextBox1.Clear();
            }
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
            delete.Visible = false;
            edit.Visible = true;
            userView.Visible = false;
        }


    }
}

