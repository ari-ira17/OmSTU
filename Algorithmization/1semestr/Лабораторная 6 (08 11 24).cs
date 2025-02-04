using System;

class Laboratory_6
{
    static void Main()
    {
        Console.WriteLine("Введите число строк");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите число столбцов");
        int m = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int [n, m];

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                    Console.WriteLine($"Введите элемент {r + 1} строки {c + 1} столбца");
                    int num = Convert.ToInt32(Console.ReadLine());
                    matrix[r, c] = num;
            }
        }

        // 1-ое задание
        Console.WriteLine("1-ое задание");
        for (int c1 = 0; c1 < m; c1++)
        {
            int counter_sum_1 = 0;
            int counter_product_1 = 1;
            int counter_null_1 = 0;

            for (int r_1 = 0; r_1 < n; r_1 ++)
            {
                counter_sum_1 += matrix[r_1, c1];
                counter_product_1 *= matrix[r_1, c1];
                if (matrix[r_1, c1] == 0) {counter_null_1++;}
            }

            for (int c2 = c1 + 1; c2 < m; c2++)  
            {
                int counter_sum_2 = 0;
                int counter_product_2 = 1;
                int counter_null_2 = 0;

                for (int r_2 = 0; r_2 < n; r_2++)
                {
                    counter_sum_2 += matrix[r_2, c2];  
                    counter_product_2 *= matrix[r_2, c2];  
                    if (matrix[r_2, c2] == 0) counter_null_2++;  
                }

                if (counter_sum_1 == counter_sum_2 && counter_product_1 == counter_product_2 && counter_null_1 == counter_null_2)
                {
                    Console.WriteLine("Элементы, совпадающих стоблцов");
                    for (int r = 0; r < n; r++)
                    {
                        Console.WriteLine($"{matrix[r, c1]} {matrix[r, c2]}");
                    }
                }
            }
        } 

        // 2-ое задание
        Console.WriteLine("2-ое задание");

        int minn = matrix[0, 0];
        int maxx = matrix[0, 0];
        int minn_c = 0;
        int maxx_c = 0;
        for (int r = 0; r < n; r ++)
        {
            for (int c = 0; c < m; c++)
            {
                if (matrix[r, c] >= maxx) {maxx = matrix[r, c]; maxx_c = c;}
                if (matrix[r, c] <= minn) {minn = matrix[r, c]; minn_c = c;}
            }
        }

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c ++)
            {
                if (c == minn_c)
                {
                     Console.Write($"{matrix[r, maxx_c]}" + " ");
                }

                else if (c == maxx_c)
                {
                     Console.Write($"{matrix[r, minn_c]}" + " ");
                }
                
                else {Console.Write($"{matrix[r, c]}" + " ");}
            }
            Console.WriteLine();
        }

        //3-е задание
        Console.WriteLine("3-е задание");
        for (int r = 0; r < n; r++)
        {
            int counter = 0;
            for (int c = 1; c < m; c++)
            {
                int difference = Math.Abs(matrix[0, 0] - matrix[0, 1]);
                if (matrix[r, c - 1] - matrix[r, c] == difference) {counter++;}
            }
            if (counter == m - 1) {Console.WriteLine($"В строчке {r + 1} равномерно убывающая последовательность");}
        }
    }
}
