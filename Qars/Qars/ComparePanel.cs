using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars
{
    class ComparePanel : Panel
    {
        public List<Car> cars { get; set; }
        public string[] compareItems = { "startprice","rentalprice", "brand", "model", "category", "modelyear", "horsepower", "doors", "seats", "Fuelusage", "motor" };
        //items in code are given in English. In the application the translation is shown.
        public string[] compareItemsTranslation = { "startprijs","Huurprijs", "Merk", "model", "Categorie", "Bouwjaar", "Vermogen", "Deuren", "Stoelen", "Verbruik", "Motor" };
        public List<string> checkHighest = new List<String>{"modelyear", "horsepower","doors","seats" };
        public List<string> checkLowest = new List<String> {"startprice","rentalprice","Fuelusage"};
        public List<Label> allLabels { get; set; }
        public List<PictureBox> pictures { get; set; }
        public Graphics graphics;
        public int pictureHeight { get; set; }
        public int pictureMargin { get; set; }
        public int sideMargin { get; set; }
        public int topMargin { get; set; }
        public int columnWidth { get; set; }
        public int labelHeight { get; set; }

        public ComparePanel(List<Car> list)
        {
            allLabels = new List<Label>();
            this.Font = new Font("Calibri", 14);
            sideMargin = 100;
            topMargin = 27;
            Height = 570;
            Width = 1045;
            columnWidth = (Width - sideMargin) / list.Count;
            pictureHeight = 200;
            pictureMargin = 1;
            labelHeight = 30;
            this.BackColor = Color.FromArgb(240, 240, 240);
            cars = list;

            this.Top = 70;
            this.Left = 221;

            pictures = new List<PictureBox>();
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //close button
            Button closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.Width = Width;
            closeButton.Height = topMargin;
            closeButton.BackColor = Color.White;
            closeButton.Click += closeClick;
            this.Controls.Add(closeButton);


            //put categories in the sidebar
            for (int i = 0; i < compareItems.Length; i++)
            {
                Label tempLabel = new Label();
                tempLabel.Text = compareItemsTranslation[i];
                tempLabel.Top = topMargin + pictureHeight + labelHeight * i;
                tempLabel.Width = 100;
                tempLabel.Height = labelHeight;
                tempLabel.TextAlign = ContentAlignment.MiddleLeft;
                tempLabel.BackColor = Color.Transparent;
                this.Controls.Add(tempLabel);
                allLabels.Add(tempLabel);
            }

            for (int i = 0; i < cars.Count; i++)
            {
                // check if car has a photo
                if (cars[i].PhotoList.Count > 0)
                {
                    pictures.Add(new PictureBox());
                    pictures[i].Left = sideMargin + columnWidth * i + pictureMargin;
                    pictures[i].ImageLocation = cars[i].PhotoList[0].Photolink;
                    pictures[i].Width = columnWidth - pictureMargin * 2;
                    pictures[i].Top = topMargin;
                    pictures[i].Height = pictureHeight;
                    pictures[i].SizeMode = PictureBoxSizeMode.Zoom;
                    pictures[i].BorderStyle = BorderStyle.FixedSingle;
                    this.Controls.Add(pictures[i]);
                }

                //add all labels for the compare items.
                for (int j = 0; j < compareItems.Length; j++)
                {
                    Label tempLabel = new Label();
                    tempLabel.Text = Convert.ToString(GetPropValue(cars[i],compareItems[j]));
                    tempLabel.Left = sideMargin + columnWidth * i;
                    tempLabel.Top = topMargin + pictureHeight + labelHeight * j;
                    tempLabel.Height = labelHeight;
                    tempLabel.Width = columnWidth;
                    tempLabel.TextAlign = ContentAlignment.MiddleCenter;
                    tempLabel.BackColor = Color.Transparent;
                    if (checkHighest.Contains(compareItems[j]))
                    {
                        CheckHighest(compareItems[j], ref tempLabel, cars[i]);
                    }
                    if (checkLowest.Contains(compareItems[j]))
                    {
                        CheckLowest(compareItems[j], ref tempLabel, cars[i]);
                    }
                    this.Controls.Add(tempLabel);
                    allLabels.Add(tempLabel);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            graphics = e.Graphics;
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.FromArgb(97, 97, 97));

            //rectangle for the items in the list
            for (int i = 0; i < compareItems.Length; i+=2)
            {
                graphics.FillRectangle(brush, new Rectangle(0,topMargin + pictureHeight + labelHeight * i,Width, labelHeight));
            }

            //styling lines can be put here.
            graphics.DrawLine(pen, new Point(0, topMargin + pictureHeight), new Point(Width, topMargin + pictureHeight));

            for (int i = 0; i < cars.Count; i++){
                graphics.DrawLine(pen, new Point(sideMargin + columnWidth * i, topMargin), new Point(sideMargin + columnWidth * i, Height));
            }
            
            this.BringToFront();
        }

        public void closeClick(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        public void CheckHighest(string item, ref Label label,Car car){
            double[] compare = new double[cars.Count];
            
            for (int i = 0; i < compare.Length; i++){
                compare[i] = Convert.ToDouble(GetPropValue(cars[i],item));
            }
            double maxValue = compare.Max();
            if (maxValue == Convert.ToDouble(GetPropValue(car,item))){
                label.Text = label.Text + " \u221A";
                label.Font = new Font("Calibri", 14, FontStyle.Bold);
                
                //big check
                //Label tempLabel = new Label();
                //tempLabel.Text = "\u221A";
                //tempLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
                //tempLabel.Left = label.Left + label.Width;
                //tempLabel.Top = label.Top;
                //tempLabel.Height = labelHeight;
                //tempLabel.Width = columnWidth;
                //tempLabel.TextAlign = ContentAlignment.MiddleCenter;
                //tempLabel.BackColor = Color.Transparent;
                //this.Controls.Add(tempLabel);
                //allLabels.Add(tempLabel);
            }
        }

        public void CheckLowest(string item, ref Label label, Car car)
        {
            double[] compare = new double[cars.Count];
            for (int i = 0; i < compare.Length; i++){
                compare[i] = Convert.ToDouble(GetPropValue(cars[i], item));
            }
            double maxValue = compare.Min();
            if (maxValue == Convert.ToDouble(GetPropValue(car, item))){
                label.Text = label.Text + " \u221A";
                label.Font = new Font("Calibri", 14, FontStyle.Bold);
            }
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
