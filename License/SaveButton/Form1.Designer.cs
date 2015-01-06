namespace SaveButton
{
    partial class saveForm
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.yes = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.Button();
            this.saveNclose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(208, 141);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "niet weer vragen";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // yes
            // 
            this.yes.Location = new System.Drawing.Point(23, 77);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(83, 58);
            this.yes.TabIndex = 1;
            this.yes.Text = "ja";
            this.yes.UseVisualStyleBackColor = true;
            // 
            // no
            // 
            this.no.Location = new System.Drawing.Point(127, 77);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(83, 58);
            this.no.TabIndex = 2;
            this.no.Text = "nee";
            this.no.UseVisualStyleBackColor = true;
            // 
            // saveNclose
            // 
            this.saveNclose.Location = new System.Drawing.Point(233, 77);
            this.saveNclose.Name = "saveNclose";
            this.saveNclose.Size = new System.Drawing.Size(110, 58);
            this.saveNclose.TabIndex = 3;
            this.saveNclose.Text = "opslaan en sluiten";
            this.saveNclose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Weet u zeker dat u wilt opslaan?";
            // 
            // saveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 174);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveNclose);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.checkBox1);
            this.Name = "saveForm";
            this.Text = "Opslaan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Button no;
        private System.Windows.Forms.Button saveNclose;
        private System.Windows.Forms.Label label1;
    }
}

