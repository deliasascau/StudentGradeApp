using System;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Services;
using StudentGradeApp.Models;

namespace StudentGradeApp.Forms
{
    public partial class FilterForm : Form
    {
        private readonly IDataService _dataService;
        private readonly System.Collections.Generic.List<Student> _students;
        private readonly System.Collections.Generic.List<Disciplina> _disciplines;

        public FilterForm()
        {
            InitializeComponent();
            _dataService = new JsonDataService();
            _students = _dataService.GetAllStudents().ToList();
            _disciplines = _dataService.GetAllDiscipline().ToList();

            // Populează doar ComboBox-ul, în funcție de radio
            rdoStudent.Checked = true;
            RefreshCombo();

            // Evenimente
            rdoStudent.CheckedChanged += (s, e) => RefreshCombo();
            rdoDisciplina.CheckedChanged += (s, e) => RefreshCombo();
            btnFilter.Click += (s, e) => ApplyFilter();
        }

        private void RefreshCombo()
        {
            cmbFilter.Items.Clear();
            if (rdoStudent.Checked)
            {
                cmbFilter.Items.Add("(toți)");
                cmbFilter.Items.AddRange(_students.Select(s => s.Nume + " " + s.Prenume).ToArray());
            }
            else
            {
                cmbFilter.Items.Add("(toate)");
                cmbFilter.Items.AddRange(_disciplines.Select(d => d.Nume).ToArray());
            }
            cmbFilter.SelectedIndex = 0;
        }

        private void ApplyFilter()
        {
            var notes = _dataService.GetAllNotes().ToList();
            var studs = _students.ToDictionary(s => s.Id, s => s.Nume + " " + s.Prenume);
            var disci = _disciplines.ToDictionary(d => d.Id, d => d.Nume);

            var sel = cmbFilter.SelectedItem.ToString();
            var filtered = notes.Where(n =>
                rdoStudent.Checked
                    ? (sel == "(toți)" || studs[n.StudentId] == sel)
                    : (sel == "(toate)" || disci[n.DisciplinaId] == sel)
            )
            .Select(n => new
            {
                Student = studs[n.StudentId],
                Disciplina = disci[n.DisciplinaId],
                Nota = n.Valoare,
                Data = n.DataNota.ToString("dd.MM.yyyy")
            })
            .OrderBy(x => rdoStudent.Checked ? x.Student : x.Disciplina)
            .ThenBy(x => x.Data)
            .ToList();

            dgvResults.DataSource = filtered;
        }
    }
}
