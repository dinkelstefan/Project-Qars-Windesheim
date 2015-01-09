namespace Qars_Admin.Panels
{
    partial class ToSAdminPanel
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
            this.ToSTextBox = new System.Windows.Forms.RichTextBox();
            this.save_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ToSDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ToSTextBox
            // 
            this.ToSTextBox.Location = new System.Drawing.Point(0, 0);
            this.ToSTextBox.Name = "ToSTextBox";
            this.ToSTextBox.Size = new System.Drawing.Size(1149, 650);
            this.ToSTextBox.TabIndex = 0;
            this.ToSTextBox.Text = "";
            // 
            // save_Button
            // 
            this.save_Button.Location = new System.Drawing.Point(1040, 678);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(100, 32);
            this.save_Button.TabIndex = 1;
            this.save_Button.Text = "Opslaan";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 684);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Laatst bijgewerkt op:";
            // 
            // ToSDate
            // 
            this.ToSDate.AutoSize = true;
            this.ToSDate.Location = new System.Drawing.Point(3, 711);
            this.ToSDate.Name = "ToSDate";
            this.ToSDate.Size = new System.Drawing.Size(64, 20);
            this.ToSDate.TabIndex = 3;
            this.ToSDate.Text = "{datum}";
            // 
            // ToSAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToSDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.ToSTextBox);
            this.Name = "ToSAdminPanel";
            this.Size = new System.Drawing.Size(1152, 750);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ToSTextBox;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ToSDate;
    }
}
