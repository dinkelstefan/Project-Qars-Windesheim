using System;
namespace Qars
{
    partial class RentCarPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.firstnameLabel = new System.Windows.Forms.Label();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.enddateLabel = new System.Windows.Forms.Label();
            this.startdataLabel = new System.Windows.Forms.Label();
            this.postalcodeLabel = new System.Windows.Forms.Label();
            this.streetnumberLabel = new System.Windows.Forms.Label();
            this.streetnameLabel = new System.Windows.Forms.Label();
            this.phonenumberLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.firstnameTextbox = new System.Windows.Forms.TextBox();
            this.lastnameTextbox = new System.Windows.Forms.TextBox();
            this.streetnameTextbox = new System.Windows.Forms.TextBox();
            this.streetnumberTextbox = new System.Windows.Forms.TextBox();
            this.streetnumbersuffixTextbox = new System.Windows.Forms.TextBox();
            this.postalcodeTextbox = new System.Windows.Forms.MaskedTextBox();
            this.phonenumberTextbox = new System.Windows.Forms.MaskedTextBox();
            this.startdateTextbox = new System.Windows.Forms.MaskedTextBox();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.enddateTextbox = new System.Windows.Forms.MaskedTextBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.streetnumbersuffixlabel = new System.Windows.Forms.Label();
            this.citylabel = new System.Windows.Forms.Label();
            this.cityTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.commentTextbox = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // firstnameLabel
            // 
            this.firstnameLabel.AutoSize = true;
            this.firstnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.firstnameLabel.Location = new System.Drawing.Point(38, 123);
            this.firstnameLabel.Name = "firstnameLabel";
            this.firstnameLabel.Size = new System.Drawing.Size(113, 26);
            this.firstnameLabel.TabIndex = 0;
            this.firstnameLabel.Text = "Voornaam";
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lastnameLabel.Location = new System.Drawing.Point(38, 167);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(130, 26);
            this.lastnameLabel.TabIndex = 8;
            this.lastnameLabel.Text = "Achternaam";
            // 
            // enddateLabel
            // 
            this.enddateLabel.AutoSize = true;
            this.enddateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.enddateLabel.Location = new System.Drawing.Point(38, 603);
            this.enddateLabel.Name = "enddateLabel";
            this.enddateLabel.Size = new System.Drawing.Size(117, 26);
            this.enddateLabel.TabIndex = 9;
            this.enddateLabel.Text = "Einddatum";
            // 
            // startdataLabel
            // 
            this.startdataLabel.AutoSize = true;
            this.startdataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.startdataLabel.Location = new System.Drawing.Point(38, 561);
            this.startdataLabel.Name = "startdataLabel";
            this.startdataLabel.Size = new System.Drawing.Size(129, 26);
            this.startdataLabel.TabIndex = 10;
            this.startdataLabel.Text = "Begindatum";
            // 
            // postalcodeLabel
            // 
            this.postalcodeLabel.AutoSize = true;
            this.postalcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.postalcodeLabel.Location = new System.Drawing.Point(38, 395);
            this.postalcodeLabel.Name = "postalcodeLabel";
            this.postalcodeLabel.Size = new System.Drawing.Size(122, 26);
            this.postalcodeLabel.TabIndex = 11;
            this.postalcodeLabel.Text = "+ Postcode";
            // 
            // streetnumberLabel
            // 
            this.streetnumberLabel.AutoSize = true;
            this.streetnumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.streetnumberLabel.Location = new System.Drawing.Point(38, 281);
            this.streetnumberLabel.Name = "streetnumberLabel";
            this.streetnumberLabel.Size = new System.Drawing.Size(137, 26);
            this.streetnumberLabel.TabIndex = 12;
            this.streetnumberLabel.Text = "Huisnummer";
            // 
            // streetnameLabel
            // 
            this.streetnameLabel.AutoSize = true;
            this.streetnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.streetnameLabel.Location = new System.Drawing.Point(38, 245);
            this.streetnameLabel.Name = "streetnameLabel";
            this.streetnameLabel.Size = new System.Drawing.Size(125, 26);
            this.streetnameLabel.TabIndex = 13;
            this.streetnameLabel.Text = "Straatnaam";
            // 
            // phonenumberLabel
            // 
            this.phonenumberLabel.AutoSize = true;
            this.phonenumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.phonenumberLabel.Location = new System.Drawing.Point(38, 487);
            this.phonenumberLabel.Name = "phonenumberLabel";
            this.phonenumberLabel.Size = new System.Drawing.Size(95, 26);
            this.phonenumberLabel.TabIndex = 14;
            this.phonenumberLabel.Text = "Telefoon";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.emailLabel.Location = new System.Drawing.Point(38, 450);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(122, 26);
            this.emailLabel.TabIndex = 15;
            this.emailLabel.Text = "Emailadres";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.titleLabel.Location = new System.Drawing.Point(184, 37);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(250, 46);
            this.titleLabel.TabIndex = 16;
            this.titleLabel.Text = "Huur de auto";
            // 
            // firstnameTextbox
            // 
            this.firstnameTextbox.Location = new System.Drawing.Point(192, 123);
            this.firstnameTextbox.Name = "firstnameTextbox";
            this.firstnameTextbox.Size = new System.Drawing.Size(242, 26);
            this.firstnameTextbox.TabIndex = 17;
            // 
            // lastnameTextbox
            // 
            this.lastnameTextbox.Location = new System.Drawing.Point(192, 166);
            this.lastnameTextbox.Name = "lastnameTextbox";
            this.lastnameTextbox.Size = new System.Drawing.Size(242, 26);
            this.lastnameTextbox.TabIndex = 18;
            // 
            // streetnameTextbox
            // 
            this.streetnameTextbox.Location = new System.Drawing.Point(192, 244);
            this.streetnameTextbox.Name = "streetnameTextbox";
            this.streetnameTextbox.Size = new System.Drawing.Size(242, 26);
            this.streetnameTextbox.TabIndex = 19;
            // 
            // streetnumberTextbox
            // 
            this.streetnumberTextbox.Location = new System.Drawing.Point(192, 295);
            this.streetnumberTextbox.Name = "streetnumberTextbox";
            this.streetnumberTextbox.Size = new System.Drawing.Size(113, 26);
            this.streetnumberTextbox.TabIndex = 20;
            // 
            // streetnumbersuffixTextbox
            // 
            this.streetnumbersuffixTextbox.Location = new System.Drawing.Point(311, 295);
            this.streetnumbersuffixTextbox.Name = "streetnumbersuffixTextbox";
            this.streetnumbersuffixTextbox.Size = new System.Drawing.Size(123, 26);
            this.streetnumbersuffixTextbox.TabIndex = 21;
            // 
            // postalcodeTextbox
            // 
            this.postalcodeTextbox.Location = new System.Drawing.Point(358, 377);
            this.postalcodeTextbox.Mask = "0000 LL";
            this.postalcodeTextbox.Name = "postalcodeTextbox";
            this.postalcodeTextbox.Size = new System.Drawing.Size(76, 26);
            this.postalcodeTextbox.TabIndex = 23;
            // 
            // phonenumberTextbox
            // 
            this.phonenumberTextbox.Location = new System.Drawing.Point(192, 486);
            this.phonenumberTextbox.Mask = "0000-000000";
            this.phonenumberTextbox.Name = "phonenumberTextbox";
            this.phonenumberTextbox.Size = new System.Drawing.Size(242, 26);
            this.phonenumberTextbox.TabIndex = 25;
            // 
            // startdateTextbox
            // 
            this.startdateTextbox.Location = new System.Drawing.Point(192, 560);
            this.startdateTextbox.Mask = "00/00/0000";
            this.startdateTextbox.Name = "startdateTextbox";
            this.startdateTextbox.Size = new System.Drawing.Size(108, 26);
            this.startdateTextbox.TabIndex = 26;
            this.startdateTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startdateTextbox.ValidatingType = typeof(System.DateTime);
            this.startdateTextbox.Enter += new System.EventHandler(this.openCalender);
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(192, 449);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(242, 26);
            this.emailTextbox.TabIndex = 24;
            // 
            // enddateTextbox
            // 
            this.enddateTextbox.Location = new System.Drawing.Point(192, 603);
            this.enddateTextbox.Mask = "00/00/0000";
            this.enddateTextbox.Name = "enddateTextbox";
            this.enddateTextbox.Size = new System.Drawing.Size(108, 26);
            this.enddateTextbox.TabIndex = 27;
            this.enddateTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.enddateTextbox.ValidatingType = typeof(System.DateTime);
            this.enddateTextbox.Enter += new System.EventHandler(this.openCalender);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(312, 377);
            this.monthCalendar.MinDate = new System.DateTime(2014, 11, 30, 0, 0, 0, 0);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 999;
            this.monthCalendar.Visible = false;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.closeCalender);
            // 
            // streetnumbersuffixlabel
            // 
            this.streetnumbersuffixlabel.AutoSize = true;
            this.streetnumbersuffixlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.streetnumbersuffixlabel.Location = new System.Drawing.Point(38, 307);
            this.streetnumbersuffixlabel.Name = "streetnumbersuffixlabel";
            this.streetnumbersuffixlabel.Size = new System.Drawing.Size(143, 26);
            this.streetnumbersuffixlabel.TabIndex = 29;
            this.streetnumbersuffixlabel.Text = "+ Toevoeging";
            // 
            // citylabel
            // 
            this.citylabel.AutoSize = true;
            this.citylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.citylabel.Location = new System.Drawing.Point(38, 369);
            this.citylabel.Name = "citylabel";
            this.citylabel.Size = new System.Drawing.Size(127, 26);
            this.citylabel.TabIndex = 30;
            this.citylabel.Text = "Woonplaats";
            // 
            // cityTextbox
            // 
            this.cityTextbox.Location = new System.Drawing.Point(192, 377);
            this.cityTextbox.Name = "cityTextbox";
            this.cityTextbox.Size = new System.Drawing.Size(160, 26);
            this.cityTextbox.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(581, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 372);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "carInfoGroupbox";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1016, 642);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 39);
            this.button1.TabIndex = 32;
            this.button1.Text = "Auto huren";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.rentCarClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(908, 642);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 39);
            this.button2.TabIndex = 33;
            this.button2.Text = "Annuleren";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.closeRentCarPanel);
            // 
            // commentTextbox
            // 
            this.commentTextbox.Location = new System.Drawing.Point(581, 438);
            this.commentTextbox.Name = "commentTextbox";
            this.commentTextbox.Size = new System.Drawing.Size(538, 191);
            this.commentTextbox.TabIndex = 34;
            this.commentTextbox.Text = "";
            // 
            // RentCarPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.commentTextbox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cityTextbox);
            this.Controls.Add(this.citylabel);
            this.Controls.Add(this.streetnumbersuffixlabel);
            this.Controls.Add(this.enddateTextbox);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.startdateTextbox);
            this.Controls.Add(this.phonenumberTextbox);
            this.Controls.Add(this.postalcodeTextbox);
            this.Controls.Add(this.streetnumbersuffixTextbox);
            this.Controls.Add(this.streetnumberTextbox);
            this.Controls.Add(this.streetnameTextbox);
            this.Controls.Add(this.lastnameTextbox);
            this.Controls.Add(this.firstnameTextbox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.phonenumberLabel);
            this.Controls.Add(this.streetnameLabel);
            this.Controls.Add(this.streetnumberLabel);
            this.Controls.Add(this.postalcodeLabel);
            this.Controls.Add(this.startdataLabel);
            this.Controls.Add(this.enddateLabel);
            this.Controls.Add(this.lastnameLabel);
            this.Controls.Add(this.firstnameLabel);
            this.Name = "RentCarPanel";
            this.Size = new System.Drawing.Size(1149, 694);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstnameLabel;
        private System.Windows.Forms.Label lastnameLabel;
        private System.Windows.Forms.Label enddateLabel;
        private System.Windows.Forms.Label startdataLabel;
        private System.Windows.Forms.Label postalcodeLabel;
        private System.Windows.Forms.Label streetnumberLabel;
        private System.Windows.Forms.Label streetnameLabel;
        private System.Windows.Forms.Label phonenumberLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox firstnameTextbox;
        private System.Windows.Forms.TextBox lastnameTextbox;
        private System.Windows.Forms.TextBox streetnameTextbox;
        private System.Windows.Forms.TextBox streetnumberTextbox;
        private System.Windows.Forms.TextBox streetnumbersuffixTextbox;
        private System.Windows.Forms.MaskedTextBox postalcodeTextbox;
        private System.Windows.Forms.MaskedTextBox phonenumberTextbox;
        private System.Windows.Forms.MaskedTextBox startdateTextbox;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.MaskedTextBox enddateTextbox;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label streetnumbersuffixlabel;
        private System.Windows.Forms.Label citylabel;
        private System.Windows.Forms.TextBox cityTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox commentTextbox;
        private System.Windows.Forms.Timer timer1;


    }
}
