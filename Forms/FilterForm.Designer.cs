using System.Windows.Forms;

namespace StudentGradeApp.Forms
{
    partial class FilterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.RadioButton rdoStudent;
        private System.Windows.Forms.RadioButton rdoDisciplina;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgvResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.rdoStudent    = new System.Windows.Forms.RadioButton();
            this.rdoDisciplina = new System.Windows.Forms.RadioButton();
            this.cmbFilter     = new System.Windows.Forms.ComboBox();
            this.btnFilter     = new System.Windows.Forms.Button();
            this.dgvResults    = new System.Windows.Forms.DataGridView();
            this.groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.rdoStudent);
            this.groupBoxFilter.Controls.Add(this.rdoDisciplina);
            this.groupBoxFilter.Controls.Add(this.cmbFilter);
            this.groupBoxFilter.Controls.Add(this.btnFilter);
            this.groupBoxFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFilter.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(700, 70);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filtrare note";
            // 
            // rdoStudent
            // 
            this.rdoStudent.AutoSize = true;
            this.rdoStudent.Location = new System.Drawing.Point(15, 30);
            this.rdoStudent.Name = "rdoStudent";
            this.rdoStudent.Size = new System.Drawing.Size(95, 21);
            this.rdoStudent.TabIndex = 0;
            this.rdoStudent.TabStop = true;
            this.rdoStudent.Text = "By Student";
            this.rdoStudent.UseVisualStyleBackColor = true;
            // 
            // rdoDisciplina
            // 
            this.rdoDisciplina.AutoSize = true;
            this.rdoDisciplina.Location = new System.Drawing.Point(125, 30);
            this.rdoDisciplina.Name = "rdoDisciplina";
            this.rdoDisciplina.Size = new System.Drawing.Size(109, 21);
            this.rdoDisciplina.TabIndex = 1;
            this.rdoDisciplina.TabStop = true;
            this.rdoDisciplina.Text = "By Discipline";
            this.rdoDisciplina.UseVisualStyleBackColor = true;
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Location = new System.Drawing.Point(245, 27);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(250, 24);
            this.cmbFilter.TabIndex = 2;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(515, 25);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 27);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filtrează";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows    = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock   = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 70);
            this.dgvResults.Name     = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.TabIndex = 1;
            // 
            // FilterForm
            // 
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.groupBoxFilter);
            this.Name = "FilterForm";
            this.Text = "Filtrare Note";
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

