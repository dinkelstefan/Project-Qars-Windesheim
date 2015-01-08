namespace Qars
{
    partial class VisualDemo
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LogInOrRegisterButton = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.WelcomeInfoLabel = new System.Windows.Forms.Label();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TileView = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TileView.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 644);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Vergelijk";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1265, 71);
            this.panel1.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(1120, -2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 73);
            this.label14.TabIndex = 2;
            this.label14.Text = "Q";
            this.label14.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(525, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 73);
            this.label13.TabIndex = 1;
            this.label13.Text = "Qars";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(-2, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(221, 73);
            this.label12.TabIndex = 0;
            this.label12.Text = "Quintor";
            // 
            // LogInOrRegisterButton
            // 
            this.LogInOrRegisterButton.Location = new System.Drawing.Point(881, 54);
            this.LogInOrRegisterButton.Name = "LogInOrRegisterButton";
            this.LogInOrRegisterButton.Size = new System.Drawing.Size(116, 63);
            this.LogInOrRegisterButton.TabIndex = 15;
            this.LogInOrRegisterButton.Text = "Log In/Registreer";
            this.LogInOrRegisterButton.UseVisualStyleBackColor = true;
            this.LogInOrRegisterButton.Click += new System.EventHandler(this.LogInOrRegisterButton_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel8.Controls.Add(this.LogOutButton);
            this.panel8.Controls.Add(this.LogInOrRegisterButton);
            this.panel8.Controls.Add(this.WelcomeInfoLabel);
            this.panel8.Controls.Add(this.WelcomeLabel);
            this.panel8.Location = new System.Drawing.Point(-1, -1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1025, 182);
            this.panel8.TabIndex = 10;
            // 
            // LogOutButton
            // 
            this.LogOutButton.Enabled = false;
            this.LogOutButton.Location = new System.Drawing.Point(881, 54);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(116, 63);
            this.LogOutButton.TabIndex = 20;
            this.LogOutButton.Text = "Log uit";
            this.LogOutButton.UseVisualStyleBackColor = true;
            this.LogOutButton.Visible = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // WelcomeInfoLabel
            // 
            this.WelcomeInfoLabel.AutoSize = true;
            this.WelcomeInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.WelcomeInfoLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeInfoLabel.ForeColor = System.Drawing.Color.White;
            this.WelcomeInfoLabel.Location = new System.Drawing.Point(28, 86);
            this.WelcomeInfoLabel.Name = "WelcomeInfoLabel";
            this.WelcomeInfoLabel.Size = new System.Drawing.Size(351, 57);
            this.WelcomeInfoLabel.TabIndex = 6;
            this.WelcomeInfoLabel.Text = "U maakt momenteel gebruik van de Qars applicatie! \r\nOm optimaal gebruik te maken " +
    "van deze applicatie \r\nkunt u zich registreren en inloggen";
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.WelcomeLabel.Font = new System.Drawing.Font("Calibri", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.ForeColor = System.Drawing.Color.White;
            this.WelcomeLabel.Location = new System.Drawing.Point(18, 4);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(280, 82);
            this.WelcomeLabel.TabIndex = 1;
            this.WelcomeLabel.Text = "Welkom!";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 62);
            this.panel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vestigingen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 649);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 11;
            // 
            // TileView
            // 
            this.TileView.AutoScroll = true;
            this.TileView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TileView.Controls.Add(this.panel8);
            this.TileView.Location = new System.Drawing.Point(250, 70);
            this.TileView.Name = "TileView";
            this.TileView.Size = new System.Drawing.Size(1015, 568);
            this.TileView.TabIndex = 12;
            this.TileView.Paint += new System.Windows.Forms.PaintEventHandler(this.TileView_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1191, 648);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 20);
            this.button2.TabIndex = 14;
            this.button2.Text = "Toon alles";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.showAllCars);
            // 
            // VisualDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1265, 672);
            this.Controls.Add(this.TileView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VisualDemo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qars";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TileView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label WelcomeInfoLabel;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel TileView;
        private Views.searchWizard searchWizard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LogInOrRegisterButton;
        private System.Windows.Forms.Button LogOutButton;
        public System.Windows.Forms.Button button2;

    }
}

