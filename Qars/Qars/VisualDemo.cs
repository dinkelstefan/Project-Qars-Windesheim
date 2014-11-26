using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Qars
{
    public partial class VisualDemo : Form
    {
        public int imageWidth = 160;
        public int imageHeigth = 160;
        public List<MyCheckBox> checkBoxes = new List<MyCheckBox>();
        public List<Car> compareList = new List<Car>();
        public List<Car> carList = new List<Car>();
        public int carNumber = 0;
        public string[] names = { "Fiets", "Audi", "DeLorean", "General Lee", "Maserati", "Sherman" };
        public string[] prices = { "0.50/km", "10/km", "25/km", "15/km", "40/km", "100/km" };

        public VisualDemo()
        {
            InitializeComponent();
            DoubleBuffered = true;

            BuildCars(6);

            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Kevin\Desktop\Cars");
            foreach (Car cr in carList)
            {
                try
                {
                    this.imageList1.Images.Add(Image.FromFile(cr.picPath));
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
           
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(imageWidth, imageHeigth);
            this.listView1.LargeImageList = this.imageList1;
           

            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listView1.Items.Add(new ListViewItem { ImageIndex = j });
                listView1.OwnerDraw = true;
                //listView1.DrawItem(DrawInformation);
               
            }
  
             listView1.DrawItem += new DrawListViewItemEventHandler(DrawInformation);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public CheckBoxState state = CheckBoxState.CheckedPressed;
        public bool clicked = false;
        

        public void DrawInformation(object sender, DrawListViewItemEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds.X + 15, e.Bounds.Y - 5, imageWidth + 14, imageHeigth + 37);
            e.Graphics.DrawString(names[(carNumber - 5) * -1] + "\n" + "Prijs: " + prices[(carNumber-5)*-1], new Font("Arial", 10), new SolidBrush(Color.Black), e.Bounds.X + 20, e.Bounds.Y + 162);

            
            MyCheckBox mb = new MyCheckBox(e.Graphics, e.Bounds.X + 170, e.Bounds.Y + 175, 15, 15, ButtonState.Inactive, carNumber);
            checkBoxes.Add(mb);
            Debug.WriteLine(checkBoxes[checkBoxes.Count - 1].productID);
            //Debug.WriteLine(carNumber);

            carNumber++;
            ControlPaint.DrawCheckBox(mb.grp, mb.x, mb.y, mb.width, mb.heigth, mb.bt);
            e.DrawDefault = true;
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (MyCheckBox mb in checkBoxes)
            {
                if (mb.IsHit(e.X, e.Y))
                {
                    clicked = !clicked;

                    //if (clicked)
                    //{
                    // mb.bt = ButtonState.Checked;
                    if (!compareList.Contains(carList[(mb.productID - 5) * -1]))
                    {
                        compareList.Add(carList[(mb.productID - 5) * -1]);
                        label3.Text += "" + carList[(mb.productID - 5) * -1].brand + " | ";
                    }
                   
                   // Debug.WriteLine(mb.productID);
                    //}
                    //else
                    //{
                    //mb.bt = ButtonState.Inactive;

                    //if(carList[mb.productID] != null)
                    // compareList.Remove(carList[mb.productID]);
                    //}


                    
                    break;
                }
            }

            if (compareList.Count > 1)
            {
                button1.Visible = true;
            }
        }

        void BuildCars(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Car car = new Car(i, names[i], 60, 25.00, @"C:\Users\Kevin\Desktop\Cars\" + i + ".jpg");
                carList.Add(car);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel p = new panel(compareList);
            this.Controls.Add(p);
            compareList.Clear();
            button1.Visible = false;
            label3.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

//Panel carPanel = new Panel();
//               carPanel.Size = new Size(176, 220);

//               PictureBox localBox = new PictureBox();
//               localBox.Image = imageList1.Images[0];
//               localBox.Size = new System.Drawing.Size(160, 160);
//               localBox.Top = 8;
//               localBox.Left = 8;
//               carPanel.Controls.Add(localBox);
//               carPanel.BackColor = Color.Blue;

//               Label name = new Label();
//               name.Text = "Auto";
//               carPanel.Controls.Add(name);
//               name.Left = 8;
//               name.Top = 170;
//               name.Font = new Font("Ariel", 16);


//               Label price = new Label();
//               price.Text = "25/km";
//               carPanel.Controls.Add(price);
//               price.Top = 190;
//               price.Left = 8;
//               price.Font = new Font("Ariel", 16);

//               CheckBox checkBox = new CheckBox();
//               carPanel.Controls.Add(checkBox);
//               checkBox.Top = 145;
//               checkBox.Left = 145;

//               this.Controls.Add(carPanel);
