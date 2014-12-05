namespace Qars.Views
{
    partial class searchWizard
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
            this.searchWizardTabControl = new System.Windows.Forms.TabControl();
            this.searchTabpage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.searchWizardTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchWizardTabControl
            // 
            this.searchWizardTabControl.Controls.Add(this.searchTabpage);
            this.searchWizardTabControl.Controls.Add(this.tabPage2);
            this.searchWizardTabControl.Location = new System.Drawing.Point(3, 3);
            this.searchWizardTabControl.Name = "searchWizardTabControl";
            this.searchWizardTabControl.SelectedIndex = 0;
            this.searchWizardTabControl.Size = new System.Drawing.Size(1559, 867);
            this.searchWizardTabControl.TabIndex = 0;
            // 
            // searchTabpage
            // 
            this.searchTabpage.Location = new System.Drawing.Point(4, 29);
            this.searchTabpage.Name = "searchTabpage";
            this.searchTabpage.Padding = new System.Windows.Forms.Padding(3);
            this.searchTabpage.Size = new System.Drawing.Size(1551, 834);
            this.searchTabpage.TabIndex = 0;
            this.searchTabpage.Text = "Vraag 1";
            this.searchTabpage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1551, 834);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // searchWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchWizardTabControl);
            this.Name = "searchWizard";
            this.Size = new System.Drawing.Size(1565, 873);
            this.searchWizardTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl searchWizardTabControl;
        private System.Windows.Forms.TabPage searchTabpage;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
