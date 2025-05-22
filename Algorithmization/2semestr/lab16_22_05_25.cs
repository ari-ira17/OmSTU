// using System;

// class Function
// {
//     public static bool Is_Polindrom(int num)
//     {
//         string num_to_string = Convert.ToString(Math.Abs(num));
//         string num_reverse = "";

//         for (int i = num_to_string.Length - 1; i >= 0; i--)
//         {
//             num_reverse += num_to_string[i];
//         }

//         if (num_to_string == num_reverse) { return true; }
//         else { return false; }
//     }
// }

// class Laboratory_16_1
// {
//     unsafe static void Main()  
//     {
//         int array_length = 5;

//         int* nums = stackalloc int[array_length];

//         nums[0] = 23;
//         nums[1] = 777;
//         nums[2] = 99888899;
//         nums[3] = 45;
//         nums[4] = 1;

//         for (int i = 0; i < array_length; i++)
//         {
//             if (Function.Is_Polindrom(*(nums + i))) { Console.WriteLine(*(nums + i)); }
//         }
//     }
// }



char symbol = 'A';
int asciiCode = Convert.ToInt32(symbol); //  Получение ASCII кода

Console.WriteLine(asciiCode); // Вывод: 65
