namespace StudentGradeApp.Forms
{
    partial class DisciplineSituationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbDisciplines;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView gridResults;
        private System.Windows.Forms.Label lblAverage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbDisciplines = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.gridResults = new System.Windows.Forms.DataGridView();
            this.lblAverage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridResults)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDisciplines
            // 
            this.cmbDisciplines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplines.FormattingEnabled = true;
            this.cmbDisciplines.Location = new System.Drawing.Point(20, 20);
            this.cmbDisciplines.Name = "cmbDisciplines";
            this.cmbDisciplines.Size = new System.Drawing.Size(200, 28);
            this.cmbDisciplines.TabIndex = 0;
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
            // gridResults
            // 
            this.gridResults.AllowUserToAddRows = false;
            this.gridResults.AllowUserToDeleteRows = false;
            this.gridResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridResults.BackgroundColor = System.Drawing.Color.Thistle;
            this.gridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResults.Location = new System.Drawing.Point(240, 20);
            this.gridResults.Name = "gridResults";
            this.gridResults.ReadOnly = true;
            this.gridResults.RowHeadersVisible = false;
            this.gridResults.RowHeadersWidth = 62;
            this.gridResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridResults.Size = new System.Drawing.Size(520, 300);
            this.gridResults.TabIndex = 2;
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAverage.Location = new System.Drawing.Point(240, 330);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(194, 28);
            this.lblAverage.TabIndex = 3;
            this.lblAverage.Text = "Media disciplinei:";
            // 
            // DisciplineSituationForm
            // 
            this.ClientSize = new System.Drawing.Size(780, 370);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.gridResults);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cmbDisciplines);
            this.Name = "DisciplineSituationForm";
            this.Text = "Situatie per Disciplină";
            ((System.ComponentModel.ISupportInitialize)(this.gridResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
