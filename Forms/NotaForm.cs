using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Models;
using StudentGradeApp.Services;

namespace StudentGradeApp.Forms
{
    public partial class NotaForm : Form
    {
        private readonly IDataService _dataService; // Acces la date
        public Nota Nota { get; private set; }      // Nota editată sau adăugată

        /// <summary>
        /// Constructor pentru adăugare sau editare notă.
        /// Primește o notă existentă sau null pentru adăugare nouă.
        /// </summary>
        public NotaForm(Nota nota)
        {
            InitializeComponent();

            _dataService = new JsonDataService();

            // === Clonare notă existentă sau creare nouă ===
            if (nota != null)
            {
                Nota = new Nota
                {
                    Id = nota.Id, // se păstrează Id compus
                    StudentId = nota.StudentId,
                    DisciplinaId = nota.DisciplinaId,
                    Valoare = nota.Valoare,
                    DataNota = nota.DataNota
                };
            }
            else
            {
                Nota = new Nota
                {
                    StudentId = 0,
                    DisciplinaId = 0,
                    Valoare = 5,                // Valoare implicită
                    DataNota = DateTime.Now     // Data curentă
                };
            }

            // === Populare combo box-uri ===

            var studs = new List<Student>(_dataService.GetAllStudents());
            cmbStudent.DataSource = studs;
            cmbStudent.DisplayMember = "Nume_Complet"; // presupune proprietate calculată

            var disci = new List<Disciplina>(_dataService.GetAllDiscipline());
            cmbDisciplina.DataSource = disci;
            cmbDisciplina.DisplayMember = "Nume";

            // === Dacă se editează, selectează valorile curente ===
            if (nota != null)
            {
                cmbStudent.SelectedItem = studs.FirstOrDefault(s => s.Id == nota.StudentId);
                cmbDisciplina.SelectedItem = disci.FirstOrDefault(d => d.Id == nota.DisciplinaId);
                numNota.Value = nota.Valoare;
                dtpData.Value = nota.DataNota;
            }

            // Legare evenimente butoane
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Salvează nota dacă selecțiile sunt valide.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Obține studentul și disciplina selectate
            var selStud = (Student)cmbStudent.SelectedItem;
            var selDisc = (Disciplina)cmbDisciplina.SelectedItem;

            if (selStud == null || selDisc == null)
            {
                MessageBox.Show("You need to select both student and course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Actualizare obiect Nota cu valorile din UI
            Nota.StudentId = selStud.Id;
            Nota.DisciplinaId = selDisc.Id;
            Nota.Valoare = (int)numNota.Value;
            Nota.DataNota = dtpData.Value;

            // === Generare Id compus ===
            // Atenție: acest mod presupune că nu există coliziuni între ID-uri
            Nota.Id = selStud.Id + selDisc.Id;

            // Închide formularul cu rezultat OK
            DialogResult = DialogResult.OK;
        }
    }
}
