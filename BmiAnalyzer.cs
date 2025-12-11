using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4dd
{
    internal class BmiAnalyzer
    {
        private double[] bmiMeasurement = new double [10];
        private double[] weights = new double [10];
        private double[] heights = new double [10];
        private string[] genders = new string [10];
        private int[] ages = new int [10];
        private string[] categories = new string [10];
        private DateTime[] measurementDates = new DateTime [10];
        private int currentIndex = 0;

        internal void AddMeasurement(double bmi, double w, double h, string g, int a, string cat, DateTime md, int ci)
        {
            if (ci < 10)
            {
                heights[ci] = h;
                weights[ci] = w;
                genders[ci] = g;
                ages[ci] = a;
                bmiMeasurement[ci] = bmi;
                categories[ci] = cat;
                measurementDates[ci] = md;
                this.currentIndex++;
            }
            else
            {
                heights[ci-10] = h;
                weights[ci-10] = w;
                genders[ci - 10] = g;
                ages[ci - 10] = a;
                bmiMeasurement[ci - 10] = bmi;
                categories[ci - 10] = cat;
                measurementDates[ci - 10] = md;
                this.currentIndex -= 10;
            }
        }

        internal void ShowHistory()
        {
            Console.Clear();
            Console.WriteLine("===История замеров===");
            for (int i = 0; i < bmiMeasurement.Length && i < this.currentIndex; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Вес: {weights[i]}\nРост: {heights[i]}\nПол: {genders[i]}\nВозраст: {ages[i]}\nИМТ: {bmiMeasurement[i]}\nДата: {measurementDates[i]}\n");
                Console.ResetColor();
            }
        }

        internal void AnalyzeTrends()
        {
            Console.Clear();
            double bmiCompare = CompareMeasurements(bmiMeasurement[0], bmiMeasurement[9]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Динамика показателей ===\n");
            Console.WriteLine($"Период: {measurementDates[0]} - {measurementDates[9]}\n");
            Console.WriteLine($"Изменение ИМТ: {bmiCompare} ({bmiMeasurement[0]} → {bmiMeasurement[9]})\n");
            Console.ResetColor();
        }

        private double CompareMeasurements(double a, double b)
        {
            return b - a;
        }
    }
}
