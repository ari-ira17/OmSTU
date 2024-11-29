using System;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
namespace Lab;

class Laboratory_8
{
    static void Main()
    {
        Console.WriteLine("Введите строку");
        string s = Console.ReadLine();
        s = s.ToLower();

        // 1-ое задание
        string chars = "";
        char our_char = '\0';

        for (int i = 2; i < s.Length; i++)
        {
            if ($"{s[i - 2]}{s[i]}" == "ab")
            {
                chars += s[i - 1];
            }
        }
        
        string sortedString = new string(chars.OrderBy(c => c).ToArray());

        int k = 0;
        int k_max = 1;
        for (int j = 0; j < sortedString.Length - 1; j++)
        {
            if (sortedString.Length == 1) {our_char = sortedString[0];}
            else if (sortedString[j] == sortedString[j + 1]) {k++;}
            else
            {
                if (k >= k_max)
                {
                    k_max = k;
                    our_char = chars[j];
                }
                k = 1;
                our_char = chars[j - 1];
            }
        }

        Console.WriteLine("Чаще всего между a и b встречается " + our_char);

        // 2-ое задание
        int counter = 0;
        int counter_max = 0;
        int l = 0;

        while (l < s.Length)
        {
            if (l + 2 < s.Length && $"{s[l]}{s[l + 1]}{s[l + 2]}" == "abc")
            {
                counter += 3; 
                counter_max = Math.Max(counter, counter_max);
                l += 3;  
            }
            else if (l + 1 < s.Length && $"{s[l]}{s[l + 1]}" == "ab" && counter >= 3)
            {
                counter += 2;  
                counter_max = Math.Max(counter, counter_max);
                l += 2;  
            }
            else if (s[l] == 'a' && counter >= 3)
            {
                counter++; 
                counter_max = Math.Max(counter, counter_max);
                l++;  
            }
            else
            {
                counter = 0;
                l++; 
            }
        }

        Console.WriteLine("Максимальная длина подпоследовательности abc = " + counter_max);
    }
}



