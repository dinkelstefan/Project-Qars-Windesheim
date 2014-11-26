using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            string[] imgArray = {
                                    "http://pqrojectqars.herobo.com/fotomap/auto1.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto2.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto3.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto4.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto5.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto1.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto2.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto3.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto4.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto5.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto1.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto2.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto3.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto4.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto5.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto1.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto2.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto3.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto4.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto5.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto1.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto2.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto3.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto4.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto5.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto5.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto1.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto2.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto3.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto4.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto5.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto5.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto1.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto2.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto3.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto4.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto5.jpg",
                                    "http://pqrojectqars.herobo.com/fotomap/auto5.jpg"
                                };

            for (int i = 0; i < 20; i++) {
                CarListView newView = new CarListView(imgArray[i]);
                newView.Location = new System.Drawing.Point(20, i * (newView.Size.Height+20));
                this.Controls.Add(newView);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
