using System;
using System.IO;

public interface IType
{
    string Name { get; set; }
    double Perimetr();
    double Square();
}

public class Circle : IType
{
    public string Name { get; set; }
    public int Radius;
    public Circle(int radius)
    {
        Radius = radius;
    }

    public double Perimetr()
    {
        return 2 * Math.PI * Radius;
    }

    public double Square()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

public class Square_fiqure : IType
{
    public string Name { get; set; }
    public int Side_square;
    public Square_fiqure(int side_square)
    {
        Side_square = side_square;
    }

    public double Perimetr()
    {
        return 2 * Side_square;
    }

    public double Square()
    {
        return Math.Pow(Side_square, 2);
    }
}

public class Triangle : IType
{
    public string Name { get; set; }
    public int Side_triangle;
    public Triangle(int side_triangle)
    {
        Side_triangle = side_triangle;
    }

    public double Perimetr()
    {
        return 3 * Side_triangle;
    }

    public double Square()
    {
        return (Math.Sqrt(3) / 4) * Math.Pow(Side_triangle, 2);
    }
}

class Laboratory_2
{
    static void Main()
    {
        Circle circle = new Circle(10);
        circle.Name = "Окружность";
        Console.WriteLine($"{circle.Name}:");
        Console.WriteLine($"P = {Math.Round(circle.Perimetr(), 2)}");
        Console.WriteLine($"S = {Math.Round(circle.Square(), 2)}\n");

        Square_fiqure square_fiqure = new Square_fiqure(5);
        square_fiqure.Name = "Квадрат";
        Console.WriteLine($"{square_fiqure.Name}:");
        Console.WriteLine($"P = {Math.Round(square_fiqure.Perimetr(), 2)}");
        Console.WriteLine($"S = {Math.Round(square_fiqure.Square(), 2)}\n");

        Triangle triangle = new Triangle(16);
        triangle.Name = "Треугольник";
        Console.WriteLine($"{triangle.Name}:");
        Console.WriteLine($"P = {Math.Round(triangle.Perimetr(), 2)}");
        Console.WriteLine($"S = {Math.Round(triangle.Square(), 2)}\n");
    }
}
