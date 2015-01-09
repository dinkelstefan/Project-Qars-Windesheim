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
using Qars_Admin.Models.SimpleClasses;
using Qars_Admin.Views.EditPanels;
using Qars.Models;
using Qars.Models.DBObjects;

namespace Qars_Admin.Views
{
    public partial class UserAdminPanel : UserControl
    {
        private DBConnect databaseConnection;
        private List<User> userList;
        private AdminForm adminForm;


        public UserAdminPanel(DBConnect connection, AdminForm adminform)
        {
            this.databaseConnection = connection;
            this.adminForm = adminform;
            InitializeComponent();

            this.refreshList();
        }

        public void refreshList()
        {
            List<simpleUser> simpleUserList = new List<simpleUser>();
            this.userList = this.databaseConnection.SelectUsers();

            foreach (User user in userList)
            {
                if (user.Establishment == adminForm.currentUser.Establishment || adminForm.currentUser.accountLevel == 4)
                {
                    simpleUserList.Add(new simpleUser(user.UserID, user.accountLevel, user.username, user.firstname, user.lastname, user.city, user.phonenumber, user.emailaddress));
                }
            }

            this.userDataGridView.DataSource = simpleUserList;
        }

        private void userDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = this.userDataGridView.CurrentCell.RowIndex;
            List<simpleUser> userList = this.userDataGridView.DataSource as List<simpleUser>;
            int simpleUserID = userList[rowIndex].GebruikerID;

            var query = from u in this.userList
                        where u.UserID == simpleUserID
                        select u;

            User user = query.First();

            editUserWindow editWindow = new editUserWindow(user, databaseConnection);
            editWindow.ShowDialog();

            this.refreshList();
        }
    }
}
