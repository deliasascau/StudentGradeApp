using System;
using System.Windows.Forms;

namespace StudentGradeApp.Forms
{
    partial class MainForm
    {
        // -----------------  Designer fields  -----------------
        private System.ComponentModel.IContainer components = null;

        private MenuStrip menuStripMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem manageToolStripMenuItem;
        private ToolStripMenuItem studentsToolStripMenuItem;
        private ToolStripMenuItem disciplineToolStripMenuItem;
        private ToolStripMenuItem notesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparatorReports;
        private ToolStripMenuItem byStudentToolStripMenuItem;
        private ToolStripMenuItem byDisciplineToolStripMenuItem;
        private ToolStripMenuItem generalToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem averageToolStripMenuItem;
        private ToolStripMenuItem matrixToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem filterGradesToolStripMenuItem;

        private DataGridView dgvEntities;
        private Panel panelButtons;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnExportCsv;

        // -----------------  Dispose  -----------------
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        // -----------------  InitializeComponent  -----------------
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ===== MENIU principal ===================================================
            menuStripMain = new MenuStrip
            {
                BackColor = System.Drawing.Color.Indigo,
                ImageScalingSize = new System.Drawing.Size(24, 24),
                GripMargin = new Padding(2, 2, 0, 2),
                Location = new System.Drawing.Point(0, 0),
                Name = "menuStripMain",
                Size = new System.Drawing.Size(800, 33)
            };

            // --- File ---
            fileToolStripMenuItem = new ToolStripMenuItem
            {
                ForeColor = System.Drawing.SystemColors.ActiveBorder,
                Text = "File"
            };
            exitToolStripMenuItem = new ToolStripMenuItem
            {
                BackColor = System.Drawing.Color.FromArgb(255, 128, 128),
                Text = "Exit"
            };
            fileToolStripMenuItem.DropDownItems.Add(exitToolStripMenuItem);

            // --- Manage ---
            manageToolStripMenuItem = new ToolStripMenuItem
            {
                ForeColor = System.Drawing.SystemColors.ActiveBorder,
                Text = "Manage"
            };

            //   • sub-meniuri de administrare
            studentsToolStripMenuItem = BuildSubMenu("Studenți", System.Drawing.Color.Thistle);
            disciplineToolStripMenuItem = BuildSubMenu("Discipline", System.Drawing.Color.Thistle);
            notesToolStripMenuItem = BuildSubMenu("Note", System.Drawing.Color.Thistle);

            //   • separator + rapoarte
            toolStripSeparatorReports = new ToolStripSeparator();

            byStudentToolStripMenuItem = BuildSubMenu("Situație per Student", System.Drawing.Color.Orchid);
            byDisciplineToolStripMenuItem = BuildSubMenu("Situație per Disciplină", System.Drawing.Color.Orchid);
            generalToolStripMenuItem = BuildSubMenu("Situație generală", System.Drawing.Color.Orchid);

            toolStripSeparator1 = new ToolStripSeparator();

            averageToolStripMenuItem = BuildSubMenu("Media generală", System.Drawing.Color.DarkOrchid);
            matrixToolStripMenuItem = BuildSubMenu("Student x Curs", System.Drawing.Color.DarkOrchid);

            toolStripSeparator2 = new ToolStripSeparator();

            filterGradesToolStripMenuItem = BuildSubMenu("Filtrare Note", System.Drawing.Color.MediumPurple,
                                                         System.Drawing.Color.White);

            manageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                studentsToolStripMenuItem,
                disciplineToolStripMenuItem,
                notesToolStripMenuItem,
                toolStripSeparatorReports,
                byStudentToolStripMenuItem,
                byDisciplineToolStripMenuItem,
                generalToolStripMenuItem,
                toolStripSeparator1,
                averageToolStripMenuItem,
                matrixToolStripMenuItem,
                toolStripSeparator2,
                filterGradesToolStripMenuItem
            });

            menuStripMain.Items.AddRange(new ToolStripItem[]
            {
                fileToolStripMenuItem,
                manageToolStripMenuItem
            });

            // ===== DataGridView ======================================================
            dgvEntities = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                RowHeadersWidth = 62,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // ===== Bara de butoane ===================================================
            panelButtons = new Panel
            {
                BackColor = System.Drawing.SystemColors.ScrollBar,
                BorderStyle = BorderStyle.Fixed3D,
                Dock = DockStyle.Bottom,
                Size = new System.Drawing.Size(800, 100)
            };

            btnAdd = BuildButton("Add", System.Drawing.Color.Lime, 185);
            btnEdit = BuildButton("Edit", System.Drawing.Color.Yellow, 270);
            btnDelete = BuildButton("Delete", System.Drawing.Color.Red, 355);
            btnRefresh = BuildButton("Refresh", System.Drawing.Color.Cyan, 440);
            btnExportCsv = BuildButton("Export CSV", System.Drawing.Color.Violet, 525, width: 90);

            panelButtons.Controls.AddRange(new Control[]
            {
                btnAdd, btnEdit, btnDelete, btnRefresh, btnExportCsv
            });

            // ===== Form -- proprietăți generale =====================================
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(800, 460);
            Controls.Add(dgvEntities);
            Controls.Add(panelButtons);
            Controls.Add(menuStripMain);
            Cursor = Cursors.PanNW;
            MainMenuStrip = menuStripMain;
            Name = "MainForm";
            Text = "Student Grade App";
        }

        // -----------------  Helpers  -----------------
        private static ToolStripMenuItem BuildSubMenu(string text, System.Drawing.Color back,
                                                      System.Drawing.Color? fore = null)
        {
            return new ToolStripMenuItem
            {
                BackColor = back,
                ForeColor = fore ?? System.Drawing.SystemColors.ControlText,
                Text = text
            };
        }

        private static Button BuildButton(string text, System.Drawing.Color back, int left, int width = 75)
        {
            return new Button
            {
                BackColor = back,
                FlatStyle = FlatStyle.Popup,
                Location = new System.Drawing.Point(left, 18),
                Name = $"btn{text.Replace(" ", "")}",
                Size = new System.Drawing.Size(width, 61),
                Text = text,
                UseVisualStyleBackColor = false
            };
        }
    }
}
