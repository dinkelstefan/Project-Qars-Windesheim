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
        public AddCarPhoto(int CarID, int HighestPhotoID, EditCarWindow carWindow)
        {
            InitializeComponent();
            this.CarID = CarID;
            this.HighestPhotoID = HighestPhotoID;
            this.carWindow = carWindow;
        }


        private void ChoosePictureButton_Click(object sender, EventArgs e)
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
                    error = true;
                    MessageBox.Show("De foto mag maximaal 2.5 megabytes zijn!");
                }
                if (error == false)
                {
                    string extension = fi.Extension;
                    if (extension == ".png")
                    {
                        error = false;
                    }
                    else if (extension == ".jpg")
                    {
                        error = false;
                    }
                    else
                    {
                        error = true;
                    }
                }
                else
                {
                    MessageBox.Show("Alleen foto's met een .png en .jpg extensie zijn toegestaan!");
                }
                if (error == false)
                {
                    photoPictureBox.Image = Image.FromFile(photoLink);
                    photoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("Uw geselecteerde foto is niet correct!");
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
            CarPhoto photo = new CarPhoto(this.HighestPhotoID, this.CarID, nameTextBox.Text, descriptionTextBox.Text, dateTimePicker.Text, openFileDialog.FileName);
            carWindow.addCarPhoto(photo);
            this.Close();
        }
    }
}
