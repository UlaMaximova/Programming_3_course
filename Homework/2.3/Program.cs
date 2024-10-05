using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите число n: ");
        int n = int.Parse(Console.ReadLine());

        int steps = CollatzSteps(n);
        Console.WriteLine($"Число замен, приводящих к 1: {steps}");
    }

    // Функция для подсчета числа шагов, приводящих к 1
    static int CollatzSteps(int n)
    {
        int count = 0;

        while (n != 1)
        {
            if (n % 2 == 0)
            {
                n /= 2;  // Если число четное, делим на 2
            }
            else
            {
                n = 3 * n + 1;  // Если число нечетное, умножаем на 3 и прибавляем 1
            }

            count++;  // Увеличиваем счетчик шагов
        }

        return count;
    }
}