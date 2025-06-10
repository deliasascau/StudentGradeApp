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
        private readonly IDataService _dataService;
        public Nota Nota { get; private set; }

        public NotaForm(Nota nota)
        {
            InitializeComponent();

            _dataService = new JsonDataService();


            // Clone or new
            if (nota != null)
            {
                Nota = new Nota
                {
                    // preserve existing composite Id
                    Id = nota.Id,
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
                    // Id will be set on Save
                    StudentId = 0,
                    DisciplinaId = 0,
                    Valoare = 5,
                    DataNota = DateTime.Now
                };
            }

            // Populate combo boxes
            var studs = new List<Student>(_dataService.GetAllStudents());
            cmbStudent.DataSource = studs;
            cmbStudent.DisplayMember = "Nume";

            var disci = new List<Disciplina>(_dataService.GetAllDiscipline());
            cmbDisciplina.DataSource = disci;
            cmbDisciplina.DisplayMember = "Nume";

            // If editing, select current values
            if (nota != null)
            {
                cmbStudent.SelectedItem = studs.FirstOrDefault(s => s.Id == nota.StudentId);
                cmbDisciplina.SelectedItem = disci.FirstOrDefault(d => d.Id == nota.DisciplinaId);
                numNota.Value = nota.Valoare;
                dtpData.Value = nota.DataNota;
            }

            // Wire buttons
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Read selected student & discipline
            var selStud = (Student)cmbStudent.SelectedItem;
            var selDisc = (Disciplina)cmbDisciplina.SelectedItem;

            if (selStud == null || selDisc == null)
            {
                MessageBox.Show("Trebuie să selectezi şi Student, şi Disciplina.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Nota.StudentId = selStud.Id;
            Nota.DisciplinaId = selDisc.Id;
            Nota.Valoare = (int)numNota.Value;
            Nota.DataNota = dtpData.Value;

            // Composite ID rule: StudentId + DisciplinaId
            Nota.Id = selStud.Id + selDisc.Id;

            DialogResult = DialogResult.OK;
        }
    }
}
