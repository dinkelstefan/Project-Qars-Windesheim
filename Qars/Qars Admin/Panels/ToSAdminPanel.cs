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

namespace Qars_Admin.Panels
{
    public partial class ToSAdminPanel : UserControl
    {
        private DBConnect connection;
        public ToSAdminPanel(DBConnect connection)
        {
            this.connection = connection;
            InitializeComponent();
        }
    }
}
