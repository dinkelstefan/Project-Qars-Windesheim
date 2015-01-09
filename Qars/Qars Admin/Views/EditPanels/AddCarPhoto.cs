using Qars;
using Qars.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qars_Admin.Views.EditPanels
{
    public partial class AddCarPhoto : Form
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private int CarID;
        private int HighestPhotoID;
        private EditCarWindow carWindow;
        bool JPG;
        public AddCarPhoto(int CarID, int HighestPhotoID, EditCarWindow carWindow)
        {
            InitializeComponent();
            this.CarID = CarID;
            this.HighestPhotoID = HighestPhotoID;
            this.carWindow = carWindow;
        }

        private void photoLinkTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void photoLinkTextBox_Enter(object sender, EventArgs e)
        {

            bool error = false;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "JPG files (*.JPG)|*.jpg|PNG files(*.PNG)|*.PNG";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string photoLink = openFileDialog.FileName;
                FileInfo fi = new FileInfo(photoLink);

                long fileSize = fi.Length; //The size of the current file in bytes.file
                if (fileSize > 2621440)
                {
                    photoLink = "";
                }
                else
                {
                    string extension = fi.Extension;
                    Console.WriteLine(extension);
                    if (extension == ".jpg")
                    {
                        JPG = true;
                    }
                    else if (extension == ".png")
                    {
                        JPG = false;
                    }
                    else
                    {
                        error = true;
                    }
                    if (error == false)
                    {
                        photoPictureBox.Image = Image.FromFile(photoLink);
                        photoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        photoLinkTextBox.Text = openFileDialog.FileName;
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            //set right format for the database
            dateTimePicker.CustomFormat = "dd-mm-yyyy";
            CarPhoto photo = new CarPhoto(this.HighestPhotoID, this.CarID, nameTextBox.Text, descriptionTextBox.Text, dateTimePicker.Text, photoLinkTextBox.Text);
            carWindow.addCarPhoto(photo);
            this.Close();
        }
    }
}
