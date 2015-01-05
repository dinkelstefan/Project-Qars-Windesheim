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
using Qars_Admin.SimpleClasses;

namespace Qars_Admin.Panels
{
    public partial class userAdminPanel : UserControl
    {
        private DBConnect databaseConnection;
        private List<User> userList;

        public userAdminPanel(DBConnect connection)
        {
            this.databaseConnection = connection;
            InitializeComponent();

            this.refreshList();
        }

        public void refreshList()
        {
            List<simpleUser> simpleUserList = new List<simpleUser>();
            this.userList = this.databaseConnection.SelectUsers();

            foreach (User user in userList)
            {
                simpleUserList.Add(new simpleUser(user.customerID, user.accountLevel, user.username, user.firstname, user.lastname, user.city, user.phonenumber, user.emailaddress));
            }

            this.dataGridView1.DataSource = simpleUserList;
        }
    }
}
