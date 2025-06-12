using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Models;
using StudentGradeApp.Services;

namespace StudentGradeApp.Forms
{
    public partial class AverageForm : Form
    {
        private readonly IDataService _dataService;
        private readonly List<Student> _students;

        public AverageForm()
        {
            InitializeComponent();
            _dataService = new JsonDataService();

            _students = _dataService.GetAllStudents().ToList();
            cmbStudents.DataSource = _students;
            cmbStudents.DisplayMember = "Nume";

            cmbStudents.SelectedIndexChanged += (s, e) => UpdateAverage();

            if (_students.Any())
                cmbStudents.SelectedIndex = 0;
        }

        private void UpdateAverage()
        {
            if (!(cmbStudents.SelectedItem is Student st)) return;

            var notes = _dataService.GetAllNotes()
                .Where(n => n.StudentId == st.Id)
                .Select(n => n.Valoare)
                .ToList();

            double media = notes.Any() ? notes.Average() : 0.0;
            double rounded = Math.Round(media, 2);

            // Afișare numerică
            lblValue.Text = $"Media: {rounded:0.00}";

            // Bară proporțională
            int progress = (int)(rounded * 10); // max = 100
            progressBarAverage.Value = Math.Min(progress, 100);

            // Culoare: verde dacă promovat, roșu dacă sub 5
            progressBarAverage.ForeColor = System.Drawing.Color.White;
            progressBarAverage.BackColor = rounded >= 5
                ? System.Drawing.Color.LightGreen
                : System.Drawing.Color.Salmon;
        }
    }

}