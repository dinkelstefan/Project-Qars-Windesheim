using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qars;

namespace Qars_Admin.EditPanels
{
    public partial class editUserWindow : Form
    {
        private DBConnect connection;
        public editUserWindow(User user, DBConnect connection)
        {
            InitializeComponent();
            this.connection = connection;

            userIdTextBox.Text = user.UserID.ToString();
            accountLevelTextBox.Text = user.accountLevel.ToString();
            usernameTextBox.Text = user.username;
            passwordTextBox.Text = user.password;
            firstnameTextBox.Text = user.firstname;
            lastnameTextBox.Text = user.lastname;
            ageTextBox.Text = user.age.ToString();
            cityTextBox.Text = user.city;
            postalCodeTextBox.Text = user.postalcode;
            streetnameTextBox.Text = user.streetname;
            streetnumberTextBox.Text = user.streetnumber.ToString();
            streetnumberSuffixTextBox.Text = user.streetnumbersuffix;
            phonenumberTextBox.Text = user.phonenumber;
            emailadresTextBox.Text = user.emailaddress;
            driverLicensePictureBox.ImageLocation = user.driverslicenselink;

            //Fill combobox
            int i = 0;
            List<Establishment> establishmentList = connection.SelectEstablishment();
            foreach (Establishment est in establishmentList)
            {
                establishmentComboBox.Items.Add(est.name);
                if (user.Esthablishment == est.establishmentID)
                {
                        establishmentComboBox.SelectedIndex = i;
                }
                i++;
            }
            
        }

        private User getUserFromFields()
        {
            User user = new User();

            user.UserID = Int32.Parse(userIdTextBox.Text);
            user.accountLevel = Int32.Parse(accountLevelTextBox.Text);
            user.username = usernameTextBox.Text;
            user.password = passwordTextBox.Text;
            user.firstname = firstnameTextBox.Text;
            user.lastname = lastnameTextBox.Text;
            user.age = Int32.Parse(ageTextBox.Text);
            user.postalcode = postalCodeTextBox.Text;
            user.city = cityTextBox.Text;
            user.streetname = streetnameTextBox.Text;
            user.streetnumber = Int32.Parse(streetnumberTextBox.Text);
            user.streetnumbersuffix = streetnumberSuffixTextBox.Text;
            user.phonenumber = phonenumberTextBox.Text;
            user.emailaddress = emailadresTextBox.Text;
            user.Esthablishment = establishmentComboBox.SelectedIndex + 1;

            return user;
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            try
            {
                User user = getUserFromFields();
                this.connection.UpdateUser(user);

                MessageBox.Show("De gebruiker is succesvol geupdate.");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Het format van de door u ingevulde tekst klopt niet");
            }

        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            User user = getUserFromFields();
            this.connection.DeleteUser(user);
            this.Close();

        }

        private void TextBoxAlphabeticalChars_KeyPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || e.KeyData == Keys.Back || e.KeyData == Keys.Delete || e.KeyData == Keys.OemMinus)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                MessageBox.Show("U mag hier geen getallen invullen.");
            }
        }
        private void TextBoxNumOnly_KeyPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9) || e.KeyData == Keys.OemMinus || e.KeyData == Keys.Back || e.KeyData == Keys.Delete)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                MessageBox.Show("U mag hier geen letters invullen.");
            }
        }
    }
}
