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

namespace Qars_Admin {
    public partial class CarAdminPanel : UserControl {
        public CarAdminPanel(DBConnect dbConnect) {
            InitializeComponent();
            this.dataGridView1.DataSource = dbConnect.SelectCar();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
            Console.WriteLine(12);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            Console.WriteLine(123);
        }
    }
}
