using System;
class Milk_Packaging
{
    static void Main()
    {
        Console.WriteLine("Введите число фирм");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] milk_cost = new double [n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите информацию о {i + 1} фирме");

            double x1 = Convert.ToDouble(Console.ReadLine());
            double y1 = Convert.ToDouble(Console.ReadLine());
            double z1 = Convert.ToDouble(Console.ReadLine());
            double s1 = 2 * (x1*y1 + x1*z1 + y1*z1);
            double v1 = (x1 * y1 * z1) / 1000;

            double x2 = Convert.ToDouble(Console.ReadLine());
            double y2 = Convert.ToDouble(Console.ReadLine());
            double z2 = Convert.ToDouble(Console.ReadLine());
            double s2 = 2 * (x2*y2 + x2*z2 + y2*z2);
            double v2 = (x2 * y2 * z2) / 1000;

            double c1 = Convert.ToDouble(Console.ReadLine());
            double c2 = Convert.ToDouble(Console.ReadLine());

            double g = Math.Abs(c2 - (c1 * s2) / s1) / Math.Abs(v2 - (v1 * s2) / s1);

            milk_cost[i] = g;      
        }

        double min_milk_cost = milk_cost.Min();
        int min_milk_producer = Array.IndexOf(milk_cost, min_milk_cost);

        Console.WriteLine((min_milk_producer + 1) + " " + Math.Round(min_milk_cost, 2));
    }
}
