namespace StudentGradeApp.Forms
{
    partial class DisciplinaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.NumericUpDown numId;
        private System.Windows.Forms.Label lblNume;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.Label lblAcronim;
        private System.Windows.Forms.TextBox txtAcronim;
        private System.Windows.Forms.Label lblTipEvaluare;
        private System.Windows.Forms.ComboBox cmbTipEvaluare;
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
            this.lblId = new System.Windows.Forms.Label();
            this.numId = new System.Windows.Forms.NumericUpDown();
            this.lblNume = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.lblAcronim = new System.Windows.Forms.Label();
            this.txtAcronim = new System.Windows.Forms.TextBox();
            this.lblTipEvaluare = new System.Windows.Forms.Label();
            this.cmbTipEvaluare = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(30, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(22, 20);
            this.lblId.Text = "ID";
            // 
            // numId
            // 
            this.numId.Location = new System.Drawing.Point(150, 18);
            this.numId.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numId.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(120, 26);
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.Location = new System.Drawing.Point(30, 60);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(45, 20);
            this.lblNume.Text = "Nume";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(150, 57);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(250, 26);
            // 
            // lblAcronim
            // 
            this.lblAcronim.AutoSize = true;
            this.lblAcronim.Location = new System.Drawing.Point(30, 100);
            this.lblAcronim.Name = "lblAcronim";
            this.lblAcronim.Size = new System.Drawing.Size(63, 20);
            this.lblAcronim.Text = "Acronim";
            // 
            // txtAcronim
            // 
            this.txtAcronim.Location = new System.Drawing.Point(150, 97);
            this.txtAcronim.Name = "txtAcronim";
            this.txtAcronim.Size = new System.Drawing.Size(250, 26);
            // 
            // lblTipEvaluare
            // 
            this.lblTipEvaluare.AutoSize = true;
            this.lblTipEvaluare.Location = new System.Drawing.Point(30, 140);
            this.lblTipEvaluare.Name = "lblTipEvaluare";
            this.lblTipEvaluare.Size = new System.Drawing.Size(95, 20);
            this.lblTipEvaluare.Text = "Tip Evaluare";
            // 
            // cmbTipEvaluare
            // 
            this.cmbTipEvaluare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipEvaluare.Location = new System.Drawing.Point(150, 137);
            this.cmbTipEvaluare.Name = "cmbTipEvaluare";
            this.cmbTipEvaluare.Size = new System.Drawing.Size(250, 28);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(300, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DisciplinaForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.numId);
            this.Controls.Add(this.lblNume);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.lblAcronim);
            this.Controls.Add(this.txtAcronim);
            this.Controls.Add(this.lblTipEvaluare);
            this.Controls.Add(this.cmbTipEvaluare);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "DisciplinaForm";
            this.Text = "Disciplina";
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
