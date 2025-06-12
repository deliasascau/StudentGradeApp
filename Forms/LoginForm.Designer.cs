using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StudentGradeApp.Forms
{
    partial class LoginForm
    {
        // —–––– FIELD-URI ACCESIBILE DIN CEALALTĂ PARTE —––––
        private IContainer components = null;
        private PictureBox pbUniversity = null;
        private PictureBox pbFaculty = null;
        private PictureBox pbPhoto = null;
        private TextBox txtUsername = null;
        private TextBox txtPassword = null;
        private Button btnLogin = null;
        private TableLayoutPanel tlpFields = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) 
                components.Dispose();
            base.Dispose(disposing);
        }

        // —–––– CONSTRUCȚIA INTERFEȚEI —––––
        private void InitializeComponent()
        {
            components = new Container();

            // ———————— FORM ————————
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 550);
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Login";

            // ———————— TABLELAYOUT PRINCIPAL ————————
            var tlpMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.White
            };
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));       // logos
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));       // foto
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));  // fields

            // ———————— LOGO-URI (FLOWLAYOUT CENTRAT) ————————
            var flowLogos = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Anchor = AnchorStyles.None,
                Padding = new Padding(0, 15, 0, 15),
                BackColor = Color.White
            };

            pbUniversity = new PictureBox
            {
                Height = 80,
                Width = 80,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            pbFaculty = new PictureBox
            {
                Height = 80,
                Width = 120,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            flowLogos.Controls.AddRange(new Control[] { pbUniversity, pbFaculty });

            // ———————— FOTOGRAFIA ————————
            pbPhoto = new PictureBox
            {
                Dock = DockStyle.Fill,
                Height = 240,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(30, 0, 30, 20),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // ———————— TLP FIELDS (USERNAME / PASSWORD / BUTTON) ————————
            tlpFields = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 3,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Anchor = AnchorStyles.None,
                Padding = new Padding(10, 20, 10, 20)
            };
            tlpFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
            tlpFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70f));
            tlpFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            tlpFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            tlpFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));

            // Labels + TextBox-uri
            var lblUsername = new Label
            {
                Text = "Username:",
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10f)
            };
            txtUsername = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10f)
            };

            var lblPassword = new Label
            {
                Text = "Password:",
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10f)
            };
            txtPassword = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10f),
                UseSystemPasswordChar = true
            };

            btnLogin = new Button
            {
                Text = "Log In",
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Height = 40,
                Width = 120,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0, 15, 0, 0)
            };
            btnLogin.FlatAppearance.BorderSize = 0;

            // punem controalele în tlpFields
            tlpFields.Controls.Add(lblUsername, 0, 0);
            tlpFields.Controls.Add(txtUsername, 1, 0);
            tlpFields.Controls.Add(lblPassword, 0, 1);
            tlpFields.Controls.Add(txtPassword, 1, 1);
            tlpFields.Controls.Add(btnLogin, 1, 2);

            // ———————— ASAMBLARE FINALA ————————
            tlpMain.Controls.Add(flowLogos, 0, 0);
            tlpMain.Controls.Add(pbPhoto, 0, 1);
            tlpMain.Controls.Add(tlpFields, 0, 2);

            Controls.Add(tlpMain);
        }
    }
}
