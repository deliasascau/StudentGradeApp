using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Services;

namespace StudentGradeApp.Forms
{
    public partial class StatusMatrixForm : Form
    {
        private readonly IDataService _dataService;

        public StatusMatrixForm()
        {
            InitializeComponent();
            _dataService = new JsonDataService();
            BuildMatrix();
        }

        private void BuildMatrix()
        {
            // Load data
            var students = _dataService.GetAllStudents().ToList();
            var disciplines = _dataService.GetAllDiscipline().ToList();
            var notes = _dataService.GetAllNotes().ToList();

            // Pivot DataTable
            var dt = new DataTable();
            dt.Columns.Add("Student");

            // One column per discipline
            foreach (var d in disciplines)
                dt.Columns.Add(d.Nume);

            // Fill rows
            foreach (var s in students)
            {
                var row = dt.NewRow();
                row["Student"] = s.Nume + " " + s.Prenume;

                foreach (var d in disciplines)
                {
                    // Average grade for this student+discipline
                    var avg = notes
                        .Where(n => n.StudentId == s.Id && n.DisciplinaId == d.Id)
                        .Select(n => n.Valoare)
                        .DefaultIfEmpty()    // if no notes, treat as 0
                        .Average();

                    row[d.Nume] = avg >= 5 ? "Promovat" : "Respins";
                }

                dt.Rows.Add(row);
            }

            // Bind to grid
            dgvMatrix.DataSource = dt;

            // Color‐coding on formatting
            dgvMatrix.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex == 0) return;
                var val = e.Value as string;
                if (val == "Promovat")
                    e.CellStyle.BackColor = Color.LightGreen;
                else if (val == "Respins")
                    e.CellStyle.BackColor = Color.IndianRed;
            };
        }
    }
}
