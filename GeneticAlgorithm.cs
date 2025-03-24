using System;
using System.Collections.Generic;
using System.Linq;

namespace DywanikReal
{
    public class GeneticAlgorithm
    {
        private Random rand = new Random();

        private int populationSize;      // rozmiar populacji
        private double mutationRate;     // szansa na mutację
        private double mutationStep;     // max zmiana x1,x2 w mutacji

        private List<(double x1, double x2)> population;
        private double[] fitness;

        public GeneticAlgorithm(int popSize, double mutRate, double mutStep)
        {
            populationSize = popSize;
            mutationRate = mutRate;
            mutationStep = mutStep;

            population = new List<(double, double)>(popSize);
            fitness = new double[popSize];

            // Losowe x1, x2 w [0..100]
            for (int i = 0; i < popSize; i++)
            {
                double x1 = rand.NextDouble() * 100.0;
                double x2 = rand.NextDouble() * 100.0;
                population.Add((x1, x2));
            }

            CalculateFitness();
        }

        // Funkcja celu: F(x1, x2)
        private double Evaluate(double x1, double x2)
        {
            return Math.Sin(0.05 * x1)
                 + Math.Sin(0.05 * x2)
                 + 0.4 * Math.Sin(0.15 * x1) * Math.Sin(0.15 * x2);
        }

        // Oblicz fitness calej populacji
        private void CalculateFitness()
        {
            for (int i = 0; i < populationSize; i++)
            {
                var (x1, x2) = population[i];
                fitness[i] = Evaluate(x1, x2);
            }
        }

        // 1 iteracja
        public void DoOneIteration()
        {
            var newPop = new List<(double, double)>(populationSize);

            // (popSize - 1) osobnikow -> selekcja + mutacja
            for (int i = 0; i < populationSize - 1; i++)
            {
                var child = TournamentSelect();
                if (rand.NextDouble() < mutationRate)
                    child = Mutate(child);
                newPop.Add(child);
            }

            //najlepszy osobnik ze starej populacji
            int bestI = BestIndex();
            newPop.Add(population[bestI]);

            population = newPop;
            CalculateFitness();
        }

        // Turniej (2 osobniki)
        private (double, double) TournamentSelect()
        {
            int i1 = rand.Next(populationSize);
            int i2 = rand.Next(populationSize);
            return (fitness[i1] > fitness[i2]) ? population[i1] : population[i2];
        }

        // Mutacja: perturbacja x1, x2 w mutationStep, ograniczona do [0..100]
        private (double, double) Mutate((double x1, double x2) parent)
        {
            double x1 = parent.x1;
            double x2 = parent.x2;

            double dx1 = (rand.NextDouble() * 2 - 1) * mutationStep;
            double dx2 = (rand.NextDouble() * 2 - 1) * mutationStep;

            x1 += dx1;
            x2 += dx2;

            if (x1 < 0) x1 = 0;
            if (x1 > 100) x1 = 100;
            if (x2 < 0) x2 = 0;
            if (x2 > 100) x2 = 100;

            return (x1, x2);
        }

        // Znajdź indeks osobnika o najwyższym fitness
        private int BestIndex()
        {
            double bestVal = double.MinValue;
            int best = 0;
            for (int i = 0; i < populationSize; i++)
            {
                if (fitness[i] > bestVal)
                {
                    bestVal = fitness[i];
                    best = i;
                }
            }
            return best;
        }

        // Zwroc (max) fitness
        public double BestFitness() => fitness.Max();

        // Zwroc sredni fitness
        public double AvgFitness() => fitness.Average();

        // Zwroc (x1, x2) najlepszego osobnika
        public (double x1, double x2) BestSolution()
        {
            return population[BestIndex()];
        }
    }
}
