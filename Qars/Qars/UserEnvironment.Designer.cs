namespace Qars
{
    partial class UserEnvironment
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
            this.button1 = new System.Windows.Forms.Button();
            this.ReservationsLabel = new System.Windows.Forms.Label();
            this.PersonalInfoLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(948, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sluiten";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReservationsLabel
            // 
            this.ReservationsLabel.AutoSize = true;
            this.ReservationsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReservationsLabel.Location = new System.Drawing.Point(637, 34);
            this.ReservationsLabel.Name = "ReservationsLabel";
            this.ReservationsLabel.Size = new System.Drawing.Size(180, 25);
            this.ReservationsLabel.TabIndex = 3;
            this.ReservationsLabel.Text = "Uw reserveringen";
            // 
            // PersonalInfoLabel
            // 
            this.PersonalInfoLabel.AutoSize = true;
            this.PersonalInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonalInfoLabel.Location = new System.Drawing.Point(27, 34);
            this.PersonalInfoLabel.Name = "PersonalInfoLabel";
            this.PersonalInfoLabel.Size = new System.Drawing.Size(264, 25);
            this.PersonalInfoLabel.TabIndex = 4;
            this.PersonalInfoLabel.Text = "Uw persoonlijke gegevens";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(481, 198);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(376, 97);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // UserEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.PersonalInfoLabel);
            this.Controls.Add(this.ReservationsLabel);
            this.Controls.Add(this.button1);
            this.Name = "UserEnvironment";
            this.Size = new System.Drawing.Size(1047, 552);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ReservationsLabel;
        private System.Windows.Forms.Label PersonalInfoLabel;
        private System.Windows.Forms.ListView listView1;
    }
}
