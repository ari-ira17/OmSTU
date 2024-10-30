using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Reflection.Emit;

class Practise_2{
    static void Main()
    {
        Console.WriteLine("Введите длину массива");
        int num_of_numbers = Convert.ToInt32(Console.ReadLine());
        
        // Массив и заполнение
        int[] numbers = new int[num_of_numbers];
        for (int i = 0; i < num_of_numbers; i++)
        {
            Console.WriteLine("Введите элемент массива");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        int[] new_numbers = new int[num_of_numbers];
        // Вывод положительных
        int k_need = 0;
        for (int k = 0; k < numbers.Length; k++)
        {
            if (numbers[k] > 0)
            {
                new_numbers[k] = numbers[k];
                k_need = Math.Max(k, k_need);
            }
        }
        k_need ++; //последний положительный индекс

        // Вывод нулевых
        int l_need = 0;
        for (int l = 0; l < numbers.Length; l++)
        {
            if (numbers[l] == 0)
            {
                new_numbers[k_need] = numbers[l];
                k_need ++;
                l_need = Math.Max(l, l_need);
            }
        }
        l_need ++;  //последний нулевой индекс

        // Вывод отрицательных
        for (int m = 0; m < numbers.Length; m++)
        {
            if (numbers[m] < 0)
            {
                new_numbers[l_need] = numbers[m];
                l_need ++;
            }
        }

        // 1-e задание
        foreach (int i in new_numbers)
            Console.Write(i + " ");

        // 2-ое задание
        int p = 0;
        int t = Math.Abs(numbers[0] - numbers[1]);
        for (int j = 1; j < numbers.Length; j++)
        {
            if ((numbers[j - 1] <= numbers[j]) && (numbers[j - 1] - numbers[j] == t))
            {
                p ++;
            }
        }
        if (p == 0) {Console.WriteLine("\nПоследовательность убывающих элементов");}
        else {Console.WriteLine("Не является последовательностью убывающих элементов");}

        // 3-е задание
        int w = 0;
        for (int q = 0; q < num_of_numbers; q++)
        {
            if (Math.Abs(numbers[q]) % 2 != 0)
            {
                w++;
            }
        }
        if (w == 0) {Console.WriteLine("Все числа четные");}
        else {Console.WriteLine("Не все элементы четные");}
    
    }
}
