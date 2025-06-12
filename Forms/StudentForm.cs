using System;
using System.Windows.Forms;
using StudentGradeApp.Models;

namespace StudentGradeApp.Forms
{
    public partial class StudentForm : Form
    {
        // Proprietate publică ce va fi citită de MainForm după închiderea formularului cu OK
        public Student Student { get; private set; }

        /// <summary>
        /// Constructor pentru adăugare sau editare student.
        /// Dacă este primit un student, se face o clonă a acestuia.
        /// Dacă nu, se creează un student nou.
        /// </summary>
        /// <param name="student">Studentul existent pentru editare sau null pentru adăugare</param>
        public StudentForm(Student student)
        {
            InitializeComponent();

            // Dacă primim un student, îl copiem (nu referință directă)
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
                // Student nou, ID 0 inițial
                Student = new Student { Id = 0 };
            }

            // Populează câmpurile formularului cu valorile din student
            txtNume.Text = Student.Nume;
            txtPrenume.Text = Student.Prenume;
            txtEmail.Text = Student.Email;
            txtGrupa.Text = Student.Grupa;

            // Asociază evenimentele pentru butoane
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Eveniment declanșat la apăsarea butonului "Save".
        /// Validează și salvează datele introduse în formular.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validare simplă: câmpul Nume nu trebuie să fie gol
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                MessageBox.Show("Enter the name, please.");
                return;
            }

            // Copiază datele din controale în obiectul Student
            Student.Nume = txtNume.Text.Trim();
            Student.Prenume = txtPrenume.Text.Trim();
            Student.Email = txtEmail.Text.Trim();
            Student.Grupa = txtGrupa.Text.Trim();

            // === Generare ID automat ===
            // ID-ul este calculat ca produsul dintre lungimea numelui și a prenumelui,
            // apoi înmulțit cu 10 și se adaugă ultima cifră a secundei curente.
            int lenN = Student.Nume.Length;
            int lenP = Student.Prenume.Length;
            int baseValue = lenN * lenP;
            int suffix = DateTime.Now.Second % 10; // ultima cifră a secundei (0–9)
            Student.Id = baseValue * 10 + suffix;
            // Exemplu: Nume cu 5 litere și Prenume cu 7 → 5×7=35, 35×10=350, 350+4 = 354

            // Închide formularul cu rezultat OK
            DialogResult = DialogResult.OK;
        }
    }
}
