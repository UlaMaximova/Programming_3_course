using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите число:");
        string input = Console.ReadLine();

        try
        {
            ValidateInput(input);
            Console.WriteLine("Число корректно!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void ValidateInput(string input)
    {
        // Используем decimal для работы с большим диапазоном значений
        if (!decimal.TryParse(input, out decimal number))
            throw new Exception("Введено не число.");

        // Проверяем, входит ли число в диапазон int
        if (number > int.MaxValue)
            throw new Exception("Введено слишком большое число.");

        if (number < int.MinValue)
            throw new Exception("Введено слишком маленькое число.");
    }
}
