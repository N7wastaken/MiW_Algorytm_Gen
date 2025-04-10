using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace AlGen
{
    public class AlgorytmGenetyczny
    {
        private Random rnd = new Random();

        // =======================================================================
        // POLA DO DANYCH (zadanie 2: SINUS)
        // =======================================================================
        private List<double> sinusX = new List<double>();
        private List<double> sinusY = new List<double>();


        public void ZaladujDaneSinus(string sciezkaPliku)
        {
            sinusX.Clear();
            sinusY.Clear();

            string[] linie = File.ReadAllLines(sciezkaPliku);
            foreach (string linia in linie)
            {
                var tokens = linia.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 2) continue;

                double xVal = double.Parse(tokens[0], CultureInfo.InvariantCulture);
                double yVal = double.Parse(tokens[1], CultureInfo.InvariantCulture);

                sinusX.Add(xVal);
                sinusY.Add(yVal);
            }
        }

        // ===============================================================
        // Zadanie 1 (Dywanik)
        // ===============================================================
        public bool[][] InicjalizujDywanik(int rozmiarPopulacji, int bityNaParametr)
        {
            bool[][] populacja = new bool[rozmiarPopulacji][];
            for (int i = 0; i < rozmiarPopulacji; i++)
            {
                bool[] osobnik = new bool[2 * bityNaParametr];
                for (int j = 0; j < osobnik.Length; j++)
                    osobnik[j] = (rnd.NextDouble() < 0.5);

                populacja[i] = osobnik;
            }
            return populacja;
        }

        public double[] ObliczPrzystosowanieDywanik(bool[][] populacja, int bityNaParametr)
        {
            double[] wyniki = new double[populacja.Length];
            for (int i = 0; i < populacja.Length; i++)
            {
                (double x1, double x2) = DekodujDwaParametry(populacja[i], bityNaParametr, 0, 100);

                // F(x1,x2) = sin(0.05*x1) + sin(0.05*x2) + 0.4*sin(0.15*x1)*sin(0.15*x2)
                double wartosc =
                      Math.Sin(0.05 * x1)
                    + Math.Sin(0.05 * x2)
                    + 0.4 * Math.Sin(0.15 * x1) * Math.Sin(0.15 * x2);

                // maksymalizacja
                wyniki[i] = wartosc;
            }
            return wyniki;
        }

        public bool[][] IteracjaDywanik(bool[][] staraPop, double[] starePrzyst, int bityNaParametr, int turniej)
        {
            int n = staraPop.Length;
            bool[][] nowaPop = new bool[n][];

            // n - 1 -> selekcja turniejowa + mutacja
            for (int i = 0; i < n - 1; i++)
            {
                bool[] child = SelekcjaTurniejowa(staraPop, starePrzyst, turniej);
                MutacjaJednopunktowa(child);
                nowaPop[i] = child;
            }

            // Elita
            int bestIdx = ZnajdzNajlepszy(starePrzyst);
            nowaPop[n - 1] = (bool[])staraPop[bestIdx].Clone();

            return nowaPop;
        }

        // ===============================================================
        // Zadanie 2 (Sinus)
        // ===============================================================
        public bool[][] InicjalizujSinus(int rozmiarPop, int bityNaParametr)
        {
            int razemBitow = 3 * bityNaParametr;
            bool[][] populacja = new bool[rozmiarPop][];
            for (int i = 0; i < rozmiarPop; i++)
            {
                bool[] osobnik = new bool[razemBitow];
                for (int j = 0; j < razemBitow; j++)
                    osobnik[j] = (rnd.NextDouble() < 0.5);

                populacja[i] = osobnik;
            }
            return populacja;
        }


        public double[] ObliczPrzystosowanieSinus(bool[][] populacja, int bityNaParametr)
        {
            double[] fitness = new double[populacja.Length];

            for (int i = 0; i < populacja.Length; i++)
            {
                (double pa, double pb, double pc) = DekodujTrzyParametry(populacja[i], bityNaParametr, 0, 3);

                double sse = 0.0;
                for (int s = 0; s < sinusX.Count; s++)
                {
                    double x = sinusX[s];
                    double yTrue = sinusY[s];
                    double pred = pa * Math.Sin(pb * x + pc);
                    double blad = yTrue - pred;
                    sse += blad * blad;
                }
                fitness[i] = -sse;
            }
            return fitness;
        }

        public bool[][] IteracjaSinus(bool[][] staraPop, double[] starePrzyst, int bityNaParametr, int turniej)
        {
            int n = staraPop.Length;
            bool[][] nowaPop = new bool[n][];

            // 4 crossing (parami)
            for (int i = 0; i < 4; i += 2)
            {
                bool[] p1 = SelekcjaTurniejowa(staraPop, starePrzyst, turniej);
                bool[] p2 = SelekcjaTurniejowa(staraPop, starePrzyst, turniej);
                (bool[] c1, bool[] c2) = KrzyzowanieJednopunktowe(p1, p2);
                nowaPop[i] = c1;
                nowaPop[i + 1] = c2;
            }

            // 4 mutacje (4..7)
            for (int i = 4; i < 8; i++)
            {
                bool[] child = SelekcjaTurniejowa(staraPop, starePrzyst, turniej);
                MutacjaJednopunktowa(child);
                nowaPop[i] = child;
            }

            // 4 crossing + mutacja (8..11)
            for (int i = 8; i < 12; i += 2)
            {
                bool[] p1 = SelekcjaTurniejowa(staraPop, starePrzyst, turniej);
                bool[] p2 = SelekcjaTurniejowa(staraPop, starePrzyst, turniej);
                (bool[] c1, bool[] c2) = KrzyzowanieJednopunktowe(p1, p2);
                MutacjaJednopunktowa(c1);
                MutacjaJednopunktowa(c2);
                nowaPop[i] = c1;
                nowaPop[i + 1] = c2;
            }

            // elita
            int best = ZnajdzNajlepszy(starePrzyst);
            nowaPop[12] = (bool[])staraPop[best].Clone();

            return nowaPop;
        }

        // ===============================================================
        // Zadanie 3 (XOR)
        // ===============================================================
        public bool[][] InicjalizujXOR(int rozmiarPop, int bityNaWage)
        {
            // 9 wag (3 neurony * 3 wagi na neuron)
            int dl = 9 * bityNaWage;
            bool[][] populacja = new bool[rozmiarPop][];
            for (int i = 0; i < rozmiarPop; i++)
            {
                bool[] chrom = new bool[dl];
                for (int j = 0; j < dl; j++)
                    chrom[j] = (rnd.NextDouble() < 0.5);

                populacja[i] = chrom;
            }
            return populacja;
        }

        // Cztery próbki do XOR
        private double[][] xorWejscia =
        {
            new double[]{0,0},
            new double[]{0,1},
            new double[]{1,0},
            new double[]{1,1}
        };
        private double[] xorOczekiwane = { 0, 1, 1, 0 };

        public double[] ObliczPrzystosowanieXOR(bool[][] populacja, int bityNaWage)
        {
            double[] fit = new double[populacja.Length];
            for (int i = 0; i < populacja.Length; i++)
            {
                // dekodujemy 9 wag do tablicy wagi[]
                double[] wagi = DekodujWagi(populacja[i], bityNaWage, 9, -10, 10);

                double sse = 0.0;

                for (int k = 0; k < 4; k++)
                {
                    double wy = PrzepuscXOR(xorWejscia[k][0], xorWejscia[k][1], wagi);
                    double blad = xorOczekiwane[k] - wy;
                    sse += blad * blad;
                }

                fit[i] = -sse; // im mniejsze SSE, tym lepiej (dlatego minus)
            }
            return fit;
        }

        public bool[][] IteracjaXOR(bool[][] populacja, double[] przystosowanie, int bityNaWage, int rozmiarTurnieju)
        {
            int rozmiarPopulacji = populacja.Length;


            // Tworzymy nową populację
            bool[][] nowaPopulacja = new bool[rozmiarPopulacji][];

            // 1) Elitaryzm – zachowujemy najlepszego osobnika
            int najlepszyIndeks = ZnajdzNajlepszy(przystosowanie);
            nowaPopulacja[0] = (bool[])populacja[najlepszyIndeks].Clone();

            for (int i = 1; i < rozmiarPopulacji; i += 2)
            {
                // Wybór rodziców (selekcja turniejowa)
                bool[] rodzic1 = SelekcjaTurniejowa(populacja, przystosowanie, rozmiarTurnieju);
                bool[] rodzic2 = SelekcjaTurniejowa(populacja, przystosowanie, rozmiarTurnieju);

                // Krzyżowanie jednopunktowe
                (bool[] dziecko1, bool[] dziecko2) = KrzyzowanieJednopunktowe(rodzic1, rodzic2);

                // Mutacja jednopunktowa
                MutacjaJednopunktowa(dziecko1);
                MutacjaJednopunktowa(dziecko2);

                // Dodanie dzieci do nowej populacji
                if (i < rozmiarPopulacji - 1)
                {
                    nowaPopulacja[i] = dziecko1;
                    nowaPopulacja[i + 1] = dziecko2;
                }
                else
                {
                    // Jeśli rozmiar populacji jest nieparzysty, 
                    // wstawiamy tylko dziecko1 na ostatnie miejsce
                    nowaPopulacja[i] = dziecko1;
                }
            }

            // 3) Zamiana starej populacji na nową
            populacja = nowaPopulacja;

            // 4) Obliczanie przystosowania (fitness) w nowej populacji
            przystosowanie = ObliczPrzystosowanieXOR(populacja, bityNaWage);

            return populacja;
        }

        // ====================================================================
        // Metody wspólne
        // ====================================================================
        private bool[] SelekcjaTurniejowa(bool[][] populacja, double[] przyst, int rozmiarTurnieju)
        {
            double najlepszy = double.MinValue;
            bool[] wybrany = null;
            int n = populacja.Length;

            for (int i = 0; i < rozmiarTurnieju; i++)
            {
                int idx = rnd.Next(n);
                if (przyst[idx] > najlepszy)
                {
                    najlepszy = przyst[idx];
                    wybrany = populacja[idx];
                }
            }
            return (bool[])wybrany.Clone();
        }

        public int ZnajdzNajlepszy(double[] przyst)
        {
            double maxVal = double.MinValue;
            int best = 0;
            for (int i = 0; i < przyst.Length; i++)
            {
                if (przyst[i] > maxVal)
                {
                    maxVal = przyst[i];
                    best = i;
                }
            }
            return best;
        }

        private void MutacjaJednopunktowa(bool[] osobnik)
        {
            int punkt = rnd.Next(osobnik.Length);
            osobnik[punkt] = !osobnik[punkt];
        }

        private (bool[], bool[]) KrzyzowanieJednopunktowe(bool[] p1, bool[] p2)
        {
            int dl = p1.Length;
            int punkt = rnd.Next(1, dl);
            bool[] c1 = new bool[dl];
            bool[] c2 = new bool[dl];

            for (int i = 0; i < punkt; i++)
            {
                c1[i] = p1[i];
                c2[i] = p2[i];
            }
            for (int i = punkt; i < dl; i++)
            {
                c1[i] = p2[i];
                c2[i] = p1[i];
            }
            return (c1, c2);
        }

        // -------------------------
        // Dekodowanie parametrów
        // -------------------------
        public (double, double) DekodujDwaParametry(bool[] bity, int bpp, double minVal, double maxVal)
        {
            int wart1 = 0, wart2 = 0;
            for (int i = 0; i < bpp; i++)
            {
                wart1 = (wart1 << 1) | (bity[i] ? 1 : 0);
                wart2 = (wart2 << 1) | (bity[bpp + i] ? 1 : 0);
            }
            int maxKod = (1 << bpp) - 1;
            double x1 = minVal + (maxVal - minVal) * wart1 / maxKod;
            double x2 = minVal + (maxVal - minVal) * wart2 / maxKod;
            return (x1, x2);
        }

        public (double, double, double) DekodujTrzyParametry(bool[] bity, int bpp, double minV, double maxV)
        {
            double p1 = DekodujJeden(bity, 0, bpp, minV, maxV);
            double p2 = DekodujJeden(bity, bpp, bpp, minV, maxV);
            double p3 = DekodujJeden(bity, 2 * bpp, bpp, minV, maxV);
            return (p1, p2, p3);
        }

        private double DekodujJeden(bool[] bity, int start, int dlugosc, double mn, double mx)
        {
            int wart = 0;
            for (int i = 0; i < dlugosc; i++)
                wart = (wart << 1) | (bity[start + i] ? 1 : 0);

            int maks = (1 << dlugosc) - 1;
            return mn + (mx - mn) * wart / maks;
        }

        // Dekodowanie tablicy wag (np. 9 wag w [-10..10])
        public double[] DekodujWagi(bool[] bity, int bpp, int ile, double minW, double maxW)
        {
            double[] wagi = new double[ile];
            for (int i = 0; i < ile; i++)
                wagi[i] = DekodujJeden(bity, i * bpp, bpp, minW, maxW);

            return wagi;
        }

        // -------------------------
        // Forward pass dla XOR
        // -------------------------
        private double PrzepuscXOR(double x1, double x2, double[] w)
        {
            // Warstwa ukryta (2 neurony)
            double h1 = Sigmoid(x1 * w[0] + x2 * w[1] + w[2]); // neuron 1
            double h2 = Sigmoid(x1 * w[3] + x2 * w[4] + w[5]); // neuron 2

            // Warstwa wyjściowa (1 neuron)
            double output = Sigmoid(h1 * w[6] + h2 * w[7] + w[8]);

            return output;
        }

        private double Sigmoid(double s)
        {
            return 1.0 / (1.0 + Math.Exp(-s));
        }
    }
}
