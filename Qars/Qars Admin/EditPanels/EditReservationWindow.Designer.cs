namespace Qars_Admin.EditPanels
{
    partial class EditReservationWindow
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.startDateTextBox = new System.Windows.Forms.TextBox();
            this.endDateTextBox = new System.Windows.Forms.TextBox();
            this.confirmedCheckBox = new System.Windows.Forms.CheckBox();
            this.kilometersTextbox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.streetnameTextBox = new System.Windows.Forms.TextBox();
            this.streetnumberTextBox = new System.Windows.Forms.TextBox();
            this.paidCheckBox = new System.Windows.Forms.CheckBox();
            this.commentCheckBox = new System.Windows.Forms.RichTextBox();
            this.streetnumberSuffixTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.delete_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(170, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Begindatum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(182, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Einddatum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(186, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bevestigd";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(178, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Kilometers";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label7.Location = new System.Drawing.Point(221, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Plaats";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label8.Location = new System.Drawing.Point(169, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 26);
            this.label8.TabIndex = 7;
            this.label8.Text = "Straatnaam";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label9.Location = new System.Drawing.Point(20, 303);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(274, 26);
            this.label9.TabIndex = 8;
            this.label9.Text = "Huisnummer + Toevoeging";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label10.Location = new System.Drawing.Point(208, 386);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 26);
            this.label10.TabIndex = 9;
            this.label10.Text = "Betaald";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label11.Location = new System.Drawing.Point(175, 421);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 26);
            this.label11.TabIndex = 10;
            this.label11.Text = "Opmerking";
            // 
            // startDateTextBox
            // 
            this.startDateTextBox.Location = new System.Drawing.Point(341, 24);
            this.startDateTextBox.Name = "startDateTextBox";
            this.startDateTextBox.Size = new System.Drawing.Size(117, 26);
            this.startDateTextBox.TabIndex = 13;
            this.startDateTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNumOnly_KeyPress);
            this.startDateTextBox.Leave += new System.EventHandler(this.checkFormat_Leave);
            // 
            // endDateTextBox
            // 
            this.endDateTextBox.Location = new System.Drawing.Point(341, 64);
            this.endDateTextBox.Name = "endDateTextBox";
            this.endDateTextBox.Size = new System.Drawing.Size(117, 26);
            this.endDateTextBox.TabIndex = 14;
            this.endDateTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNumOnly_KeyPress);
            this.endDateTextBox.Leave += new System.EventHandler(this.checkFormat_Leave);
            // 
            // confirmedCheckBox
            // 
            this.confirmedCheckBox.AutoSize = true;
            this.confirmedCheckBox.Location = new System.Drawing.Point(341, 111);
            this.confirmedCheckBox.Name = "confirmedCheckBox";
            this.confirmedCheckBox.Size = new System.Drawing.Size(22, 21);
            this.confirmedCheckBox.TabIndex = 15;
            this.confirmedCheckBox.UseVisualStyleBackColor = true;
            // 
            // kilometersTextbox
            // 
            this.kilometersTextbox.Location = new System.Drawing.Point(341, 159);
            this.kilometersTextbox.Name = "kilometersTextbox";
            this.kilometersTextbox.Size = new System.Drawing.Size(117, 26);
            this.kilometersTextbox.TabIndex = 16;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(341, 233);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(117, 26);
            this.cityTextBox.TabIndex = 17;
            this.cityTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxAlphabeticalChars_KeyPress);
            // 
            // streetnameTextBox
            // 
            this.streetnameTextBox.Location = new System.Drawing.Point(341, 270);
            this.streetnameTextBox.Name = "streetnameTextBox";
            this.streetnameTextBox.Size = new System.Drawing.Size(117, 26);
            this.streetnameTextBox.TabIndex = 18;
            this.streetnameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxAlphabeticalChars_KeyPress);
            // 
            // streetnumberTextBox
            // 
            this.streetnumberTextBox.Location = new System.Drawing.Point(341, 305);
            this.streetnumberTextBox.Name = "streetnumberTextBox";
            this.streetnumberTextBox.Size = new System.Drawing.Size(77, 26);
            this.streetnumberTextBox.TabIndex = 19;
            this.streetnumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNumOnly_KeyPress);
            // 
            // paidCheckBox
            // 
            this.paidCheckBox.AutoSize = true;
            this.paidCheckBox.Location = new System.Drawing.Point(341, 386);
            this.paidCheckBox.Name = "paidCheckBox";
            this.paidCheckBox.Size = new System.Drawing.Size(22, 21);
            this.paidCheckBox.TabIndex = 20;
            this.paidCheckBox.UseVisualStyleBackColor = true;
            // 
            // commentCheckBox
            // 
            this.commentCheckBox.Location = new System.Drawing.Point(341, 423);
            this.commentCheckBox.Name = "commentCheckBox";
            this.commentCheckBox.Size = new System.Drawing.Size(227, 161);
            this.commentCheckBox.TabIndex = 21;
            this.commentCheckBox.Text = "";
            // 
            // streetnumberSuffixTextBox
            // 
            this.streetnumberSuffixTextBox.Location = new System.Drawing.Point(424, 305);
            this.streetnumberSuffixTextBox.Name = "streetnumberSuffixTextBox";
            this.streetnumberSuffixTextBox.Size = new System.Drawing.Size(34, 26);
            this.streetnumberSuffixTextBox.TabIndex = 22;
            this.streetnumberSuffixTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxAlphabeticalChars_KeyPress);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(497, 654);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(111, 35);
            this.saveButton.TabIndex = 23;
            this.saveButton.Text = "Opslaan";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(380, 654);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(111, 35);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // delete_Button
            // 
            this.delete_Button.Location = new System.Drawing.Point(12, 654);
            this.delete_Button.Name = "delete_Button";
            this.delete_Button.Size = new System.Drawing.Size(111, 35);
            this.delete_Button.TabIndex = 25;
            this.delete_Button.Text = "Verwijderen";
            this.delete_Button.UseVisualStyleBackColor = true;
            this.delete_Button.Click += new System.EventHandler(this.delete_Button_Click);
            // 
            // EditReservationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 704);
            this.Controls.Add(this.delete_Button);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.streetnumberSuffixTextBox);
            this.Controls.Add(this.commentCheckBox);
            this.Controls.Add(this.paidCheckBox);
            this.Controls.Add(this.streetnumberTextBox);
            this.Controls.Add(this.streetnameTextBox);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.kilometersTextbox);
            this.Controls.Add(this.confirmedCheckBox);
            this.Controls.Add(this.endDateTextBox);
            this.Controls.Add(this.startDateTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(642, 760);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(642, 760);
            this.Name = "EditReservationWindow";
            this.Text = "Reservering aanpassen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox startDateTextBox;
        private System.Windows.Forms.TextBox endDateTextBox;
        private System.Windows.Forms.CheckBox confirmedCheckBox;
        private System.Windows.Forms.TextBox kilometersTextbox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox streetnameTextBox;
        private System.Windows.Forms.TextBox streetnumberTextBox;
        private System.Windows.Forms.CheckBox paidCheckBox;
        private System.Windows.Forms.RichTextBox commentCheckBox;
        private System.Windows.Forms.TextBox streetnumberSuffixTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button delete_Button;
    }
}