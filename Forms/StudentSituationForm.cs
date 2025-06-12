using System;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Models;
using StudentGradeApp.Services;

namespace StudentGradeApp.Forms
{
    public partial class StudentSituationForm : Form
    {
        private readonly IDataService _dataService;  // Serviciu pentru accesul la date
        private readonly Student[] _students;        // Lista de studenți preîncărcată

        public StudentSituationForm()
        {
            InitializeComponent();
            _dataService = new JsonDataService();

            // === Populare ComboBox cu studenți ===
            _students = _dataService.GetAllStudents().ToArray();
            cmbStudents.DataSource = _students;
            cmbStudents.DisplayMember = "Nume_Complet"; // presupune proprietate calculată în modelul Student

            // Legare eveniment buton
            btnShow.Click += (s, e) => ShowDetails();

            // Selectează automat primul student dacă există
            if (_students.Length > 0)
                cmbStudents.SelectedIndex = 0;
        }

        /// <summary>
        /// Afișează situația școlară pentru studentul selectat.
        /// </summary>
        private void ShowDetails()
        {
            var selectedStudent = cmbStudents.SelectedItem as Student;
            if (selectedStudent == null)
                return;

            // === Obține notele studentului ===
            var notes = _dataService.GetAllNotes()
                .Where(n => n.StudentId == selectedStudent.Id)
                .ToList();

            // === Dictionar pentru nume discipline ===
            var disci = _dataService.GetAllDiscipline()
                .ToDictionary(d => d.Id, d => d.Nume);

            // === Proiectează raportul cu date utile ===
            var report = notes.Select(n => new
            {
                Disciplina = disci.TryGetValue(n.DisciplinaId, out var name) ? name : "(necunoscut)",
                Nota = n.Valoare,
                Data = n.DataNota.ToString("dd.MM.yyyy")
            })
            .OrderBy(r => r.Disciplina) // sortare alfabetică
            .ToList();

            // === Afișează raportul în DataGridView ===
            gridNotes.DataSource = report;

            // === Calculul mediei generale ===
            double avg = notes.Any()
                ? notes.Average(n => n.Valoare)
                : 0.0;

            lblAverage.Text = $"Media generală: {avg:0.00}";
        }
    }
}
