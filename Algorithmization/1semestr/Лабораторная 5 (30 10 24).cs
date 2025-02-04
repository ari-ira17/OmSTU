using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Reflection.Emit;

class Laboratory_5{
    static void Main()
    {
        Console.WriteLine("Введите длину массива");
        int num_of_numbers = Convert.ToInt32(Console.ReadLine());
        
        // Массив и заполнение еще 3ех
        int[] numbers = new int[num_of_numbers];
        int[] new_numbers = new int[num_of_numbers];

        List<int> positive = new List<int>();
        List<int> nulll = new List<int>();
        List<int> negative = new List<int>();

        // Пользователь ввел циферки, сделали 3 массива: положительные, нулевые и отрицательные
        for (int i = 0; i < num_of_numbers; i++)
        {
            Console.WriteLine("Введите элемент массива");
            int element = Convert.ToInt32(Console.ReadLine());

            numbers[i] = element;

            if (element > 0) {positive.Add(element);}
            else if (element == 0) {nulll.Add(element);}
            else {negative.Add(element);}
        }

        int counter = 0;
        for (int j = 0; j < positive.Count(); j++)
        {
            new_numbers[j] = positive[j];
            counter = j;
        }

        if (counter == 0)
        {
            for (int k = 0; k < nulll.Count(); k++)
            {
                new_numbers[counter] = nulll[k];
                counter++;
            }
        }
        else
        {
            for (int k = 0; k < nulll.Count(); k++)
            {
               counter++;
                new_numbers[counter] = nulll[k]; 
            }
        }

        if (counter == 0)
        {
            for (int r = 0; r < negative.Count(); r++)
            {
                new_numbers[counter] = negative[r];
                counter++;
            }
        }
        else
        {
            for (int r = 0; r < negative.Count(); r++)
            {
                counter++;
                new_numbers[counter] = negative[r];
            }
        }


        // 1-e задание
        foreach (int i in new_numbers)
            Console.Write(i + " ");

        // 2-ое задание
        int counter_1 = 0;
        int difference = Math.Abs(numbers[0] - numbers[1]);
        for (int j = 1; j < num_of_numbers; j++)
        {
            if ((numbers[j - 1] - numbers[j] == difference) && numbers[j - 1] != numbers[j])
            {
                counter_1++;
            }
        }
        if (counter_1 == num_of_numbers - 1) {Console.WriteLine("\nРавномерная последовательность убывающих элементов");}
        else {Console.WriteLine("\nНе является равномерной последовательностью убывающих элементов");}

        // 3-е задание
        int counter_2 = 0;
        for (int k = 0; k < num_of_numbers; k++)
        {
            if (Math.Abs(numbers[k]) % 2 != 0)
            {
                counter_2++;
            }
        }
        if (counter_2 == 0) {Console.WriteLine("Все числа четные");}
        else {Console.WriteLine("Не все элементы четные");}
    
    }
}
