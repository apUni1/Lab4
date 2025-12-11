using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4dd
{
    public static class InputControl
    {
        public static double UserAnswer(string keyword, string phrase, int minLine, int maxLine)
        {
            bool error = false;
            bool run = true;
            double res = 0;
            while (run)
            {
                Console.Write(phrase);
                
                switch (keyword)
                {
                    case "weight":
                        int weight = 0;
                        if (int.TryParse(Console.ReadLine(), out weight) && minLine <= weight && weight <= maxLine)
                        {
                            res = weight;
                            run = false;
                        }
                        else
                        {
                            error = true;
                        }
                        break;

                    case "height":
                        string heightS = Console.ReadLine();
                        bool parsed = double.TryParse(heightS, out double height);
                        bool parsCm = int.TryParse(heightS, out int heightCm);
                        if (parsCm)
                        {
                            double typeChangeHeight = heightCm;
                            height = typeChangeHeight / 100;
                        }
                        if (parsed && minLine <= height && height <= maxLine)
                        {
                            res = height;
                            run = false;
                        }
                        else
                        {
                            error = true;
                        }
                        break;

                    case "choice":
                        string choiceS = Console.ReadLine();
                        string[] choices = { "1", "2", "3", "4" };
                        if (Array.IndexOf(choices, choiceS) > -1)
                        {
                            int choice = int.Parse(choiceS);
                            res = choice;
                            run = false;
                        }
                        else
                        {
                            error = true;
                        }
                        break;

                    case "endChoice":
                        string endChoiceS = Console.ReadLine();
                        string[] endChoices = { "1", "2" };
                        if (Array.IndexOf(endChoices, endChoiceS) > -1)
                        {
                            int endChoice = int.Parse(endChoiceS);
                            res = endChoice;
                            run = false;
                        }
                        else
                        {
                            error = true;
                        }
                        break;

                }
                if (error)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные введены неверно. Попробуйте ещё раз.");
                    Console.ResetColor();
                }

            }

            return res;
        }

        public static string getGender()
        {
            string gender = "";
            bool stop = false;
            while (!stop)
            {
                Console.Write("Укажите пол (м/ж): ");
                gender = Console.ReadLine();
                if (gender == "м" || gender == "ж")
                {
                    stop = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные введены неверно. Попробуйте ещё раз.");
                    Console.ResetColor();
                }
            }
            return gender;
        }

        public static int getAge()
        {
            int age = 0;
            bool stop = false;
            while (!stop)
            {
                Console.Write("Укажите возраст: ");
                string ageS = Console.ReadLine();
                bool parsed = int.TryParse(ageS, out age);
                if (parsed && (age >= 1) && (age <= 120)) stop = true;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные введены неверно. Попробуйте ещё раз.");
                    Console.ResetColor();
                }
            }
            return age;
        }
    }
}
