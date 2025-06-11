using System.Windows.Forms;

namespace StudentGradeApp.Forms
{
    partial class AverageForm
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
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.ProgressBar progressBarAverage;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblSelect;

        private void InitializeComponent()
        {
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.progressBarAverage = new System.Windows.Forms.ProgressBar();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // lblSelect
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(20, 20);
            this.lblSelect.Text = "Selectează student:";

            // cmbStudents
            this.cmbStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStudents.Location = new System.Drawing.Point(180, 16);
            this.cmbStudents.Size = new System.Drawing.Size(250, 28);

            // progressBarAverage
            this.progressBarAverage.Location = new System.Drawing.Point(20, 65);
            this.progressBarAverage.Size = new System.Drawing.Size(410, 30);
            this.progressBarAverage.Maximum = 100;
            this.progressBarAverage.Style = ProgressBarStyle.Continuous;

            // lblValue
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValue.Location = new System.Drawing.Point(20, 105);
            this.lblValue.Text = "Media: --";

            // AverageForm
            this.ClientSize = new System.Drawing.Size(460, 160);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.progressBarAverage);
            this.Controls.Add(this.lblValue);
            this.Text = "Media studentului";
            this.ResumeLayout(false);
            this.PerformLayout();
        }



        #endregion
    }
}