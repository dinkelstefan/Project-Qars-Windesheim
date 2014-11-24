using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Smooth_Moving_Button
{
    public partial class Form1 : Form
    {
        int left;
        int right;
        bool pressed = false;
        bool pressedBack = false;
        int buffer;
        Point temp = new Point(0, 0);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (pressed == false)              
            {
                timer1.Start();                          //je kan er al op klikken wanneer die al aan het draaien is....:(   en langzamerhand gaat ie naar links...
                Button b = (Button)sender;
                left = b.Location.X;
                if (buffer < 0)
                {
                    MessageBox.Show("kleiner dan 0");
                }
                buffer = b.Location.X;
                
            }

            if (pressed == true)
            {
                pressedBack = true;   //met comments 
                timer1.Start();
                Button b = (Button)sender;
                right = b.Location.Y;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {


            if (pressed == false)
            {
                if (button1.Left <= 140)   //max positie
                {
                    button1.Enabled = false;
                    left += 5;
                    button1.Left = left;
                    if (button1.Left > 140)
                    {
                        button1.Enabled = true;
                    }
                }
                else
                {
                    pressed = true;                     //als deze variabele wordt geplaatst op 
                    timer1.Stop();                       
                }
            }

            if (pressedBack)  //pressed                  //deze plek, dan voert hij deze actie ook half uit....
            {
                if (button1.Left >= buffer)   //min positie
                {
                    button1.Enabled = false;
                    left -= 5;
                    button1.Left = left;
                    if (button1.Left < buffer)
                    {
                        button1.Enabled = true;
                    }
                }
                else
                {
                    pressed = false;
                    pressedBack = false;   //dit comments
                    int difference = buffer - button1.Left;
                    button1.Left += difference; 
                    timer1.Stop();
                }
            }
        }
    }
}
