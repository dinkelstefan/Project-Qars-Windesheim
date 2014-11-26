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


            if (pressed == false)              //if the button is at the minimum left position
            {
                timer1.Start();                        
                Button b = (Button)sender;
                left = b.Location.X;
                buffer = b.Location.X;
                
            }

            if (pressed == true)                //if the button reached the maximum right position
            {
                pressedBack = true;   
                timer1.Start();
                Button b = (Button)sender;
                right = b.Location.Y;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {


            if (pressed == false)   //trigger the button to go to end location  
            {
                if (button1.Left <= 140)   //maximum position for button
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
                    pressed = true;                    
                    timer1.Stop();                       
                }
            }

            if (pressedBack)               //trigger the button to go to begin location             2nd trigger if other buttons are clicked (not yet implemented)    
            {
                if (button1.Left > buffer)    //minimum position for button
                {
                    button1.Enabled = false;

                        left -= 5;
                    
                        button1.Left = left;
                        if (button1.Left < buffer)
                        {
                            button1.Left += (buffer - button1.Left);         //if distance between begin location and current postion differs, equalize it...
                        }

                        if (button1.Left == buffer)          //if distance is 0 between begin location and current position
                        {
                         button1.Enabled = true;
                        }
                }
                else
                {
                    pressed = false;
                    pressedBack = false;   
                    timer1.Stop();
                }
            }
        }
    }
}
