using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите натуральное число: ");
        int number;

        // Проверяем, что пользователь ввёл корректное число
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.WriteLine("Ошибка! Введите корректное натуральное число.");
        }

        string romanNumeral = IntToRoman(number);
        Console.WriteLine($"Число {number} в римских цифрах: {romanNumeral}");
    }

    static string IntToRoman(int num)
    {
        // Массивы с римскими цифрами и их соответствиями
        string[] romanNumerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        string result = "";

        // Проходим по каждому значению и добавляем соответствующую римскую цифру
        for (int i = 0; i < values.Length; i++)
        {
            while (num >= values[i])
            {
                num -= values[i];
                result += romanNumerals[i];
            }
        }

        return result;
    }
}