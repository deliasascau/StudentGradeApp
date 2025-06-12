using System;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Services;

namespace StudentGradeApp.Forms
{
    public partial class GeneralOverviewForm : Form
    {
        private readonly IDataService _dataService;
        public GeneralOverviewForm()
        {
            InitializeComponent();
            _dataService = new JsonDataService();
            LoadMetrics();
            LoadEnrollmentChart();
            LoadPassFailChart();
        }

        private void LoadMetrics()
        {
            var studs = _dataService.GetAllStudents().Count();
            var courses = _dataService.GetAllDiscipline().Count();
            var notes = _dataService.GetAllNotes().ToList();
            var avg = notes.Any() ? notes.Average(n => n.Valoare) : 0.0;
            var passed = notes.Count(n => n.Valoare >= 5);

            lblTotalStudents.Text = $"Studenți\n{studs}";
            lblTotalCourses.Text = $"Cursuri\n{courses}";
            lblAverageGrade.Text = $"Media generală\n{avg:0.00}";
            lblPassRate.Text = $"Promovate\n{passed}/{notes.Count}";
        }

        private void LoadEnrollmentChart()
        {
            var notes = _dataService.GetAllNotes();
            var courses = _dataService.GetAllDiscipline()
                                       .ToDictionary(d => d.Id, d => d.Nume);

            var data = notes
                .GroupBy(n => n.DisciplinaId)
                .Select(g => new {
                    Name = courses[g.Key],
                    Count = g.Select(n => n.StudentId).Distinct().Count()
                })
                .OrderBy(x => x.Name);

            var s = chartEnrollment.Series["Înscriși"];
            s.Points.Clear();
            foreach (var pt in data)
                s.Points.AddXY(pt.Name, pt.Count);
        }

        private void LoadPassFailChart()
        {
            var notes = _dataService.GetAllNotes();
            var passed = notes.Count(n => n.Valoare >= 5);
            var failed = notes.Count() - passed;

            var s = chartPassFail.Series["Status"];
            s.Points.Clear();
            s.Points.AddXY("Promovat", passed);
            s.Points.AddXY("Picat", failed);
        }
    }
}
