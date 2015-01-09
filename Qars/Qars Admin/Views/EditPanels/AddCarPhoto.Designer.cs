namespace Qars_Admin.Views.EditPanels
{
    partial class AddCarPhoto
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.datatakenLabel = new System.Windows.Forms.Label();
            this.FotolinkLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.photoLinkTextBox = new System.Windows.Forms.TextBox();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.save_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nameLabel.Location = new System.Drawing.Point(123, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(77, 26);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Naam:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.descriptionLabel.Location = new System.Drawing.Point(55, 64);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(145, 26);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "Omschrijving:";
            // 
            // datatakenLabel
            // 
            this.datatakenLabel.AutoSize = true;
            this.datatakenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.datatakenLabel.Location = new System.Drawing.Point(12, 109);
            this.datatakenLabel.Name = "datatakenLabel";
            this.datatakenLabel.Size = new System.Drawing.Size(188, 26);
            this.datatakenLabel.TabIndex = 2;
            this.datatakenLabel.Text = "Foto genomen op:";
            // 
            // FotolinkLabel
            // 
            this.FotolinkLabel.AutoSize = true;
            this.FotolinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FotolinkLabel.Location = new System.Drawing.Point(106, 154);
            this.FotolinkLabel.Name = "FotolinkLabel";
            this.FotolinkLabel.Size = new System.Drawing.Size(94, 26);
            this.FotolinkLabel.TabIndex = 3;
            this.FotolinkLabel.Text = "Fotolink:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(206, 20);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(209, 26);
            this.nameTextBox.TabIndex = 4;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(206, 66);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(209, 26);
            this.descriptionTextBox.TabIndex = 5;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(206, 109);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(209, 26);
            this.dateTimePicker.TabIndex = 6;
            // 
            // photoLinkTextBox
            // 
            this.photoLinkTextBox.Location = new System.Drawing.Point(206, 156);
            this.photoLinkTextBox.Name = "photoLinkTextBox";
            this.photoLinkTextBox.Size = new System.Drawing.Size(209, 26);
            this.photoLinkTextBox.TabIndex = 7;
            this.photoLinkTextBox.TextChanged += new System.EventHandler(this.photoLinkTextBox_TextChanged);
            this.photoLinkTextBox.Enter += new System.EventHandler(this.photoLinkTextBox_Enter);
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.Location = new System.Drawing.Point(12, 204);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(414, 256);
            this.photoPictureBox.TabIndex = 8;
            this.photoPictureBox.TabStop = false;
            // 
            // save_Button
            // 
            this.save_Button.Location = new System.Drawing.Point(318, 466);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(108, 30);
            this.save_Button.TabIndex = 9;
            this.save_Button.Text = "Toevoegen";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "Annuleren";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddCarPhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 516);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.photoPictureBox);
            this.Controls.Add(this.photoLinkTextBox);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.FotolinkLabel);
            this.Controls.Add(this.datatakenLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "AddCarPhoto";
            this.Text = "AddCarPhoto";
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label datatakenLabel;
        private System.Windows.Forms.Label FotolinkLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox photoLinkTextBox;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button button1;
    }
}