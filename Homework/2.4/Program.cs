using System;

class Program
{
    static void Main(string[] args)
    {
        // Запрос у пользователя длины массива
        Console.Write("Введите размер массива: ");
        int n = int.Parse(Console.ReadLine());

        // Инициализация массива
        int[] arr = new int[n];

        // Ввод элементов массива пользователем
        Console.WriteLine($"Введите {n} чисел:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Элемент {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Исходный массив
        Console.WriteLine("Исходный массив:");
        PrintArray(arr);

        // Вызов функции пузырьковой сортировки
        BubbleSort(arr);

        // Отсортированный массив
        Console.WriteLine("Отсортированный массив:");
        PrintArray(arr);
    }

    // Функция пузырьковой сортировки
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;

        // Выполняем n-1 проход по массиву
        for (int i = 0; i < n - 1; i++)
        {
            // Последние i элементов уже отсортированы, их можно не проверять
            for (int j = 0; j < n - i - 1; j++)
            {
                // Если текущий элемент больше следующего, меняем их местами
                if (arr[j] > arr[j + 1])
                {
                    // Обмен элементов
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Вспомогательная функция для вывода массива
    static void PrintArray(int[] arr)
    {
        foreach (int element in arr)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
