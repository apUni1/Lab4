using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security;

namespace Lab4dd
{
    public class Program
    {

        static void Main()
        {
            BmiMeasurement measurement = new BmiMeasurement();
            BmiAnalyzer analyzer = new BmiAnalyzer();
            int count = 0;
            bool run = true;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=== Лабораторная работа 4 ===");
            Console.WriteLine("Вариант 4: индекс массы тела\n");
            Console.ResetColor();
            while (run)
            {
                double choice = MainMenu();
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        measurement.Weight = InputControl.UserAnswer("weight", "Введите вес (кг): ", 30, 300);
                        measurement.Height = InputControl.UserAnswer("height", "Введите рост (в метрах или сантиметрах, например 1,75 или 175): ", 1, 3); ;
                        measurement.Gender = InputControl.getGender();
                        measurement.Age = InputControl.getAge();
                        measurement.BmiValue = Math.Round(measurement.CalculateBmi(measurement.Weight, measurement.Height), 1);
                        measurement.MeasurementDate = DateTime.Today;
                        measurement.Category = measurement.DetermineCategory(measurement.BmiValue);
                        analyzer.AddMeasurement(measurement.BmiValue, measurement.Weight, measurement.Height, measurement.Gender, measurement.Age, measurement.Category, measurement.MeasurementDate, count);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n=== Результаты ===\n");
                        Console.ResetColor();
                        Console.WriteLine($"Ваш ИМТ: {measurement.BmiValue}");
                        Console.WriteLine($"Категория: {measurement.Category}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nПРИМЕЧАНИЕ: формула наиболее точна для людей до 40-45 лет.\nОна не учитывает телосложение, процент мышечной массы и жировых отложений.\nФормула не подходит для спортсменов, бодибилдеров, беременных женщин и лиц моложе 18 лет.\nДля получения точного и подробного результата обратитесь к специалисту.");
                        Console.ResetColor();
                        break;
                    case 2:
                        analyzer.ShowHistory();
                        break;
                    case 3:
                        analyzer.AnalyzeTrends();
                        break;
                    case 4:
                        return;



                }
                double nextChoice = EndMenu();
                if (nextChoice == 2) run = false;
                else
                {
                    Console.Clear();
                    continue;
                }
            }
        }

        private static double MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=== Анализатор ИМТ ===");
            Console.ResetColor();
            Console.WriteLine("1. Новый расчёт\n2. История замеров\n3. Анализ динамики\n4. Выйти");
            return InputControl.UserAnswer("choice", "\nВыберите операцию: ", 0, 0);
        }

        private static double EndMenu()
        {
            Console.WriteLine("\n1. Вернуться в главное меню\n2. Выход");
            return InputControl.UserAnswer("endChoice", "\nВыберите операцию: ", 0, 0);
        }

        


    }
}
