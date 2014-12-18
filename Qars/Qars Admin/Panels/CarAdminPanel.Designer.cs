namespace Qars_Admin {
    partial class CarAdminPanel {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.CarDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.CarDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CarDataGrid
            // 
            this.CarDataGrid.AllowUserToAddRows = false;
            this.CarDataGrid.AllowUserToDeleteRows = false;
            this.CarDataGrid.AllowUserToResizeColumns = false;
            this.CarDataGrid.AllowUserToResizeRows = false;
            this.CarDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CarDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CarDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.CarDataGrid.Location = new System.Drawing.Point(0, 0);
            this.CarDataGrid.MultiSelect = false;
            this.CarDataGrid.Name = "CarDataGrid";
            this.CarDataGrid.ReadOnly = true;
            this.CarDataGrid.RowHeadersVisible = false;
            this.CarDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.CarDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CarDataGrid.Size = new System.Drawing.Size(768, 550);
            this.CarDataGrid.TabIndex = 0;
            this.CarDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // CarAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CarDataGrid);
            this.Name = "CarAdminPanel";
            this.Size = new System.Drawing.Size(768, 550);
            ((System.ComponentModel.ISupportInitialize)(this.CarDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CarDataGrid;
    }
}
