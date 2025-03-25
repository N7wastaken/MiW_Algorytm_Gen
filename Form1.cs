using System;
using System.Linq;
using System.Windows.Forms;

namespace AlGen
{
    public partial class Form1 : Form
    {
        private AlgorytmGenetyczny ga;

        // ===================== Dywanik =====================
        private bool[][] populacjaDywanik;
        private double[] przystDywanik;
        private int licznikIterDywanik;
        private int maxIterDywanik;

        // ===================== Sinus =====================
        private bool[][] populacjaSinus;
        private double[] przystSinus;
        private int licznikIterSinus;
        private int maxIterSinus;

        // ===================== XOR =====================
        private bool[][] populacjaXOR;
        private double[] przystXOR;
        private int licznikIterXOR;
        private int maxIterXOR;

        public Form1()
        {
            InitializeComponent();

            ga = new AlgorytmGenetyczny();

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

        // =====================================================================
        // DYWANIK (Zadanie 1)
        // =====================================================================
        private void BtnStartDywanik_Click(object sender, EventArgs e)
        {
            txtWynikiDywanik.Clear();

            int pop = int.Parse(txtPopulacjaDywanik.Text);
            int bity = int.Parse(txtBityDywanik.Text);
            maxIterDywanik = int.Parse(txtIteracjeDywanik.Text);
            int turniej = int.Parse(txtTurniejDywanik.Text);

            // Inicjalizacja
            populacjaDywanik = ga.InicjalizujDywanik(pop, bity);
            przystDywanik = ga.ObliczPrzystosowanieDywanik(populacjaDywanik, bity);

            licznikIterDywanik = 0;

            int bestIdx = ga.ZnajdzNajlepszy(przystDywanik);
            (double bestX1, double bestX2) = ga.DekodujDwaParametry(populacjaDywanik[bestIdx], bity, 0, 100);

            txtWynikiDywanik.AppendText(
                $"Start | Najl={Max(przystDywanik):F4} | Sr={Avg(przystDywanik):F4} | bestX1={bestX1:F4} | bestX2={bestX2:F4}\r\n"
            );

            timerDywanik.Tag = new DywanikStan { bity = bity, turniej = turniej };
            timerDywanik.Start();
        }

        private void BtnStopDywanik_Click(object sender, EventArgs e)
        {
            timerDywanik.Stop();
            txtWynikiDywanik.AppendText("Dywanik STOP\r\n");
        }

        private void TimerDywanik_Tick(object sender, EventArgs e)
        {
            var st = (DywanikStan)timerDywanik.Tag;

            licznikIterDywanik++;
            if (licznikIterDywanik > maxIterDywanik)
            {
                timerDywanik.Stop();
                txtWynikiDywanik.AppendText("Koniec Dywanik\r\n");
                return;
            }

            bool[][] nowaPop = ga.IteracjaDywanik(populacjaDywanik, przystDywanik, st.bity, st.turniej);
            populacjaDywanik = nowaPop;
            przystDywanik = ga.ObliczPrzystosowanieDywanik(populacjaDywanik, st.bity);

            int bestIdx = ga.ZnajdzNajlepszy(przystDywanik);
            (double bestX1, double bestX2) = ga.DekodujDwaParametry(populacjaDywanik[bestIdx], st.bity, 0, 100);

            txtWynikiDywanik.AppendText(
                $"Iter={licznikIterDywanik} | Najl={Max(przystDywanik):F4} | Sr={Avg(przystDywanik):F4} | bestX1={bestX1:F4} | bestX2={bestX2:F4}\r\n"
            );
        }

        private class DywanikStan
        {
            public int bity;
            public int turniej;
        }

        // =====================================================================
        // SINUS (Zadanie 2)
        // =====================================================================
        private void BtnStartSinus_Click(object sender, EventArgs e)
        {
            txtWynikiSinus.Clear();

            int pop = int.Parse(txtPopulacjaSinus.Text);
            int bity = int.Parse(txtBitySinus.Text);
            maxIterSinus = int.Parse(txtIteracjeSinus.Text);
            int turniej = int.Parse(txtTurniejSinus.Text);

            populacjaSinus = ga.InicjalizujSinus(pop, bity);
            przystSinus = ga.ObliczPrzystosowanieSinus(populacjaSinus, bity);

            licznikIterSinus = 0;

            int bestIdx = ga.ZnajdzNajlepszy(przystSinus);
            (double pa, double pb, double pc) = ga.DekodujTrzyParametry(populacjaSinus[bestIdx], bity, 0, 3);

            txtWynikiSinus.AppendText(
                $"Start | Najl={Max(przystSinus):F4} | Sr={Avg(przystSinus):F4} | bestPa={pa:F4} | bestPb={pb:F4} | bestPc={pc:F4}\r\n"
            );

            timerSinus.Tag = new SinusStan { bity = bity, turniej = turniej };
            timerSinus.Start();
        }

        private void BtnStopSinus_Click(object sender, EventArgs e)
        {
            timerSinus.Stop();
            txtWynikiSinus.AppendText("Sinus STOP\r\n");
        }

        private void TimerSinus_Tick(object sender, EventArgs e)
        {
            var st = (SinusStan)timerSinus.Tag;

            licznikIterSinus++;
            if (licznikIterSinus > maxIterSinus)
            {
                timerSinus.Stop();
                txtWynikiSinus.AppendText("Koniec Sinus\r\n");
                return;
            }

            bool[][] nowa = ga.IteracjaSinus(populacjaSinus, przystSinus, st.bity, st.turniej);
            populacjaSinus = nowa;
            przystSinus = ga.ObliczPrzystosowanieSinus(populacjaSinus, st.bity);

            int bestIdx = ga.ZnajdzNajlepszy(przystSinus);
            (double pa, double pb, double pc) = ga.DekodujTrzyParametry(populacjaSinus[bestIdx], st.bity, 0, 3);

            txtWynikiSinus.AppendText(
                $"Iter={licznikIterSinus} | Najl={Max(przystSinus):F4} | Sr={Avg(przystSinus):F4} | bestPa={pa:F4} | bestPb={pb:F4} | bestPc={pc:F4}\r\n"
            );
        }

        private class SinusStan
        {
            public int bity;
            public int turniej;
        }

        // =====================================================================
        // XOR (Zadanie 3)
        // =====================================================================
        private void BtnStartXOR_Click(object sender, EventArgs e)
        {
            txtWynikiXOR.Clear();

            int pop = int.Parse(txtPopulacjaXOR.Text);
            int bity = int.Parse(txtBityXOR.Text);
            maxIterXOR = int.Parse(txtIteracjeXOR.Text);
            int turniej = int.Parse(txtTurniejXOR.Text);

            populacjaXOR = ga.InicjalizujXOR(pop, bity);
            przystXOR = ga.ObliczPrzystosowanieXOR(populacjaXOR, bity);

            licznikIterXOR = 0;

            int bestIdx = ga.ZnajdzNajlepszy(przystXOR);
            double[] bestWagi = ga.DekodujWagi(populacjaXOR[bestIdx], bity, 9, -10, 10);
            string wagiText = string.Join("; ", bestWagi.Select((w, i) => $"w{i}={w:F3}"));

            txtWynikiXOR.AppendText(
                $"Start | Najl={Max(przystXOR):F4} | Sr={Avg(przystXOR):F4} | bestWagi=({wagiText})\r\n"
            );

            timerXOR.Tag = new XORStan { bity = bity, turniej = turniej };
            timerXOR.Start();
        }

        private void BtnStopXOR_Click(object sender, EventArgs e)
        {
            timerXOR.Stop();
            txtWynikiXOR.AppendText("XOR STOP\r\n");
        }

        private void TimerXOR_Tick(object sender, EventArgs e)
        {
            var st = (XORStan)timerXOR.Tag;

            licznikIterXOR++;
            if (licznikIterXOR > maxIterXOR)
            {
                timerXOR.Stop();
                txtWynikiXOR.AppendText("Koniec XOR\r\n");
                return;
            }

            bool[][] nowa = ga.IteracjaXOR(populacjaXOR, przystXOR, st.bity, st.turniej);
            populacjaXOR = nowa;
            przystXOR = ga.ObliczPrzystosowanieXOR(populacjaXOR, st.bity);

            int bestIdx = ga.ZnajdzNajlepszy(przystXOR);
            double[] bestWagi = ga.DekodujWagi(populacjaXOR[bestIdx], st.bity, 9, -10, 10);
            string wagiText = string.Join("; ", bestWagi.Select((w, i) => $"w{i}={w:F3}"));

            txtWynikiXOR.AppendText(
                $"Iter={licznikIterXOR} | Najl={Max(przystXOR):F4} | Sr={Avg(przystXOR):F4} | bestWagi=({wagiText})\r\n"
            );
        }

        private class XORStan
        {
            public int bity;
            public int turniej;
        }

        // =====================================================================
        // Pomocnicze
        // =====================================================================
        private double Max(double[] tab) => tab.Max();
        private double Avg(double[] tab) => tab.Average();
    }
}
