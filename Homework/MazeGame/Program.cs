using System;
using System.Collections.Generic;

class Program
{
    static char[,] maze; // Лабиринт
    static int playerX, playerY; // Позиция игрока
    static int width = 20; // Ширина лабиринта
    static int height = 10; // Высота лабиринта

    static void Main()
    {
        GenerateMaze(); // Генерация лабиринта
        PrintMaze(); // Печать лабиринта
        Play(); // Игровой процесс
    }

    // Генерация лабиринта с гарантированным путем
    static void GenerateMaze()
    {
        maze = new char[height, width];
        Random rand = new Random();

        // Заполняем лабиринт стенами по краям
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    maze[y, x] = 'X'; // Границы лабиринта
                else
                    maze[y, x] = ' '; // Пустое пространство
            }
        }

        // Стартовая точка
        playerX = 1;
        playerY = 1;
        maze[playerY, playerX] = 'S'; // Символ старта

        // Выход (дыра в одном из краев)
        int exitEdge = rand.Next(4); // Случайный край
        int exitX = 0, exitY = 0;

        if (exitEdge == 0) // Верхний край
        {
            exitX = rand.Next(1, width - 1);
            exitY = 0;
        }
        else if (exitEdge == 1) // Правый край
        {
            exitX = width - 1;
            exitY = rand.Next(1, height - 1);
        }
        else if (exitEdge == 2) // Нижний край
        {
            exitX = rand.Next(1, width - 1);
            exitY = height - 1;
        }
        else // Левый край
        {
            exitX = 0;
            exitY = rand.Next(1, height - 1);
        }

        maze[exitY, exitX] = ' '; // Дыра на выходе (пустое место)

        // Прокладываем путь от старта до дырки (выхода)
        CreatePath(1, 1, exitX, exitY);

        // Добавляем стены внутри лабиринта
        AddWalls();
    }

    // Прокладывание пути от старта до дырки
    static void CreatePath(int startX, int startY, int endX, int endY)
    {
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        bool[,] visited = new bool[height, width];
        queue.Enqueue(new Tuple<int, int>(startX, startY));
        visited[startY, startX] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.Item1;
            int y = current.Item2;

            // Если мы достигли дырки (выхода)
            if (x == endX && y == endY) return;

            // Список возможных направлений
            List<Tuple<int, int>> directions = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(x, y - 1), // вверх
                new Tuple<int, int>(x, y + 1), // вниз
                new Tuple<int, int>(x - 1, y), // влево
                new Tuple<int, int>(x + 1, y)  // вправо
            };

            foreach (var direction in directions)
            {
                int newX = direction.Item1;
                int newY = direction.Item2;

                if (newX > 0 && newY > 0 && newX < width && newY < height && !visited[newY, newX] && maze[newY, newX] != 'X')
                {
                    visited[newY, newX] = true;
                    queue.Enqueue(new Tuple<int, int>(newX, newY));
                }
            }
        }
    }

    // Добавление стен внутри лабиринта
    static void AddWalls()
    {
        Random rand = new Random();

        // Идем по всем клеткам внутри лабиринта
        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                // Размещаем стену случайным образом с вероятностью 1/3
                if (maze[y, x] == ' ' && rand.Next(3) == 0)
                {
                    maze[y, x] = 'X';
                }
            }
        }
    }

    // Печать лабиринта
    static void PrintMaze()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(maze[y, x]);
            }
            Console.WriteLine();
        }
    }

    // Игровой процесс
    static void Play()
    {
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            int newX = playerX;
            int newY = playerY;

            // Обработка движения
            if (key.Key == ConsoleKey.UpArrow) newY--;
            if (key.Key == ConsoleKey.DownArrow) newY++;
            if (key.Key == ConsoleKey.LeftArrow) newX--;
            if (key.Key == ConsoleKey.RightArrow) newX++;

            // Проверка на валидность движения
            if (maze[newY, newX] != 'X')
            {
                maze[playerY, playerX] = ' '; // Очистить старую позицию
                playerX = newX;
                playerY = newY;
                maze[playerY, playerX] = 'S'; // Обновить новую позицию
            }

            Console.Clear();
            PrintMaze();

            // Проверка на победу (выход)
            if (maze[playerY, playerX] == ' ')
            {
                Console.WriteLine("Вы нашли выход!");
                break;
            }
        }
    }
}

