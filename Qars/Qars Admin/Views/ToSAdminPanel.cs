using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qars;
using Qars.Models;
using Qars.Models.DBObjects;

namespace Qars_Admin.Views
{
    public partial class ToSAdminPanel : UserControl
    {
        private DBConnect connection;
        public ToSAdminPanel(DBConnect connection)
        {
            this.connection = connection;
            InitializeComponent();

            //Fill TextBox with Terms of Services
            List<ToS> tosList = connection.selectToS();
            string path = tosList[0].ToSInfo;
            ToSTextBox.Text = path;

            //Fill label with date
            ToSDate.Text = tosList[0].date;
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            string allText = ToSTextBox.Text;
            ToS tos = new ToS();
            tos.ToSID = 0;
            tos.ToSInfo = allText;
            tos.date = DateTime.Now.ToString();
            ToSDate.Text = DateTime.Now.ToString();
            DBConnect db = new DBConnect();
            db.InsertToS(tos);
        }

    }
}
