namespace StudentGradeApp.Forms
{
    partial class StudentSituationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView gridNotes;
        private System.Windows.Forms.Label lblAverage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.gridNotes = new System.Windows.Forms.DataGridView();
            this.lblAverage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbStudents
            // 
            this.cmbStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudents.Location = new System.Drawing.Point(20, 20);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(220, 28);
            this.cmbStudents.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.GreenYellow;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShow.Location = new System.Drawing.Point(20, 60);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(120, 40);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Detalii";
            this.btnShow.UseVisualStyleBackColor = false;
            // 
            // gridNotes
            // 
            this.gridNotes.AllowUserToAddRows = false;
            this.gridNotes.AllowUserToDeleteRows = false;
            this.gridNotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridNotes.BackgroundColor = System.Drawing.Color.Thistle;
            this.gridNotes.ColumnHeadersHeight = 34;
            this.gridNotes.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridNotes.Location = new System.Drawing.Point(260, 20);
            this.gridNotes.Name = "gridNotes";
            this.gridNotes.ReadOnly = true;
            this.gridNotes.RowHeadersWidth = 62;
            this.gridNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridNotes.Size = new System.Drawing.Size(600, 360);
            this.gridNotes.TabIndex = 2;
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(260, 390);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(147, 20);
            this.lblAverage.TabIndex = 3;
            this.lblAverage.Text = "Media generală: --";
            // 
            // StudentSituationForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 430);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.gridNotes);
            this.Controls.Add(this.lblAverage);
            this.Name = "StudentSituationForm";
            this.Text = "Situație Student";
            ((System.ComponentModel.ISupportInitialize)(this.gridNotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
