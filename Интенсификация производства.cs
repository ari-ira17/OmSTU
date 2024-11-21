using System;

class Production
{
    static void Main()
    {
        Console.WriteLine("Введите начальную дату");
        string date_0 = Console.ReadLine();
        string[] date_0_splitted = date_0.Split(".");

        int[] date_0_int = new int[3];
        for (int i = 0; i < 3; i ++)
        {
            date_0_int[i] = Convert.ToInt32(date_0_splitted[i]);
        }

        Console.WriteLine("Введите конечную дату");
        string date_1 = Console.ReadLine();
        string[] date_1_splitted = date_1.Split(".");

        int[] date_1_int = new int[3];
        for (int i = 0; i < 3; i ++)
        {
            date_1_int[i] = Convert.ToInt32(date_1_splitted[i]);
        }

        DateTime date_0_1 = new DateTime(date_0_int[2], date_0_int[1], date_0_int[0]);
        DateTime date_1_1 = new DateTime(date_1_int[2], date_1_int[1], date_1_int[0]);
        TimeSpan difference = date_1_1 - date_0_1;

        Console.WriteLine("Введите начальный выпуск продукции");
        int quantity = Convert.ToInt32(Console.ReadLine());
        int quantity_now = quantity;
        int summ = quantity;

        for (int i = 0; i < difference.Days; i++)
        {
            quantity_now++;
            summ += quantity_now;
        }

        Console.WriteLine($"Всего было произведено {summ}");
    }
}