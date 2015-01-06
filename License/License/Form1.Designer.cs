namespace License
{
    partial class license
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
            this.close = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.lastEdited = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.userView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(664, 440);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 0;
            this.close.Text = "sluiten";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(562, 440);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(96, 23);
            this.edit.TabIndex = 1;
            this.edit.Text = "bewerken";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // lastEdited
            // 
            this.lastEdited.AutoSize = true;
            this.lastEdited.Location = new System.Drawing.Point(32, 416);
            this.lastEdited.Name = "lastEdited";
            this.lastEdited.Size = new System.Drawing.Size(104, 17);
            this.lastEdited.TabIndex = 3;
            this.lastEdited.Text = "Laatst bewerkt:";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(31, 433);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(57, 17);
            this.date.TabIndex = 5;
            this.date.Text = "{datum}";
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(366, 416);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(99, 40);
            this.delete.TabIndex = 6;
            this.delete.Text = "verwijderen";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Visible = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(471, 416);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(85, 40);
            this.save.TabIndex = 10;
            this.save.Text = "opslaan";
            this.save.UseVisualStyleBackColor = true;
            this.save.Visible = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(34, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(705, 368);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // userView
            // 
            this.userView.Location = new System.Drawing.Point(562, 403);
            this.userView.Name = "userView";
            this.userView.Size = new System.Drawing.Size(177, 31);
            this.userView.TabIndex = 12;
            this.userView.Text = "kijk van gebruiker";
            this.userView.UseVisualStyleBackColor = true;
            this.userView.Visible = false;
            this.userView.Click += new System.EventHandler(this.userView_Click);
            // 
            // license
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 475);
            this.Controls.Add(this.userView);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.date);
            this.Controls.Add(this.lastEdited);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.close);
            this.MaximizeBox = false;
            this.Name = "license";
            this.Text = "De algemene voorwaarden";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Label lastEdited;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button userView;
    }
}

