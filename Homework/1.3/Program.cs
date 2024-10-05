using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите коэффициенты a, b и c для уравнения ax^2 + bx + c = 0");

        Console.Write("Введите a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введите b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Введите c: ");
        double c = double.Parse(Console.ReadLine());

        SolveEquation(a, b, c);
    }

    static void SolveEquation(double a, double b, double c)
    {
        if (a == 0)
        {
            // Линейное уравнение bx + c = 0
            if (b == 0)
            {
                if (c == 0)
                {
                    Console.WriteLine("Уравнение имеет бесконечно много решений.");
                }
                else
                {
                    Console.WriteLine("Уравнение не имеет решений.");
                }
            }
            else
            {
                double x = -c / b;
                Console.WriteLine($"Линейное уравнение имеет одно решение: x = {x}");
            }
        }
        else
        {
            // Квадратное уравнение ax^2 + bx + c = 0
            double discriminant = b * b - 4 * a * c;
            Console.WriteLine($"Дискриминант: {discriminant}");

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine($"Уравнение имеет два решения: x1 = {x1}, x2 = {x2}");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Уравнение имеет одно решение: x = {x}");
            }
            else
            {
                Console.WriteLine("Уравнение не имеет действительных решений.");
            }
        }
    }
}
