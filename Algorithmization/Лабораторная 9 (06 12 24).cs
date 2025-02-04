using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
class Numbers
{
    public int a;
    public int b;
    
    public Numbers()
    { a = 0; b = 0; }

    public Numbers(int x)
    { a = x; b = 0; }

    public Numbers(int x, int y)
    { a = x; b = y; }

    public static void Sum(int a, int b)
    {
        int result = a + b;
        Console.WriteLine($"Сумма = {result}");
    }

    public static void Difference(int a, int b)
    {
        int result1 = a - b;
        int result2 = b - a;
        Console.WriteLine($"Разность a - b = {result1}");
        Console.WriteLine($"Разность b - a = {result2}");
    }

    public static void Composition(int a, int b)
    {
        int result = a * b;
        Console.WriteLine($"Произведение = {result}");
    }
    
    public static void Division(int a, int b)
    {
        if (b != 0)
        {
            int result = a / b;
            Console.WriteLine($"Частное = {result}");
        }
        else
        {
            Console.WriteLine("Нельзя делить на 0");
        }
    }

    class Laboratory_9
    {
        static void Main()
        {
            Numbers num1 = new Numbers();
            Sum(num1.a, num1.b);
            Composition(num1.a, num1.b);
            Difference(num1.a, num1.b);
            Division(num1.a, num1.b);
            Console.WriteLine();

            Numbers num2 = new Numbers(5);
            Sum(num2.a, num2.b);
            Composition(num2.a, num2.b);
            Difference(num2.a, num2.b);
            Division(num2.a, num2.b);
            Console.WriteLine();

            Numbers num3 = new Numbers(10, 5);
            Sum(num3.a, num3.b);
            Composition(num3.a, num3.b);
            Difference(num3.a, num3.b);
            Division(num3.a, num3.b);
        }
    }
}
