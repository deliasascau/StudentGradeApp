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
            // 
            // cmbStudents
            // 
            this.cmbStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudents.Location = new System.Drawing.Point(180, 16);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(250, 28);
            this.cmbStudents.TabIndex = 1;
            // 
            // progressBarAverage
            // 
            this.progressBarAverage.Location = new System.Drawing.Point(20, 65);
            this.progressBarAverage.Name = "progressBarAverage";
            this.progressBarAverage.Size = new System.Drawing.Size(410, 30);
            this.progressBarAverage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarAverage.TabIndex = 2;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValue.Location = new System.Drawing.Point(20, 105);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(119, 32);
            this.lblValue.TabIndex = 3;
            this.lblValue.Text = "Media: --";
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(20, 20);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(147, 20);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "Selectează student";
            // 
            // AverageForm
            // 
            this.ClientSize = new System.Drawing.Size(460, 160);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.progressBarAverage);
            this.Controls.Add(this.lblValue);
            this.Name = "AverageForm";
            this.Text = "Media generală";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
    }
}