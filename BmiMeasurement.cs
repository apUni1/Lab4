using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4dd
{
    internal class BmiMeasurement
    {
        private double weight = 30;
        private double height = 1.0;
        private string gender = "";
        private int age = 1;
        private double bmiValue = 0;
        private string category = "";
        private DateTime measurementDate;
        public double Weight 
        {
            get { return weight; }
            set 
            {
                if ((value < 30) || (value > 300))
                {
                    Console.WriteLine("Данные введены неверно. Попробуйте ещё раз.");
                }
                else weight = value; 
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if ((value < 1.0) || (value > 2.5))
                {
                    Console.WriteLine("Данные введены неверно. Попробуйте ещё раз.");
                }
                else weight = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                if ((value != "м") || (value != "ж"))
                {
                    Console.WriteLine("Данные введены неверно. Попробуйте ещё раз.");
                }
                else gender = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if ((value < 1) || (value > 120))
                {
                    Console.WriteLine("Данные введены неверно. Попробуйте ещё раз.");
                }
                else weight = value;
            }
        }

        public double BmiValue
        {
            get { return bmiValue; }
            set {bmiValue = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public DateTime MeasurementDate
        {
            get { return measurementDate; }
            set { measurementDate = value; }
        }

        internal double CalculateBmi(double w, double h)
        {
            double bmi = w / Math.Pow(h, 2);
            return bmi;
        }

        internal string DetermineCategory(double bmi)
        {
            bool rang1 = bmi <= 16;
            bool rang2 = bmi <= 18.5;
            bool rang3 = bmi <= 25;
            bool rang4 = bmi <= 30;
            bool rang5 = bmi <= 35;
            bool rang6 = bmi <= 40;
            bool rang7 = bmi > 40;

            bool[] rangs = { rang1, rang2, rang3, rang4, rang5, rang6, rang7 };
            string[] results = { "Выраженный дефицит массы", "Дефицит массы тела", "Норма", "Избыточная масса тела", "Ожирение первой степени", "Ожирение второй степени", "Ожирение третьей степени" };
            string resCategory = "";
            for (int i = 0; i < results.Length; i++)
            {
                if (rangs[i])
                {
                    resCategory = results[i];
                    break;
                }

            }
            return resCategory;
        }

        private void PrintReport(double bmi, string rc)
        {
            Console.WriteLine($"Ваш ИМТ:{Math.Round(bmi, 2)} ({rc})");
        }



    }
}
