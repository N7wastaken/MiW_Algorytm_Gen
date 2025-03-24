using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DywanikReal
{
    public partial class Form1 : Form
    {
        private GeneticAlgorithm ga;
        private Timer evolveTimer;
        private int iterationCount;

        public Form1()
        {
            InitializeComponent();

            // Tymczasowo tutaj
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Timer
            evolveTimer = new Timer();
            evolveTimer.Interval = 500;
            evolveTimer.Tick += (s, e) => RunOneIteration();

            // Wykres nie dzialajacy 
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            var area = new ChartArea("MainArea");
            chart1.ChartAreas.Add(area);

            var seriesBest = new Series("Najlepszy")
            {
                ChartType = SeriesChartType.Line
            };
            chart1.Series.Add(seriesBest);

            var seriesAvg = new Series("Średni")
            {
                ChartType = SeriesChartType.Line
            };
            chart1.Series.Add(seriesAvg);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                int pop = int.Parse(txtPopSize.Text);
                double mutRate = double.Parse(txtMutRate.Text);
                double mutStep = double.Parse(txtMutStep.Text);

                ga = new GeneticAlgorithm(pop, mutRate, mutStep);
                iterationCount = 0;

                // Czyszczenie 
                chart1.Series["Najlepszy"].Points.Clear();
                chart1.Series["Średni"].Points.Clear();

                // Dodaj punkt iter=0
                double best = ga.BestFitness();
                double avg = ga.AvgFitness();
                chart1.Series["Najlepszy"].Points.AddXY(0, best);

                var (bx, by) = ga.BestSolution();
                lblInfo.Text = $"Start: best={best:0.0000}, avg={avg:0.0000}, (x1={bx:0.0}, x2={by:0.0})";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            if (ga == null)
            {
                MessageBox.Show("Najpierw Init!");
                return;
            }
            RunOneIteration();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (ga == null)
            {
                MessageBox.Show("Najpierw Init!");
                return;
            }

            if (!evolveTimer.Enabled)
            {
                evolveTimer.Start();
                btnAuto.Text = "Stop";
            }
            else
            {
                evolveTimer.Stop();
                btnAuto.Text = "Autos";
            }
        }

        private void RunOneIteration()
        {
            iterationCount++;
            ga.DoOneIteration();

            double best = ga.BestFitness();
            double avg = ga.AvgFitness();

            chart1.Series["Najlepszy"].Points.AddXY(iterationCount, best);
            chart1.Series["Średni"].Points.AddXY(iterationCount, avg);

            var (bx, by) = ga.BestSolution();
            lblInfo.Text = $"Iter {iterationCount}: best={best:0.0000}, avg={avg:0.0000}, (x1={bx:0.0}, x2={by:0.0})";
        }
    }
}
