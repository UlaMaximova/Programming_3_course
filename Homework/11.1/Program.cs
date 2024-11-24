using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Указываем путь к файлу
        string filePath = "f.txt";

        // Открываем поток для записи в файл
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Записываем заголовок
            writer.WriteLine("x sin(x)");

            // Цикл для вычисления sin(x) для x от 0 до 1 с шагом 0.1
            for (double x = 0; x <= 1; x += 0.1)
            {
                // Записываем значение x и sin(x) в файл
                writer.WriteLine($"{x:F1} {Math.Sin(x):F4}");
            }
        }

        Console.WriteLine("Таблица успешно записана в файл f.txt");
    }
}
