using System;

namespace EquazioneSecondoGrado
{
    public class Program
    {
        private const string FormatMessage = "Enter coefficients of a second degree equation of the type 'aX\u00b2 + bX + c = 0'";
        private const double DefaultA = 5;
        private const double DefaultB = 0;
        private const double DefaultC = 0;

        public static (double a, double b, double c) Input()
        {
            Console.WriteLine(FormatMessage);
            string equation = Console.ReadLine();
            string[] coefficients = equation.Split(' ');

            if (coefficients.Length != 3 ||
                !double.TryParse(coefficients[0], out double a) ||
                !double.TryParse(coefficients[1], out double b) ||
                !double.TryParse(coefficients[2], out double c))
            {
                Console.WriteLine("Invalid input. Please provide three valid coefficients.");
                Environment.Exit(1);
            }

            return (a, b, c);
        }

        public static (double x1, double x2) Processing(double a, double b, double c)
        {
            double delta = b * b - 4 * a * c;
            if (delta > 0)
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                return (x1, x2); 
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                return (x, x); 
            }
            else
                throw new ArgumentException("No real solutions.");
        }

        static bool TestProcessing(double a, double b, double c, double expected_1, double expected_2)
        {
            Console.WriteLine($"Test for equation '{a}X\u00b2 + {b}X + {c} = 0'");
            Console.WriteLine($"Expected outcome: x1 = {expected_1}, x2 = {expected_2}");

            try
            {
                var solutions = Processing(a, b, c);
                return Math.Abs(solutions.x1 - expected_1) < 1e-6 && Math.Abs(solutions.x2 - expected_2) < 1e-6;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public static void Main(string[] args)
        {
            double expected_1 = 0, expected_2 = 0;
            string testResult = TestProcessing(DefaultA, DefaultB, DefaultC, expected_1, expected_2) ? "GREEN" : "RED";
            Console.WriteLine($"Test Result: {testResult}");
        }
    }
}
