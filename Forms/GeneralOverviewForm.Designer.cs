using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StudentGradeApp.Forms
{
    partial class GeneralOverviewForm
    {
        private IContainer components = null;
        private TableLayoutPanel tblMain;
        private FlowLayoutPanel flpMetrics;
        private Label lblTotalStudents, lblTotalCourses, lblAverageGrade, lblPassRate;
        private TableLayoutPanel tblCharts;
        private Chart chartEnrollment, chartPassFail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tblMain = new TableLayoutPanel();
            this.flpMetrics = new FlowLayoutPanel();
            this.lblTotalStudents = new Label();
            this.lblTotalCourses = new Label();
            this.lblAverageGrade = new Label();
            this.lblPassRate = new Label();
            this.tblCharts = new TableLayoutPanel();
            this.chartEnrollment = new Chart();
            this.chartPassFail = new Chart();

            // 
            // tblMain
            // 
            this.tblMain.Dock = DockStyle.Fill;
            this.tblMain.RowCount = 2;
            this.tblMain.ColumnCount = 1;
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F)); // metrics row
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // charts row
            this.tblMain.Controls.Add(this.flpMetrics, 0, 0);
            this.tblMain.Controls.Add(this.tblCharts, 0, 1);

            // 
            // flpMetrics
            // 
            this.flpMetrics.Dock = DockStyle.Fill;
            this.flpMetrics.Padding = new Padding(10);
            this.flpMetrics.BackColor = Color.WhiteSmoke;
            this.flpMetrics.FlowDirection = FlowDirection.LeftToRight;
            this.flpMetrics.WrapContents = false;
            foreach (var lbl in new[] { lblTotalStudents, lblTotalCourses, lblAverageGrade, lblPassRate })
            {
                lbl.AutoSize = false;
                lbl.Size = new Size(180, 60);
                lbl.Margin = new Padding(10);
                lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BackColor = Color.White;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                this.flpMetrics.Controls.Add(lbl);
            }

            // 
            // tblCharts
            // 
            this.tblCharts.Dock = DockStyle.Fill;
            this.tblCharts.RowCount = 1;
            this.tblCharts.ColumnCount = 2;
            this.tblCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tblCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tblCharts.Controls.Add(this.chartEnrollment, 0, 0);
            this.tblCharts.Controls.Add(this.chartPassFail, 1, 0);

            // 
            // chartEnrollment
            // 
            this.chartEnrollment.Dock = DockStyle.Fill;
            var ca1 = new ChartArea("Situație Înscriși");
            ca1.AxisX.MajorGrid.Enabled = false;
            ca1.AxisY.MajorGrid.LineColor = Color.LightGray;
            ca1.AxisY.Title = "Studenți";
            this.chartEnrollment.ChartAreas.Add(ca1);
            this.chartEnrollment.Legends.Add(new Legend("LegendE") { Docking = Docking.Top });
            var se = new Series("Înscriși")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.MediumSlateBlue,
                IsValueShownAsLabel = true,
                LabelForeColor = Color.Black,
            };
            this.chartEnrollment.Series.Add(se);

            // 
            // chartPassFail
            // 
            this.chartPassFail.Dock = DockStyle.Fill;
            var ca2 = new ChartArea("Promovat-Picat");
            this.chartPassFail.ChartAreas.Add(ca2);
            this.chartPassFail.Legends.Add(new Legend("LegendP") { Docking = Docking.Top });
            var sp = new Series("Status")
            {
                ChartType = SeriesChartType.Pie,
                Palette = ChartColorPalette.Excel,
                BorderColor = Color.White,
                BorderWidth = 1,
                IsValueShownAsLabel = true,
                Label = "#VALX: #PERCENT{P1}"
            };
            this.chartPassFail.Series.Add(sp);

            // 
            // GeneralOverviewForm
            // 
            this.ClientSize = new Size(800, 600);
            this.Controls.Add(this.tblMain);
            this.Text = "Situație generală";
        }
    }
}
