using System;
using System.Linq;
using System.Windows.Forms;

namespace AlGen
{
    public partial class Form1 : Form
    {
        private AlgorytmGenetyczny ga;

        // ========== Pola dla Zadania 1 (Dywanik) ==========
        private bool[][] populacjaDywanik;
        private double[] przystDywanik;
        private int licznikIterDywanik;
        private int maxIterDywanik;
        private int bityDywanik, turniejDywanik;

        // ========== Pola dla Zadania 2 (Sinus) ==========
        private bool[][] populacjaSinus;
        private double[] przystSinus;
        private int licznikIterSinus;
        private int maxIterSinus;
        private int bitySinus, turniejSinus;

        // ========== Pola dla Zadania 3 (XOR) ==========
        private bool[][] populacjaXOR;
        private double[] przystXOR;
        private int licznikIterXOR;
        private int maxIterXOR;
        private int bityXOR, turniejXOR;

        public Form1()
        {
            InitializeComponent();
            ga = new AlgorytmGenetyczny();

            // Przycisk do ładowania danych Sinus
            btnLoadSinusData.Click += BtnLoadSinusData_Click;

            // Dywanik
            btnStartDywanik.Click += BtnStartDywanik_Click;
            btnStopDywanik.Click += BtnStopDywanik_Click;
            timerDywanik.Tick += TimerDywanik_Tick;

            // Sinus
            btnStartSinus.Click += BtnStartSinus_Click;
            btnStopSinus.Click += BtnStopSinus_Click;
            timerSinus.Tick += TimerSinus_Tick;

            // XOR
            btnStartXOR.Click += BtnStartXOR_Click;
            btnStopXOR.Click += BtnStopXOR_Click;
            timerXOR.Tick += TimerXOR_Tick;
        }

        // ---------------------------------------------------------------------
        // Obsługa przycisku do wczytania pliku z danymi dla sinus
        // ---------------------------------------------------------------------
        private void BtnLoadSinusData_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Wybierz plik z danymi do sinus";
                dlg.Filter = "Pliki tekstowe|*.txt|Wszystkie pliki|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ga.ZaladujDaneSinus(dlg.FileName);
                        MessageBox.Show("Wczytano dane z pliku:\n" + dlg.FileName,
                                        "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd podczas wczytywania: " + ex.Message,
                                        "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =====================================================================
        // ZADANIE 1: Dywanik
        // =====================================================================
        private void BtnStartDywanik_Click(object sender, EventArgs e)
        {
            txtWynikiDywanik.Clear();

            int rozmiarPopulacji = int.Parse(txtPopulacjaDywanik.Text);
            bityDywanik = int.Parse(txtBityDywanik.Text);
            maxIterDywanik = int.Parse(txtIteracjeDywanik.Text);
            turniejDywanik = int.Parse(txtTurniejDywanik.Text);

            // Inicjalizacja
            populacjaDywanik = ga.InicjalizujDywanik(rozmiarPopulacji, bityDywanik);
            przystDywanik = ga.ObliczPrzystosowanieDywanik(populacjaDywanik, bityDywanik);
            licznikIterDywanik = 0;

            // Wypisanie stanu początkowego
            WypiszDywanik("Start");
            timerDywanik.Start();
        }

        private void BtnStopDywanik_Click(object sender, EventArgs e)
        {
            timerDywanik.Stop();
            txtWynikiDywanik.AppendText("Dywanik STOP\r\n");
        }

        private void TimerDywanik_Tick(object sender, EventArgs e)
        {
            licznikIterDywanik++;
            if (licznikIterDywanik > maxIterDywanik)
            {
                timerDywanik.Stop();
                txtWynikiDywanik.AppendText("Koniec Dywanik\r\n");
                return;
            }

            // Kolejna iteracja
            populacjaDywanik = ga.IteracjaDywanik(populacjaDywanik, przystDywanik, bityDywanik, turniejDywanik);
            przystDywanik = ga.ObliczPrzystosowanieDywanik(populacjaDywanik, bityDywanik);

            WypiszDywanik($"Iter={licznikIterDywanik}");
        }

        private void WypiszDywanik(string prefix)
        {
            int bestIdx = ga.ZnajdzNajlepszy(przystDywanik);
            (double x1, double x2) = ga.DekodujDwaParametry(populacjaDywanik[bestIdx], bityDywanik, 0, 100);

            double najlepsze = przystDywanik.Max();
            double srednia = przystDywanik.Average();

            txtWynikiDywanik.AppendText(
                $"{prefix} | Najl={najlepsze:F4} | Sr={srednia:F4} | bestX1={x1:F2}, bestX2={x2:F2}\r\n"
            );
        }

        // =====================================================================
        // ZADANIE 2: Sinus
        // =====================================================================
        private void BtnStartSinus_Click(object sender, EventArgs e)
        {
            txtWynikiSinus.Clear();

            int rozmiarPopulacji = int.Parse(txtPopulacjaSinus.Text);
            bitySinus = int.Parse(txtBitySinus.Text);
            maxIterSinus = int.Parse(txtIteracjeSinus.Text);
            turniejSinus = int.Parse(txtTurniejSinus.Text);

            // Inicjalizacja
            populacjaSinus = ga.InicjalizujSinus(rozmiarPopulacji, bitySinus);
            przystSinus = ga.ObliczPrzystosowanieSinus(populacjaSinus, bitySinus);
            licznikIterSinus = 0;

            WypiszSinus("Start");
            timerSinus.Start();
        }

        private void BtnStopSinus_Click(object sender, EventArgs e)
        {
            timerSinus.Stop();
            txtWynikiSinus.AppendText("Sinus STOP\r\n");
        }

        private void TimerSinus_Tick(object sender, EventArgs e)
        {
            licznikIterSinus++;
            if (licznikIterSinus > maxIterSinus)
            {
                timerSinus.Stop();
                txtWynikiSinus.AppendText("Koniec Sinus\r\n");
                return;
            }

            populacjaSinus = ga.IteracjaSinus(populacjaSinus, przystSinus, bitySinus, turniejSinus);
            przystSinus = ga.ObliczPrzystosowanieSinus(populacjaSinus, bitySinus);

            WypiszSinus($"Iter={licznikIterSinus}");
        }

        private void WypiszSinus(string prefix)
        {
            int bestIdx = ga.ZnajdzNajlepszy(przystSinus);
            (double pa, double pb, double pc) = ga.DekodujTrzyParametry(populacjaSinus[bestIdx], bitySinus, 0, 3);

            double najlepsze = przystSinus.Max();
            double srednia = przystSinus.Average();

            txtWynikiSinus.AppendText(
                $"{prefix} | Najl={najlepsze:F4} | Sr={srednia:F4} | bestPa={pa:F2}, bestPb={pb:F2}, bestPc={pc:F2}\r\n"
            );
        }

        // =====================================================================
        // ZADANIE 3: XOR
        // =====================================================================
        private void BtnStartXOR_Click(object sender, EventArgs e)
        {
            txtWynikiXOR.Clear();

            int rozmiarPopulacji = int.Parse(txtPopulacjaXOR.Text);
            bityXOR = int.Parse(txtBityXOR.Text);
            maxIterXOR = int.Parse(txtIteracjeXOR.Text);
            turniejXOR = int.Parse(txtTurniejXOR.Text);

            // Inicjalizacja
            populacjaXOR = ga.InicjalizujXOR(rozmiarPopulacji, bityXOR);
            przystXOR = ga.ObliczPrzystosowanieXOR(populacjaXOR, bityXOR);
            licznikIterXOR = 0;

            WypiszXOR("Start");
            timerXOR.Start();
        }

        private void BtnStopXOR_Click(object sender, EventArgs e)
        {
            timerXOR.Stop();
            txtWynikiXOR.AppendText("XOR STOP\r\n");
        }

        private void TimerXOR_Tick(object sender, EventArgs e)
        {
            licznikIterXOR++;
            if (licznikIterXOR > maxIterXOR)
            {
                timerXOR.Stop();
                txtWynikiXOR.AppendText("Koniec XOR\r\n");
                return;
            }

            populacjaXOR = ga.IteracjaXOR(populacjaXOR, przystXOR, bityXOR, turniejXOR);
            przystXOR = ga.ObliczPrzystosowanieXOR(populacjaXOR, bityXOR);

            WypiszXOR($"Iter={licznikIterXOR}");
        }

        private void WypiszXOR(string prefix)
        {
            int bestIdx = ga.ZnajdzNajlepszy(przystXOR);
            double[] bestWagi = ga.DekodujWagi(populacjaXOR[bestIdx], bityXOR, 9, -10, 10);

            double najlepsze = przystXOR.Max();
            double srednia = przystXOR.Average();

            // Sklejanie wag do tekstu
            string wagiText = string.Join("; ", bestWagi.Select((w, i) => $"w{i}={w:F3}"));

            txtWynikiXOR.AppendText(
                $"{prefix} | Najl={najlepsze:F4} | Sr={srednia:F4} | bestWagi=({wagiText})\r\n"
            );
        }
    }
}
