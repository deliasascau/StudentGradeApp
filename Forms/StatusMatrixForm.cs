using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Services;

namespace StudentGradeApp.Forms
{
    /// <summary>
    /// Form care afișează o matrice de statusuri (Promovat/Picat/–) pentru fiecare student și disciplină.
    /// </summary>
    public partial class StatusMatrixForm : Form
    {
        private readonly IDataService _dataService;

        public StatusMatrixForm()
        {
            InitializeComponent();
            _dataService = new JsonDataService();
            BuildMatrix();
        }

        /// <summary>
        /// Construiește tabelul pivot care afișează situația fiecărui student la fiecare disciplină.
        /// </summary>
        private void BuildMatrix()
        {
            var students = _dataService.GetAllStudents().ToList();
            var disciplines = _dataService.GetAllDiscipline().ToList();
            var notes = _dataService.GetAllNotes().ToList();

            var dt = new DataTable();
            dt.Columns.Add("Student");

            foreach (var d in disciplines)
                dt.Columns.Add(d.Nume);

            foreach (var s in students)
            {
                var row = dt.NewRow();
                row["Student"] = $"{s.Nume} {s.Prenume}";

                foreach (var d in disciplines)
                {
                    var noteDisc = notes
                        .Where(n => n.StudentId == s.Id && n.DisciplinaId == d.Id)
                        .Select(n => n.Valoare)
                        .ToList();

                    if (noteDisc.Count == 0)
                    {
                        row[d.Nume] = "-";                         // fără notă
                    }
                    else
                    {
                        var avg = noteDisc.Average();
                        row[d.Nume] = avg >= 5 ? "Promovat" : "Picat";
                    }
                }

                dt.Rows.Add(row);
            }

            dgvMatrix.DataSource = dt;

            // refacem subscrierea – prevenim multiple adăugări la eveniment
            dgvMatrix.CellFormatting -= DgvMatrix_CellFormatting;
            dgvMatrix.CellFormatting += DgvMatrix_CellFormatting;
        }

        /// <summary>
        /// Colorare condiționată a celulelor.
        /// </summary>
        private void DgvMatrix_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 0) return;

            var val = e.Value?.ToString();
            if (val == "Promovat")
            {
                e.CellStyle.BackColor = Color.LightGreen;
                e.CellStyle.ForeColor = Color.Black;
            }
            else if (val == "Picat")
            {
                e.CellStyle.BackColor = Color.IndianRed;
                e.CellStyle.ForeColor = Color.White;
            }
            else  // "-"
            {
                e.CellStyle.BackColor = dgvMatrix.DefaultCellStyle.BackColor;
                e.CellStyle.ForeColor = dgvMatrix.DefaultCellStyle.ForeColor;
            }
        }
    }
}
