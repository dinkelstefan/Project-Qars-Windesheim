using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    //public enum ButtonState { Checked, Inactive }

    public class MyCheckBox
    {
        public Graphics grp;
        public int x;
        public int y;
        public int width;
        public int heigth;
        public int productID;
        public ButtonState bt;

      

        public MyCheckBox(Graphics g, int x, int y, int width, int height, ButtonState t, int id)
        {
            this.grp = g;
            this.x = x;
            this.y = y;
            this.width = width;
            this.heigth = height;
            this.bt = t;
            this.productID = id;
        }

        public bool IsHit(int x, int y)
        {
            Rectangle rc = new Rectangle(this.x, this.y, this.width, this.heigth);
            return rc.Contains(x, y);
        }
    }
}
