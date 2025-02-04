﻿using System;
using System.Diagnostics.Tracing;
using System.Reflection.Emit;
// a*x + b
class Guess_the_number
{
    static void Main()
    {
        Console.WriteLine("Введите число операций");
        int num_of_operations = Convert.ToInt32(Console.ReadLine());

        int[] equation = [1, 0];

        for (int i = 0; i < num_of_operations; i++)
        {
            Console.WriteLine("Введите операцию и число");
            string s = Console.ReadLine();
            string[] operation = s.Split(' ');      // массив из 2ух элементов

            if (operation[0] == "+" && operation[1] == "x")
            {
                equation = [equation[0] + 1, equation[1]];
            }
            else if (operation[0] == "-" && operation[1] == "x")
            {
                equation = [equation[0] - 1, equation[1]];
            }
            else
            {
                string op = operation[0];
                int num = Convert.ToInt32(operation[1]);

                int[] After(string sign, int number, int[] equation)
                {
                    switch(sign)
                    {
                        case "+": return [equation[0], equation[1] + number];
                        case "-": return [equation[0], equation[1] - number];
                        case "*": return [equation[0] * number, equation[1] * number];
                        default: return equation;
                    }
                }

                equation[0] = After(op, num, equation)[0];
                equation[1] = After(op, num, equation)[1];
                }
            }

        Console.WriteLine("Введите ответ");
        int result = Convert.ToInt32(Console.ReadLine());

        int x = (result - equation[1]) / equation[0];

        Console.WriteLine($"Ваше загаданное число: {x}");
    }
}
