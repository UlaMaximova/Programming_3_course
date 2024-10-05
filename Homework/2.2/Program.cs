using System;

class Program
{
    static void Main(string[] args)
    {
        // Массив для хранения 10 введенных чисел
        int[] numbers = new int[10];

        // Запрашиваем у пользователя ввод 10 различных чисел
        Console.WriteLine("Введите 10 различных чисел:");

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Введите число {i + 1}: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        // Находим наибольшее и следующее по величине число
        int max1 = int.MinValue; // Наибольшее число
        int max2 = int.MinValue; // Следующее по величине число

        foreach (int number in numbers)
        {
            if (number > max1)
            {
                max2 = max1; // Предыдущее наибольшее становится вторым по величине
                max1 = number; // Текущее число становится наибольшим
            }
            else if (number > max2)
            {
                max2 = number; // Текущее число становится вторым по величине
            }
        }

        // Выводим результаты
        Console.WriteLine($"Наибольшее число: {max1}");
        Console.WriteLine($"Следующее по величине число: {max2}");
    }
}