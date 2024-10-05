using System;

class ComplexNumber
{
    public double Real { get; set; }  // Действительная часть
    public double Imaginary { get; set; }  // Мнимая часть

    // Конструктор
    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // Сложение комплексных чисел
    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(this.Real + other.Real, this.Imaginary + other.Imaginary);
    }

    // Умножение комплексных чисел
    public ComplexNumber Multiply(ComplexNumber other)
    {
        double real = this.Real * other.Real - this.Imaginary * other.Imaginary;
        double imaginary = this.Real * other.Imaginary + this.Imaginary * other.Real;
        return new ComplexNumber(real, imaginary);
    }

    // Деление комплексных чисел
    public ComplexNumber Divide(ComplexNumber other)
    {
        double denominator = other.Real * other.Real + other.Imaginary * other.Imaginary;
        double real = (this.Real * other.Real + this.Imaginary * other.Imaginary) / denominator;
        double imaginary = (this.Imaginary * other.Real - this.Real * other.Imaginary) / denominator;
        return new ComplexNumber(real, imaginary);
    }

    // Возведение в степень
    public ComplexNumber Pow(int exponent)
    {
        ComplexNumber result = new ComplexNumber(1, 0); // Начальное значение - 1
        for (int i = 0; i < exponent; i++)
        {
            result = result.Multiply(this);
        }
        return result;
    }

    // Извлечение квадратного корня
    public ComplexNumber Sqrt()
    {
        double magnitude = Math.Sqrt(this.Magnitude());
        double angle = this.Angle() / 2;

        double real = magnitude * Math.Cos(angle);
        double imaginary = magnitude * Math.Sin(angle);
        return new ComplexNumber(real, imaginary);
    }

    // Модуль комплексного числа
    public double Magnitude()
    {
        return Math.Sqrt(Real * Real + Imaginary * Imaginary);
    }

    // Угол (аргумент) комплексного числа в радианах
    public double Angle()
    {
        return Math.Atan2(Imaginary, Real);
    }

    // Переопределение метода ToString для удобного вывода
    public override string ToString()
    {
        if (Imaginary >= 0)
            return $"{Real} + {Imaginary}i";
        else
            return $"{Real} - {Math.Abs(Imaginary)}i";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Ввод первого комплексного числа
        Console.WriteLine("Введите действительную и мнимую часть первого комплексного числа:");
        Console.Write("Действительная часть: ");
        double real1 = double.Parse(Console.ReadLine());
        Console.Write("Мнимая часть: ");
        double imaginary1 = double.Parse(Console.ReadLine());
        ComplexNumber z1 = new ComplexNumber(real1, imaginary1);

        // Ввод второго комплексного числа
        Console.WriteLine("Введите действительную и мнимую часть второго комплексного числа:");
        Console.Write("Действительная часть: ");
        double real2 = double.Parse(Console.ReadLine());
        Console.Write("Мнимая часть: ");
        double imaginary2 = double.Parse(Console.ReadLine());
        ComplexNumber z2 = new ComplexNumber(real2, imaginary2);

        // Выполнение операций и вывод результатов
        ComplexNumber sum = z1.Add(z2);
        Console.WriteLine($"Сумма: {sum}");

        ComplexNumber product = z1.Multiply(z2);
        Console.WriteLine($"Произведение: {product}");

        ComplexNumber division = z1.Divide(z2);
        Console.WriteLine($"Деление: {division}");

        Console.Write("Введите степень для возведения в степень первого числа: ");
        int exponent = int.Parse(Console.ReadLine());
        ComplexNumber pow = z1.Pow(exponent);
        Console.WriteLine($"Первое число в степени {exponent}: {pow}");

        ComplexNumber sqrt = z1.Sqrt();
        Console.WriteLine($"Квадратный корень из первого числа: {sqrt}");

        double magnitude = z1.Magnitude();
        double angle = z1.Angle();
        Console.WriteLine($"Модуль первого числа: {magnitude}");
        Console.WriteLine($"Угол первого числа (в радианах): {angle}");
    }
}
