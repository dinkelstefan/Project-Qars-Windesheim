using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    class CarListView:Panel
    {
        public CarListView(String imgURL){
            this.BackColor = Color.White;
            this.Name = "AUTONAAM_LISTVIEW";
            this.Size = new System.Drawing.Size(200, 100);
            this.TabIndex = 1;  
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new System.Drawing.Size(90, 90);
            this.Controls.Add(pictureBox);

            pictureBox.ImageLocation = imgURL;
        }

        private void panel2_Paint(object sender, PaintEventArgs e) {

        }
    }
}
