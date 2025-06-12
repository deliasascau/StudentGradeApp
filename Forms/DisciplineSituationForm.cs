using System;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Services;
using StudentGradeApp.Models;

namespace StudentGradeApp.Forms
{
    public partial class DisciplineSituationForm : Form
    {
        private readonly IDataService _dataService;  // Serviciu de acces la date (JSON în implementarea curentă)
        private readonly Disciplina[] _disciplines;  // Lista de discipline disponibilă în memorie

        public DisciplineSituationForm()
        {
            InitializeComponent();
            _dataService = new JsonDataService();

            // === Încărcare discipline în ComboBox ===
            _disciplines = _dataService.GetAllDiscipline().ToArray();
            cmbDisciplines.DataSource = _disciplines;
            cmbDisciplines.DisplayMember = "Nume";

            // Legare eveniment pe butonul Show
            btnShow.Click += (s, e) => ShowDetails();

            // Selectare implicită prima disciplină (dacă există)
            if (_disciplines.Length > 0)
                cmbDisciplines.SelectedIndex = 0;
        }

        /// <summary>
        /// Afișează notele și media generală pentru disciplina selectată.
        /// </summary>
        private void ShowDetails()
        {
            var d = cmbDisciplines.SelectedItem as Disciplina;
            if (d == null) return;

            // === Obține notele pentru disciplina selectată ===
            var notes = _dataService.GetAllNotes()
                .Where(n => n.DisciplinaId == d.Id)
                .ToList();

            // === Creează dicționar StudentId → Nume complet ===
            var studs = _dataService.GetAllStudents()
                .ToDictionary(s => s.Id, s => $"{s.Nume} {s.Prenume}");

            // === Proiectare date pentru afișare ===
            var rows = notes.Select(n => new
            {
                Student = studs.TryGetValue(n.StudentId, out var name) ? name : "(unknown)",
                Nota = n.Valoare,
                Data = n.DataNota.ToString("dd.MM.yyyy")
            })
            .OrderBy(r => r.Student)
            .ToList();

            // === Afișare în DataGridView ===
            gridResults.DataSource = rows;

            // === Calcul medie generală pentru disciplină ===
            double avg = notes.Any()
                ? notes.Average(n => n.Valoare)
                : 0.0;

            lblAverage.Text = $"Media disciplinei: {avg:0.00}";
        }
    }
}
