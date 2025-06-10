using System;
using System.Windows.Forms;
using StudentGradeApp.Models;

namespace StudentGradeApp.Forms
{
    public partial class StudentForm : Form
    {
        // Proprietate pe care MainForm o citeşte la OK
        public Student Student { get; private set; }

        // Constructor Add sau Edit
        public StudentForm(Student student)
        {
            InitializeComponent();

            // Clone sau creează un nou obiect
            if (student != null)
            {
                Student = new Student
                {
                    Id = student.Id,
                    Nume = student.Nume,
                    Prenume = student.Prenume,
                    Email = student.Email,
                    Grupa = student.Grupa
                };
            }
            else
            {
                Student = new Student { Id = 0 };
            }

            // Populează controalele
            txtNume.Text = Student.Nume;
            txtPrenume.Text = Student.Prenume;
            txtEmail.Text = Student.Email;
            txtGrupa.Text = Student.Grupa;

            // Wire butoanele
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validări simple
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                MessageBox.Show("Introdu numele.");
                return;
            }

            // Copiază din controale în obiect
            Student.Nume = txtNume.Text.Trim();
            Student.Prenume = txtPrenume.Text.Trim();
            Student.Email = txtEmail.Text.Trim();
            Student.Grupa = txtGrupa.Text.Trim();

            // === generate int Id ===
            int lenN = Student.Nume.Length;
            int lenP = Student.Prenume.Length;
            int baseValue = lenN * lenP;
            // one-digit suffix: last digit of current second (0–9)
            int suffix = DateTime.Now.Second % 10;
            Student.Id = baseValue * 10 + suffix;
            //                                     ^ so "35"→"350" + suffix→"354"


            // Semnal OK
            DialogResult = DialogResult.OK;
        }

    }
}
