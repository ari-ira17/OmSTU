using System;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
class Program
{
    static int[] Input(int num_of_numbers)
    {
        int[] numbers = new int[num_of_numbers];
        for (int i = 0; i < num_of_numbers; i++)
        {
            Console.WriteLine("Введите число");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }
            
        return numbers;
    }

    static int[] Square(int[] numbers_square)
    {
        for (int i = 0; i < numbers_square.Length; i++)
        {
            numbers_square[i] *= numbers_square[i];
        }

        return numbers_square;
    }

    static void Output(int[] numbers_output)
    {
        foreach (int el in numbers_output)
        {
            Console.WriteLine(el);
        }
    }


    static void Main()
    {
        Console.WriteLine("Введите длину массива");
        int n = Convert.ToInt32(Console.ReadLine());
        
        Output(Square(Input(n)));
    }
}

