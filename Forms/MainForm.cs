using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using StudentGradeApp.Models;
using StudentGradeApp.Services;
using StudentGradeApp.Utils;

namespace StudentGradeApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly IDataService _dataService;
        private List<Student> _students;
        private List<Disciplina> _discipline;
        private List<Nota> _note;

        public MainForm()
        {
            InitializeComponent();

            // Folosim JSON pentru stocare
            _dataService = new JsonDataService();

            // Legăm meniurile
            studentsToolStripMenuItem.Click += (s, e) => LoadStudents();
            disciplineToolStripMenuItem.Click += (s, e) => LoadDiscipline();
            notesToolStripMenuItem.Click += (s, e) => LoadNotes();
            exitToolStripMenuItem.Click += (s, e) => Close();

            // Legăm butoanele
            btnAdd.Click += OnAdd;
            btnEdit.Click += OnEdit;
            btnDelete.Click += OnDelete;
            btnRefresh.Click += OnRefresh;
            btnExportCsv.Click += (s, e) =>
            {
                var path = SaveCsv();
                if (!string.IsNullOrEmpty(path))
                    CsvHelper.ExportToCsv(CurrentItems(), path);
            };

            // La pornire, arătăm studenții
            LoadStudents();
        }

        private void LoadStudents()
        {
            _students = new List<Student>(_dataService.GetAllStudents());
            dgvEntities.DataSource = _students;
        }

        private void LoadDiscipline()
        {
            _discipline = new List<Disciplina>(_dataService.GetAllDiscipline());
            dgvEntities.DataSource = _discipline;
        }

        private void LoadNotes()
        {
            _note = new List<Nota>(_dataService.GetAllNotes());
            dgvEntities.DataSource = _note;
        }

        private void OnAdd(object sender, EventArgs e)
        {
            // Decidești ce form deschizi după sursa curentă
            if (dgvEntities.DataSource == _students)
            {
                var f = new StudentForm(null);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _dataService.AddStudent(f.Student);
                    LoadStudents();
                }
            }
            else if (dgvEntities.DataSource == _discipline)
            {
                var f = new DisciplinaForm(null);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _dataService.AddDisciplina(f.Disciplina);
                    LoadDiscipline();
                }
            }
            else
            {
                var f = new NotaForm(null);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _dataService.AddNota(f.Nota);
                    LoadNotes();
                }
            }
        }

        private void OnEdit(object sender, EventArgs e)
        {
            if (dgvEntities.CurrentRow == null) return;

            if (dgvEntities.DataSource == _students)
            {
                var sel = (Student)dgvEntities.CurrentRow.DataBoundItem;
                var f = new StudentForm(sel);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _dataService.UpdateStudent(f.Student);
                    LoadStudents();
                }
            }
            else if (dgvEntities.DataSource == _discipline)
            {
                var sel = (Disciplina)dgvEntities.CurrentRow.DataBoundItem;
                var f = new DisciplinaForm(sel);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _dataService.UpdateDisciplina(f.Disciplina);
                    LoadDiscipline();
                }
            }
            else
            {
                var sel = (Nota)dgvEntities.CurrentRow.DataBoundItem;
                var f = new NotaForm(sel);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _dataService.UpdateNota(f.Nota);
                    LoadNotes();
                }
            }
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (dgvEntities.CurrentRow == null) return;
            if (MessageBox.Show("Sigur vrei să ștergi?", "Confirmare", MessageBoxButtons.YesNo)
                    != DialogResult.Yes) return;

            if (dgvEntities.DataSource == _students)
            {
                var sel = (Student)dgvEntities.CurrentRow.DataBoundItem;
                _dataService.DeleteStudent(sel.Id);
                LoadStudents();
            }
            else if (dgvEntities.DataSource == _discipline)
            {
                var sel = (Disciplina)dgvEntities.CurrentRow.DataBoundItem;
                _dataService.DeleteDisciplina(sel.Id);
                LoadDiscipline();
            }
            else
            {
                var sel = (Nota)dgvEntities.CurrentRow.DataBoundItem;
                _dataService.DeleteNota(sel.Id);
                LoadNotes();
            }
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            if (dgvEntities.DataSource == _students) LoadStudents();
            else if (dgvEntities.DataSource == _discipline) LoadDiscipline();
            else LoadNotes();
        }

        private IEnumerable CurrentItems()
        {
            if (dgvEntities.DataSource == _students) return _students;
            if (dgvEntities.DataSource == _discipline) return _discipline;
            return _note;
        }

        private string SaveCsv()
        {
            using (var dlg = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                DefaultExt = "csv"
            })
            {
                return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : null;
            }
        }
    }
}
