using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
   public class AccountInterface : Panel
    {
        public AccountInterface()
        {
            Height = 570;
            Width = 1045;

            Top = 70;
            Left = 221;
            this.BackColor = Color.FromArgb(240, 240, 240);

            Label welcomeBanner = new Label();
            welcomeBanner.Top = 5;
            welcomeBanner.Left = 5;
            welcomeBanner.Text = "Welkom";
            welcomeBanner.Height = 50;
            welcomeBanner.Width = 500;
            welcomeBanner.Font = new Font("Ariel", 20);

            this.Controls.Add(welcomeBanner);
        }
    }
}
