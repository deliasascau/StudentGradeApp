using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StudentGradeApp.Forms
{
    public partial class LoginForm : Form
    {
        private const string AdminUser = "admin";
        private const string AdminPass = "secret";

        public LoginForm()
        {
            InitializeComponent();      // designer-generated UI  
            LoadLogosAndPhoto();        // încarcă imaginile  

            // eveniment click pe buton  
            btnLogin.Click += BtnLogin_Click;
        }

        // -------------------------------------------------------------  
        //  LOGICA AUTENTIFICĂRII  
        // -------------------------------------------------------------  
        private void BtnLogin_Click(object sender, EventArgs e) // Removed nullable reference type  
        {
            var u = txtUsername.Text.Trim();
            var p = txtPassword.Text;

            if (u.Equals(AdminUser, StringComparison.OrdinalIgnoreCase) &&
                p == AdminPass)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // -------------------------------------------------------------  
        //  ÎNCARCĂ LOGO-URI + FOTOGRAFIE  
        // -------------------------------------------------------------  
        private void LoadLogosAndPhoto()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var assetsDir = Path.Combine(baseDir, "Assets");

            var uniPath = Path.Combine(assetsDir, "university.png");
            var facPath = Path.Combine(assetsDir, "faculty.png");
            var photoPath = Path.Combine(assetsDir, "photo.png");

            if (File.Exists(uniPath)) pbUniversity.Image = Image.FromFile(uniPath);
            if (File.Exists(facPath)) pbFaculty.Image = Image.FromFile(facPath);
            if (File.Exists(photoPath)) pbPhoto.Image = Image.FromFile(photoPath);

            pbUniversity.SizeMode = PictureBoxSizeMode.Zoom;
            pbFaculty.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
