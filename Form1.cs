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

            // Obiekt algorytmu genetycznego
            ga = new AlgorytmGenetyczny();

            // Podpinanie handlerów przycisków i timerów

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
        // DYWANIK
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
            txtWynikiDywanik.AppendText(
                $"Start: Najl={Max(przystDywanik):F4} Sr={Avg(przystDywanik):F4}\r\n"
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

            // Iteracja
            bool[][] nowaPop = ga.IteracjaDywanik(
                populacjaDywanik,
                przystDywanik,
                st.bity,
                st.turniej
            );
            populacjaDywanik = nowaPop;
            przystDywanik = ga.ObliczPrzystosowanieDywanik(populacjaDywanik, st.bity);

            txtWynikiDywanik.AppendText(
                $"Iter={licznikIterDywanik}: Najl={Max(przystDywanik):F4}, Sr={Avg(przystDywanik):F4}\r\n"
            );
        }

        private class DywanikStan
        {
            public int bity;
            public int turniej;
        }

        // =====================================================================
        // SINUS
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
            txtWynikiSinus.AppendText(
                $"Start: Najl={Max(przystSinus):F4} Sr={Avg(przystSinus):F4}\r\n"
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

            txtWynikiSinus.AppendText(
                $"Iter={licznikIterSinus}: Najl={Max(przystSinus):F4}, Sr={Avg(przystSinus):F4}\r\n"
            );
        }

        private class SinusStan
        {
            public int bity;
            public int turniej;
        }

        // =====================================================================
        // XOR
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
            txtWynikiXOR.AppendText(
                $"Start: Najl={Max(przystXOR):F4} Sr={Avg(przystXOR):F4}\r\n"
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

            txtWynikiXOR.AppendText(
                $"Iter={licznikIterXOR}: Najl={Max(przystXOR):F4}, Sr={Avg(przystXOR):F4}\r\n"
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
