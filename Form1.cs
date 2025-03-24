using System;
using System.Linq;
using System.Windows.Forms;

namespace AlGen
{
    public partial class Form1 : Form
    {
        
        private AlgorytmGenetyczny ga;

             private bool[][] populacjaZ1;
        private double[] przystZ1;
        private int licznikIterZ1;
        private int maxIterZ1;

        // Zad2
        private bool[][] populacjaZ2;
        private double[] przystZ2;
        private int licznikIterZ2;
        private int maxIterZ2;

        // Zad3
        private bool[][] populacjaZ3;
        private double[] przystZ3;
        private int licznikIterZ3;
        private int maxIterZ3;

        public Form1()
        {
            
            InitializeComponent();

            // Tworzymy obiekt logiki
            ga = new AlgorytmGenetyczny();

            // Podpinamy przyciski do metod
            btnZ1Start.Click += BtnZ1Start_Click;
            btnZ1Stop.Click += BtnZ1Stop_Click;
            timerZad1.Tick += TimerZad1_Tick;

            btnZ2Start.Click += BtnZ2Start_Click;
            btnZ2Stop.Click += BtnZ2Stop_Click;
            timerZad2.Tick += TimerZad2_Tick;

            btnZ3Start.Click += BtnZ3Start_Click;
            btnZ3Stop.Click += BtnZ3Stop_Click;
            timerZad3.Tick += TimerZad3_Tick;
        }

        
        // Zad1 Start
        private void BtnZ1Start_Click(object sender, EventArgs e)
        {
            
            txtZ1Wyniki.Clear();

            
            int pop = int.Parse(txtZ1Pop.Text);
            int bity = int.Parse(txtZ1Bits.Text);
            maxIterZ1 = int.Parse(txtZ1Iter.Text);
            int turniej = int.Parse(txtZ1Tourn.Text);

    
            populacjaZ1 = ga.InicjalizujZad1(pop, bity);

            przystZ1 = ga.ObliczPrzystosowanieZad1(populacjaZ1, bity);

      
            licznikIterZ1 = 0;

          
            txtZ1Wyniki.AppendText($"Start: Najl={Max(przystZ1):F4} Sr={Avg(przystZ1):F4}\r\n");


            timerZad1.Tag = new Zad1Stan { bity = bity, turniej = turniej };
            timerZad1.Start();
        }

        // Zad1 Stop
        private void BtnZ1Stop_Click(object sender, EventArgs e)
        {
            timerZad1.Stop();
            txtZ1Wyniki.AppendText("Zad1 STOP\r\n");
        }

        // Timer Zad1
        private void TimerZad1_Tick(object sender, EventArgs e)
        {
            // Odczytujemy stan
            var st = (Zad1Stan)timerZad1.Tag;

            licznikIterZ1++;
            if (licznikIterZ1 > maxIterZ1)
            {
                // Koniec
                timerZad1.Stop();
                txtZ1Wyniki.AppendText("Koniec Zad1\r\n");
                return;
            }

            // Jedna iteracja
            bool[][] nowaPop = ga.IteracjaZad1(populacjaZ1, przystZ1, st.bity, st.turniej);
            populacjaZ1 = nowaPop;
            przystZ1 = ga.ObliczPrzystosowanieZad1(populacjaZ1, st.bity);

            // Wypis
            txtZ1Wyniki.AppendText($"Iter={licznikIterZ1}: Najl={Max(przystZ1):F4}, Sr={Avg(przystZ1):F4}\r\n");
        }

        // Klasa do zapisu stanu Zad1
        class Zad1Stan
        {
            public int bity;
            public int turniej;
        }


        // Zad2 Start
        private void BtnZ2Start_Click(object sender, EventArgs e)
        {
            txtZ2Wyniki.Clear();
            int pop = int.Parse(txtZ2Pop.Text);
            int bity = int.Parse(txtZ2Bits.Text);
            maxIterZ2 = int.Parse(txtZ2Iter.Text);
            int turniej = int.Parse(txtZ2Tourn.Text);

            populacjaZ2 = ga.InicjalizujZad2(pop, bity);
            przystZ2 = ga.ObliczPrzystosowanieZad2(populacjaZ2, bity);

            licznikIterZ2 = 0;
            txtZ2Wyniki.AppendText($"Start: Najl={Max(przystZ2):F4} Sr={Avg(przystZ2):F4}\r\n");

            timerZad2.Tag = new Zad2Stan { bity=bity, turniej=turniej };
            timerZad2.Start();
        }

        private void BtnZ2Stop_Click(object sender, EventArgs e)
        {
            timerZad2.Stop();
            txtZ2Wyniki.AppendText("Zad2 STOP\r\n");
        }

        private void TimerZad2_Tick(object sender, EventArgs e)
        {
            var st=(Zad2Stan) timerZad2.Tag;
            licznikIterZ2++;
            if(licznikIterZ2> maxIterZ2)
            {
                timerZad2.Stop();
                txtZ2Wyniki.AppendText("Koniec Zad2\r\n");
                return;
            }
            bool[][] nowa = ga.IteracjaZad2(populacjaZ2, przystZ2, st.bity, st.turniej);
            populacjaZ2= nowa;
            przystZ2= ga.ObliczPrzystosowanieZad2(populacjaZ2, st.bity);

            txtZ2Wyniki.AppendText($"Iter={licznikIterZ2}: Najl={Max(przystZ2):F4}, Sr={Avg(przystZ2):F4}\r\n");
        }

        class Zad2Stan
        {
            public int bity;
            public int turniej;
        }

        // Zad3 Start
        private void BtnZ3Start_Click(object sender, EventArgs e)
        {
            txtZ3Wyniki.Clear();
            int pop= int.Parse(txtZ3Pop.Text);
            int bity= int.Parse(txtZ3Bits.Text);
            maxIterZ3= int.Parse(txtZ3Iter.Text);
            int turniej= int.Parse(txtZ3Tourn.Text);

            populacjaZ3= ga.InicjalizujZad3(pop, bity);
            przystZ3= ga.ObliczPrzystosowanieZad3(populacjaZ3, bity);

            licznikIterZ3= 0;
            txtZ3Wyniki.AppendText($"Start: Najl={Max(przystZ3):F4} Sr={Avg(przystZ3):F4}\r\n");

            timerZad3.Tag= new Zad3Stan { bity=bity, turniej= turniej};
            timerZad3.Start();
        }

        private void BtnZ3Stop_Click(object sender, EventArgs e)
        {
            timerZad3.Stop();
            txtZ3Wyniki.AppendText("Zad3 STOP\r\n");
        }

        private void TimerZad3_Tick(object sender, EventArgs e)
        {
            var st=(Zad3Stan) timerZad3.Tag;
            licznikIterZ3++;
            if(licznikIterZ3> maxIterZ3)
            {
                timerZad3.Stop();
                txtZ3Wyniki.AppendText("Koniec Zad3\r\n");
                return;
            }
            bool[][] nowa= ga.IteracjaZad3(populacjaZ3, przystZ3, st.bity, st.turniej);
            populacjaZ3= nowa;
            przystZ3= ga.ObliczPrzystosowanieZad3(populacjaZ3, st.bity);

            txtZ3Wyniki.AppendText($"Iter={licznikIterZ3}: Najl={Max(przystZ3):F4}, Sr={Avg(przystZ3):F4}\r\n");
        }

        class Zad3Stan
        {
            public int bity;
            public int turniej;
        }

        // Pomocnicze metody do obliczania max i avg
        private double Max(double[] tab) => tab.Max();
        private double Avg(double[] tab) => tab.Average();
    }
}
