using System;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Models;
using StudentGradeApp.Services;

namespace StudentGradeApp.Forms
{
    public partial class DisciplinaForm : Form
    {
        private readonly IDataService _dataService;
        public Disciplina Disciplina { get; private set; }

        public DisciplinaForm(Disciplina disciplina)
        {
            InitializeComponent();

            _dataService = new JsonDataService();
                // Populate ComboBox with enum values
            cmbTipEvaluare.DataSource = Enum.GetValues(typeof(TipEvaluare))
                                            .Cast<TipEvaluare>()
                                            .ToList();

            // Clone or new
            if (disciplina != null)
            {
                Disciplina = new Disciplina
                {
                    Id = disciplina.Id,
                    Nume = disciplina.Nume,
                    Acronym = disciplina.Acronym,
                    TipEvaluare = disciplina.TipEvaluare
                };
            }
            else
            {
                // ADD new — pick the next available integer ≥ 1
                var all = _dataService.GetAllDiscipline().ToList();
                var nextId = all.Any()
                    ? all.Max(d => d.Id) + 1
                    : 1;

                Disciplina = new Disciplina
                {
                    Id = nextId
                };
            }

            // Fill controls
            numId.Value = Disciplina.Id;
            txtNume.Text = Disciplina.Nume;
            txtAcronim.Text = Disciplina.Acronym;
            cmbTipEvaluare.SelectedItem = Disciplina.TipEvaluare;

            // Wire buttons
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                MessageBox.Show("Introdu numele disciplinei.");
                return;
            }

            // Assign back into model
            Disciplina.Id = (int)numId.Value;
            Disciplina.Nume = txtNume.Text.Trim();
            Disciplina.Acronym = txtAcronim.Text.Trim();
            Disciplina.TipEvaluare = (TipEvaluare)cmbTipEvaluare.SelectedItem;

            DialogResult = DialogResult.OK;
        }
    }
}
