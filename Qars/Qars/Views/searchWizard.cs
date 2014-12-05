using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars.Views
{
    public partial class searchWizard : UserControl
    {
        private string[] awnsers = new string[5];
        public searchWizard()
        {
            InitializeComponent();
        }

        private void selectCarType(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            this.awnsers[0] = rb.Text;
        }

        private void transissionType(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            this.awnsers[1] = rb.Text;
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                builder.AppendLine(this.awnsers[i]);
            }
            return builder.ToString();
        }

        private void priceClassChanged(object sender, EventArgs e)
        {
            CheckBox rb = (CheckBox)sender;
            }

        private void cityChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            Console.WriteLine(cb.Text);
        }

    }
}
