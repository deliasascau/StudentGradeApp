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
            this.lblId.Location = new System.Drawing.Point(61, 49);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(26, 20);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // numId
            // 
            this.numId.Location = new System.Drawing.Point(239, 43);
            this.numId.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(120, 26);
            this.numId.TabIndex = 1;
            this.numId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.Location = new System.Drawing.Point(61, 88);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(51, 20);
            this.lblNume.TabIndex = 2;
            this.lblNume.Text = "Nume";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(239, 82);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(250, 26);
            this.txtNume.TabIndex = 3;
            // 
            // lblAcronim
            // 
            this.lblAcronim.AutoSize = true;
            this.lblAcronim.Location = new System.Drawing.Point(61, 128);
            this.lblAcronim.Name = "lblAcronim";
            this.lblAcronim.Size = new System.Drawing.Size(71, 20);
            this.lblAcronim.TabIndex = 4;
            this.lblAcronim.Text = "Acronim";
            // 
            // txtAcronim
            // 
            this.txtAcronim.Location = new System.Drawing.Point(239, 122);
            this.txtAcronim.Name = "txtAcronim";
            this.txtAcronim.Size = new System.Drawing.Size(250, 26);
            this.txtAcronim.TabIndex = 5;
            // 
            // lblTipEvaluare
            // 
            this.lblTipEvaluare.AutoSize = true;
            this.lblTipEvaluare.Location = new System.Drawing.Point(61, 165);
            this.lblTipEvaluare.Name = "lblTipEvaluare";
            this.lblTipEvaluare.Size = new System.Drawing.Size(151, 20);
            this.lblTipEvaluare.TabIndex = 6;
            this.lblTipEvaluare.Text = "Tip de evaluare";
            // 
            // cmbTipEvaluare
            // 
            this.cmbTipEvaluare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipEvaluare.Location = new System.Drawing.Point(239, 162);
            this.cmbTipEvaluare.Name = "cmbTipEvaluare";
            this.cmbTipEvaluare.Size = new System.Drawing.Size(250, 28);
            this.cmbTipEvaluare.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(239, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(389, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // DisciplinaForm
            // 
            this.ClientSize = new System.Drawing.Size(554, 304);
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
            this.Text = "Cursuri";
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
