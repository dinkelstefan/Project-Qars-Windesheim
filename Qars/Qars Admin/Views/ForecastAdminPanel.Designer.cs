namespace Qars_Admin.Views
{
    partial class ForecastAdminPanel
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
            this.update_Button = new System.Windows.Forms.Button();
            this.ForecastDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ForecastDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // update_Button
            // 
            this.update_Button.Location = new System.Drawing.Point(302, 741);
            this.update_Button.Name = "update_Button";
            this.update_Button.Size = new System.Drawing.Size(554, 35);
            this.update_Button.TabIndex = 0;
            this.update_Button.Text = "Bijwerken";
            this.update_Button.UseVisualStyleBackColor = true;
            this.update_Button.Click += new System.EventHandler(this.update_Button_Click);
            // 
            // ForecastDataGridView
            // 
            this.ForecastDataGridView.AllowUserToAddRows = false;
            this.ForecastDataGridView.AllowUserToDeleteRows = false;
            this.ForecastDataGridView.AllowUserToResizeColumns = false;
            this.ForecastDataGridView.AllowUserToResizeRows = false;
            this.ForecastDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ForecastDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ForecastDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ForecastDataGridView.MultiSelect = false;
            this.ForecastDataGridView.Name = "ForecastDataGridView";
            this.ForecastDataGridView.ReadOnly = true;
            this.ForecastDataGridView.RowHeadersVisible = false;
            this.ForecastDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.ForecastDataGridView.RowTemplate.Height = 28;
            this.ForecastDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ForecastDataGridView.ShowCellErrors = false;
            this.ForecastDataGridView.ShowEditingIcon = false;
            this.ForecastDataGridView.ShowRowErrors = false;
            this.ForecastDataGridView.Size = new System.Drawing.Size(1152, 735);
            this.ForecastDataGridView.StandardTab = true;
            this.ForecastDataGridView.TabIndex = 1;
            // 
            // ForecastAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ForecastDataGridView);
            this.Controls.Add(this.update_Button);
            this.Name = "ForecastAdminPanel";
            this.Size = new System.Drawing.Size(1152, 787);
            ((System.ComponentModel.ISupportInitialize)(this.ForecastDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button update_Button;
        private System.Windows.Forms.DataGridView ForecastDataGridView;

    }
}
