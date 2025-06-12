using System;
using System.Linq;
using System.Windows.Forms;
using StudentGradeApp.Models;
using StudentGradeApp.Services;

namespace StudentGradeApp.Forms
{
    public partial class DisciplinaForm : Form
    {
        private readonly IDataService _dataService; // Serviciu pentru acces la date (ex: JSON)
        public Disciplina Disciplina { get; private set; } // Proprietate accesibilă de MainForm

        /// <summary>
        /// Constructor pentru adăugare sau editare disciplină.
        /// Dacă se primește o disciplină, se clonează. Dacă nu, se creează una nouă.
        /// </summary>
        public DisciplinaForm(Disciplina disciplina)
        {
            InitializeComponent();

            // Inițializare serviciu de date (în acest caz, JSON)
            _dataService = new JsonDataService();

            // Populare combo box cu valorile din enum-ul TipEvaluare
            cmbTipEvaluare.DataSource = Enum.GetValues(typeof(TipEvaluare))
                                            .Cast<TipEvaluare>()
                                            .ToList();

            // Verifică dacă se editează sau se creează o disciplină nouă
            if (disciplina != null)
            {
                // Clonare disciplină existentă
                Disciplina = new Disciplina
                {
                    Id = disciplina.Id,
                    Nume = disciplina.Nume,
                    Acronim = disciplina.Acronim,
                    TipEvaluare = disciplina.TipEvaluare
                };
            }
            else
            {
                // Creare disciplină nouă cu ID generat automat
                var all = _dataService.GetAllDiscipline().ToList();
                var nextId = all.Any()
                    ? all.Max(d => d.Id) + 1
                    : 1;

                Disciplina = new Disciplina
                {
                    Id = nextId
                };
            }

            // Umplere controale formular cu datele disciplinei
            numId.Value = Disciplina.Id;
            txtNume.Text = Disciplina.Nume;
            txtAcronim.Text = Disciplina.Acronim;
            cmbTipEvaluare.SelectedItem = Disciplina.TipEvaluare;

            // Legare evenimente la butoane
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Eveniment la salvarea formularului.
        /// Validează și actualizează obiectul Disciplina.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validare simplă: numele disciplinei este obligatoriu
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                MessageBox.Show("Enter course name, please.");
                return;
            }

            // Preluare date din controale și salvare în obiectul Disciplina
            Disciplina.Id = (int)numId.Value;
            Disciplina.Nume = txtNume.Text.Trim();
            Disciplina.Acronim = txtAcronim.Text.Trim();
            Disciplina.TipEvaluare = (TipEvaluare)cmbTipEvaluare.SelectedItem;

            // Închide formularul cu rezultat OK
            DialogResult = DialogResult.OK;
        }
    }
}
