//                          №1
// using System;
// using System.Reflection.Emit;
// class Program {
//     static void Main() 
//     {
//         int nums_of_numbers = Convert.ToInt32(Console.ReadLine());
//         int num_1 = Convert.ToInt32(Console.ReadLine());
//         int num_2 = Convert.ToInt32(Console.ReadLine());
//         int counter = 0;
//         for (int i=2; i < nums_of_numbers; i++)
//         {
//             int num_n = Convert.ToInt32(Console.ReadLine());
//             if (num_1 > num_2 && num_2 < num_n)
//             {
//                 counter += 1;
//             }
//             num_1 = num_2;
//             num_2 = num_n;
//         }
//         Console.WriteLine(counter);
//   }
// }


//                          №2
// using System;
// using System.Reflection.Emit;
// class Program {
//     static void Main() 
//     {
//         int n = Convert.ToInt32(Console.ReadLine());
//         int counter = 0;
//         for (int i=0; i<n; i++)
//         {
//             int a = Convert.ToInt32(Console.ReadLine());
//             a = Math.Abs(a);
//             if (a % 10 == 2)
//                 counter += 1;
//         }
//         Console.WriteLine(counter);
//   }
// }


 //                        №3
using System;
using System.Reflection.Emit;
class Program {
    static void Main() 
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите 1-ый элемент");
        int max_first = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите 2-ой элемент");
        int max_second = Convert.ToInt32(Console.ReadLine());

        max_first = Math.Max(max_first, max_second);
        max_second = Math.Min(max_first, max_second);

        for (int i=2; i<n; i++)
        {
            Console.WriteLine("Введите элемент");
            int a = Convert.ToInt32(Console.ReadLine());

             if (a >= max_first)
            {
                max_second = max_first;
                max_first = a;
            }
            else
            {
                max_second = Math.Max(a, max_second);
            } 
        }

        Console.WriteLine(max_second);
  }
}


//                          №4
// using System;
// using System.ComponentModel.DataAnnotations;
// using System.Reflection.Emit;
// class Program {
//     static void Main() 
//     {
//         int n = Convert.ToInt32(Console.ReadLine());
//         int counter_inside = 0;
//         int counter_outside = 0;
//         for (int i=0; i<n; i++)
//         {
//             int a = Convert.ToInt32(Console.ReadLine());
//             if (a % 2 == 0)
//             {
//                 counter_inside += 1;
//             }   
//             else
//             {
//                 counter_inside = 0;
//             }

//             counter_outside = Math.Max(counter_inside, counter_outside);
                
//         }
//         Console.WriteLine(counter_outside);
//   }
// }
