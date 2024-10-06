//                          №1
// using System;
// using System.Reflection.Emit;
// class Program_1 {
//     static void Main() 
//     {
//         Console.WriteLine("Введите число элементов");
//         int nums_of_numbers = Convert.ToInt32(Console.ReadLine());

//         Console.WriteLine("Введите 1-ое число");
//         int element = Convert.ToInt32(Console.ReadLine());
//         int counter = 1, counter_max = 1;
//         for (int i=1; i < nums_of_numbers; i++)
//         {
//             Console.WriteLine("Введите число");
//             int element_now = Convert.ToInt32(Console.ReadLine());

//             if (element == element_now)
//             {
//                 counter += 1;
//                 element = element_now;
//             }
//             else
//             {
//                 counter = 1;
//                 element = element_now;
//             }

//             counter_max = Math.Max(counter_max, counter);
//         }
//         Console.WriteLine(counter_max);
//   }
// }


//                          №2
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
class Program_2 {
    static void Main() 
    {
        Console.WriteLine("Введите число элементов");
        int n = Convert.ToInt32(Console.ReadLine());

        int min_counter = 100_000_000;
        int counter = 0;

        Console.WriteLine("Введите числа");

        for (int i = 0; i < n; i++)
        {
            int current = Convert.ToInt32(Console.ReadLine());

            if (current % 2 == 0)
            {
                counter++;
            }
            else if (counter != 0)
            {
                min_counter = Math.Min(min_counter, counter);
            }
            else
            {
                counter = 0;
            }

            if (counter != 0)
            {
                min_counter = Math.Min(min_counter, counter);
            }
        }
        Console.WriteLine(min_counter);
  }
}



//                          №3
// using System;
// using System.ComponentModel.DataAnnotations;
// using System.Reflection.Emit;
// class Program_3 {
//     static void Main() 
//     {
//         Console.WriteLine("Введите число элементов");
//         int n = Convert.ToInt32(Console.ReadLine());
//         int sum_inside = 0;
//         int sum_outside = 0;
//         for (int i=0; i<n; i++)
//         {
//             int a = Convert.ToInt32(Console.ReadLine());
//             if (a % 2 == 0)
//             {
//                 sum_inside += a;
//             }   
//             else
//             {
//                 sum_inside = 0;
//             }

//             sum_outside = Math.Max(sum_inside, sum_outside);
                
//         }
//         Console.WriteLine(sum_outside);
//   }
// }
