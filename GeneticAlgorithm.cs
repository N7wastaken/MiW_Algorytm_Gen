using System;

namespace AlGen
{
    public class AlgorytmGenetyczny
    {
        private Random los = new Random();

        // ===============================================================
        // Zadanie 1 -> Dywanik
        // ===============================================================
        public bool[][] InicjalizujDywanik(int wielkoscPopulacji, int bityNaParametr)
        {
            bool[][] populacja = new bool[wielkoscPopulacji][];
            for (int i = 0; i < wielkoscPopulacji; i++)
            {
                bool[] osobnik = new bool[2 * bityNaParametr]; // x1 i x2
                for (int j = 0; j < osobnik.Length; j++)
                {
                    osobnik[j] = (los.NextDouble() < 0.5);
                }
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

                wyniki[i] = wartosc;  // Maksymalizujemy
            }
            return wyniki;
        }

        public bool[][] IteracjaDywanik(bool[][] staraPop, double[] starePrzyst, int bityNaParametr, int rozmiarTurnieju)
        {
            int n = staraPop.Length;
            bool[][] nowaPop = new bool[n][];

            // n - 1 -> selekcja turniejowa + mutacja
            for (int i = 0; i < n - 1; i++)
            {
                bool[] child = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                MutacjaJednopunktowa(child);
                nowaPop[i] = child;
            }
            // Elita (najlepszy osobnik)
            int najlepszyIdx = ZnajdzNajlepszy(starePrzyst);
            nowaPop[n - 1] = (bool[])staraPop[najlepszyIdx].Clone();

            return nowaPop;
        }

        // ===============================================================
        // Zadanie 2 -> Sinus (3 parametry pa, pb, pc w [0..3])
        // ===============================================================
        public bool[][] InicjalizujSinus(int wielkoscPop, int bityNaParametr)
        {
            int razemBitow = 3 * bityNaParametr;
            bool[][] populacja = new bool[wielkoscPop][];
            for (int i = 0; i < wielkoscPop; i++)
            {
                bool[] osobnik = new bool[razemBitow];
                for (int j = 0; j < razemBitow; j++)
                {
                    osobnik[j] = (los.NextDouble() < 0.5);
                }
                populacja[i] = osobnik;
            }
            return populacja;
        }

        // Przykładowa (skrócona) baza testowa:
        private double[] przykladoweX = { -1.0, -0.8, -0.6 };
        private double[] przykladoweY = {  0.59554, 0.58813, 0.64181 };

        public double[] ObliczPrzystosowanieSinus(bool[][] populacja, int bityNaParametr)
        {
            double[] fitness = new double[populacja.Length];
            for (int i = 0; i < populacja.Length; i++)
            {
                (double pa, double pb, double pc) =
                    DekodujTrzyParametry(populacja[i], bityNaParametr, 0, 3);

                // SSE (Sum of Squared Errors); minimalizujemy -> fitness = -SSE
                double sse = 0.0;
                for (int s = 0; s < przykladoweX.Length; s++)
                {
                    double x = przykladoweX[s];
                    double yTrue = przykladoweY[s];
                    double pred = pa * Math.Sin(x) + pb * x + pc;
                    double blad = yTrue - pred;
                    sse += blad * blad;
                }
                fitness[i] = -sse;
            }
            return fitness;
        }

        public bool[][] IteracjaSinus(bool[][] staraPop, double[] starePrzyst, int bityNaParametr, int rozmiarTurnieju)
        {
            int n = staraPop.Length; // np. 13
            bool[][] nowaPop = new bool[n][];

            // 4 crossing parami (0-1, 2-3)
            for (int i = 0; i < 4; i += 2)
            {
                bool[] p1 = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                bool[] p2 = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                (bool[] c1, bool[] c2) = KrzyzowanieJednopunktowe(p1, p2);
                nowaPop[i] = c1;
                nowaPop[i + 1] = c2;
            }

            // 4 mut (4..7)
            for (int i = 4; i < 8; i++)
            {
                bool[] child = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                MutacjaJednopunktowa(child);
                nowaPop[i] = child;
            }

            // 4 cross + mut (8..11)
            for (int i = 8; i < 12; i += 2)
            {
                bool[] p1 = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                bool[] p2 = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                (bool[] c1, bool[] c2) = KrzyzowanieJednopunktowe(p1, p2);
                MutacjaJednopunktowa(c1);
                MutacjaJednopunktowa(c2);
                nowaPop[i] = c1;
                nowaPop[i + 1] = c2;
            }

            // 1 elita (najlepszy)
            int best = ZnajdzNajlepszy(starePrzyst);
            nowaPop[12] = (bool[])staraPop[best].Clone();

            return nowaPop;
        }

        // ===============================================================
        // Zadanie 3 -> XOR (9 wag w [-10..10])
        // ===============================================================
        public bool[][] InicjalizujXOR(int wielkoscPop, int bityNaWage)
        {
            int razem = 9 * bityNaWage;
            bool[][] populacja = new bool[wielkoscPop][];
            for (int i = 0; i < wielkoscPop; i++)
            {
                bool[] chrom = new bool[razem];
                for (int j = 0; j < razem; j++)
                {
                    chrom[j] = (los.NextDouble() < 0.5);
                }
                populacja[i] = chrom;
            }
            return populacja;
        }

        private double[][] xorWejscia =
        {
            new double[]{0,0},
            new double[]{0,1},
            new double[]{1,0},
            new double[]{1,1}
        };
        private double[] xorOczekiwane = {0, 1, 1, 0};

        public double[] ObliczPrzystosowanieXOR(bool[][] populacja, int bityNaWage)
        {
            double[] fit = new double[populacja.Length];
            for (int i = 0; i < populacja.Length; i++)
            {
                double[] wagi = DekodujWagi(populacja[i], bityNaWage, 9, -10, 10);

                double sse = 0.0;
                for (int k = 0; k < 4; k++)
                {
                    double wy = PrzepuscXOR(xorWejscia[k][0], xorWejscia[k][1], wagi);
                    double blad = xorOczekiwane[k] - wy;
                    sse += blad * blad;
                }
                // minimalizacja SSE => fitness = -sse
                fit[i] = -sse;
            }
            return fit;
        }

        public bool[][] IteracjaXOR(bool[][] staraPop, double[] starePrzyst, int bityNaWage, int rozmiarTurnieju)
        {
            int n = staraPop.Length;
            bool[][] nowaPop = new bool[n][];

            // 4 crossing (0-1, 2-3)
            for (int i = 0; i < 4; i += 2)
            {
                bool[] p1 = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                bool[] p2 = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                (bool[] c1, bool[] c2) = KrzyzowanieJednopunktowe(p1, p2);
                nowaPop[i] = c1;
                nowaPop[i + 1] = c2;
            }

            // 4 mut (4..7)
            for (int i = 4; i < 8; i++)
            {
                bool[] child = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                MutacjaJednopunktowa(child);
                nowaPop[i] = child;
            }

            // 4 cross+mut (8..11)
            for (int i = 8; i < 12; i += 2)
            {
                bool[] p1 = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                bool[] p2 = SelekcjaTurniejowa(staraPop, starePrzyst, rozmiarTurnieju);
                (bool[] c1, bool[] c2) = KrzyzowanieJednopunktowe(p1, p2);
                MutacjaJednopunktowa(c1);
                MutacjaJednopunktowa(c2);
                nowaPop[i] = c1;
                nowaPop[i + 1] = c2;
            }

            // 1 elita
            int najlepszy = ZnajdzNajlepszy(starePrzyst);
            nowaPop[12] = (bool[])staraPop[najlepszy].Clone();

            return nowaPop;
        }

        // ===============================================================
        // Uniwersalne operatory / funkcje pomocnicze
        // ===============================================================
        private bool[] SelekcjaTurniejowa(bool[][] populacja, double[] przystosowanie, int k)
        {
            double najlepsze = double.MinValue;
            bool[] wybrany = null;
            int n = populacja.Length;
            for (int i = 0; i < k; i++)
            {
                int idx = los.Next(n);
                if (przystosowanie[idx] > najlepsze)
                {
                    najlepsze = przystosowanie[idx];
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
            int punkt = los.Next(osobnik.Length);
            osobnik[punkt] = !osobnik[punkt];
        }

        private (bool[], bool[]) KrzyzowanieJednopunktowe(bool[] p1, bool[] p2)
        {
            int dl = p1.Length;
            int punkt = los.Next(1, dl);
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

        // Dekodowanie parametru x1, x2
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

        // Dekodowanie 3 parametrów (sinus)
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
            {
                wart = (wart << 1) | (bity[start + i] ? 1 : 0);
            }
            int maks = (1 << dlugosc) - 1;
            return mn + (mx - mn) * wart / maks;
        }

        // Dekodowanie wag do XOR
        public double[] DekodujWagi(bool[] bity, int bpp, int ile, double minW, double maxW)
        {
            double[] wagi = new double[ile];
            for (int i = 0; i < ile; i++)
            {
                wagi[i] = DekodujJeden(bity, i * bpp, bpp, minW, maxW);
            }
            return wagi;
        }

        // Prosty XOR: 3 neurony, każdy ma 3 wagi (x1, x2, bias).
        // Sygmoida -> n1,n2,n3 -> zsumowane, jeśli >1.5 => 1
        private double PrzepuscXOR(double x1, double x2, double[] w)
        {
            double n1 = 1.0 / (1.0 + Math.Exp(-(x1 * w[0] + x2 * w[1] + w[2])));
            double n2 = 1.0 / (1.0 + Math.Exp(-(x1 * w[3] + x2 * w[4] + w[5])));
            double n3 = 1.0 / (1.0 + Math.Exp(-(x1 * w[6] + x2 * w[7] + w[8])));
            double suma = n1 + n2 + n3;
            return (suma > 1.5) ? 1.0 : 0.0;
        }
    }
}
