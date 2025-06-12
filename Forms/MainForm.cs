using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Models;
using StudentGradeApp.Services;
using StudentGradeApp.Utils;
using StudentGradeApp.Forms;

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
            _dataService = new JsonDataService();

            // ---- MENIU Manage ----
            studentsToolStripMenuItem.Click += (s, e) => LoadStudents();
            disciplineToolStripMenuItem.Click += (s, e) => LoadDiscipline();
            notesToolStripMenuItem.Click += (s, e) => LoadNotes();
            toolStripSeparatorReports.Visible = true;

            byStudentToolStripMenuItem.Click += (s, e) =>
            {
                using (var f = new StudentSituationForm())
                {
                    f.ShowDialog();
                }
            };

            byDisciplineToolStripMenuItem.Click += (s, e) =>
            {
                using (var f = new DisciplineSituationForm())
                {
                    f.ShowDialog();
                }
            };

            generalToolStripMenuItem.Click += (s, e) =>
            {
                using (var f = new GeneralOverviewForm())
                {
                    f.ShowDialog();
                }
            };

            averageToolStripMenuItem.Click += (s, e) =>
            {
                using (var f = new AverageForm())
                {
                    f.ShowDialog();
                }
            };

            matrixToolStripMenuItem.Click += (s, e) =>
            {
                using (var f = new StatusMatrixForm())
                {
                    f.ShowDialog();
                }
            };

            filterGradesToolStripMenuItem.Click += (s, e) =>
            {
                using (var f = new FilterForm())
                {
                    f.ShowDialog();
                }
            };

            exitToolStripMenuItem.Click += (s, e) => Close();

            // ---- Butoane CRUD ----
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

            // Încărcare inițială
            LoadStudents();
        }

        // --------------------- Încărcare entități ---------------------
        private void LoadStudents()
        {
            _students = _dataService.GetAllStudents().ToList();
            dgvEntities.DataSource = _students;
        }

        private void LoadDiscipline()
        {
            _discipline = _dataService.GetAllDiscipline().ToList();
            dgvEntities.DataSource = _discipline;
        }

        private void LoadNotes()
        {
            _note = _dataService.GetAllNotes().ToList();
            dgvEntities.DataSource = _note;
        }

        // --------------------- CRUD ---------------------
        private void OnAdd(object sender, EventArgs e)
        {
            if (dgvEntities.DataSource == _students)
            {
                using (var f = new StudentForm(null))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        _dataService.AddStudent(f.Student);
                        LoadStudents();
                    }
                }
            }
            else if (dgvEntities.DataSource == _discipline)
            {
                using (var f = new DisciplinaForm(null))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        _dataService.AddDisciplina(f.Disciplina);
                        LoadDiscipline();
                    }
                }
            }
            else
            {
                using (var f = new NotaForm(null))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        _dataService.AddNota(f.Nota);
                        LoadNotes();
                    }
                }
            }
        }

        private void OnEdit(object sender, EventArgs e)
        {
            if (dgvEntities.CurrentRow == null) return;

            if (dgvEntities.DataSource == _students)
            {
                var sel = (Student)dgvEntities.CurrentRow.DataBoundItem;
                using (var f = new StudentForm(sel))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        _dataService.UpdateStudent(f.Student);
                        LoadStudents();
                    }
                }
            }
            else if (dgvEntities.DataSource == _discipline)
            {
                var sel = (Disciplina)dgvEntities.CurrentRow.DataBoundItem;
                using (var f = new DisciplinaForm(sel))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        _dataService.UpdateDisciplina(f.Disciplina);
                        LoadDiscipline();
                    }
                }
            }
            else
            {
                var sel = (Nota)dgvEntities.CurrentRow.DataBoundItem;
                using (var f = new NotaForm(sel))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        _dataService.UpdateNota(f.Nota);
                        LoadNotes();
                    }
                }
            }
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (dgvEntities.CurrentRow == null) return;

            var confirm = MessageBox.Show("Sigur vrei să ștergi?", "Confirmare",
                                          MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

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

        // --------------------- Utilitare ---------------------
        private IEnumerable CurrentItems()
        {
            if (dgvEntities.DataSource == _students) return _students;
            if (dgvEntities.DataSource == _discipline) return _discipline;
            return _note;
        }

        private static string SaveCsv()
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
