namespace StudentGradeApp.Forms
{
    partial class NotaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.NumericUpDown numNota;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.numNota = new System.Windows.Forms.NumericUpDown();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numNota)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new System.Drawing.Point(30, 30);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(60, 20);
            this.lblStudent.Text = "Student";
            // 
            // cmbStudent
            // 
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Location = new System.Drawing.Point(150, 27);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(300, 28);
            // 
            // lblDisciplina
            // 
            this.lblDisciplina.AutoSize = true;
            this.lblDisciplina.Location = new System.Drawing.Point(30, 75);
            this.lblDisciplina.Name = "lblDisciplina";
            this.lblDisciplina.Size = new System.Drawing.Size(75, 20);
            this.lblDisciplina.Text = "Disciplina";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplina.Location = new System.Drawing.Point(150, 72);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(300, 28);
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(30, 120);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(39, 20);
            this.lblNota.Text = "Nota";
            // 
            // numNota
            // 
            this.numNota.Location = new System.Drawing.Point(150, 118);
            this.numNota.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numNota.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numNota.Name = "numNota";
            this.numNota.Size = new System.Drawing.Size(120, 26);
            this.numNota.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(30, 165);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(36, 20);
            this.lblData.Text = "Data";
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(150, 162);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(150, 26);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(300, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // NotaForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 270);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.cmbStudent);
            this.Controls.Add(this.lblDisciplina);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.numNota);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "NotaForm";
            this.Text = "Nota";
            ((System.ComponentModel.ISupportInitialize)(this.numNota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
