using System;

delegate int Operation(int x, int y);
delegate bool Is_Null(int x);

class Laboratory_8_1
{
    static void Main()
    {
        Is_Null is_null = x => x == 0;
        Operation summ = (a, b) => a + b;
        Operation difference = (a, b) => a - b;
        Operation composition = (a, b) => a * b;
        Operation devide = (a, b) => a / b;
        
        int a = 10;
        int b = 0;

        Console.WriteLine(summ(a, b));
        Console.WriteLine(difference(a, b));
        Console.WriteLine(composition(a, b));

        if (is_null(b)) { Console.WriteLine("Ошибка: деление на 0 невозможно!"); }
        else { Console.WriteLine(a / b); }

    }
}


delegate bool A_Is_First(string s);
class Laboratory_8_2
{
    static void Main()
    {
        string[] array = {"apple", "banana", "car", "abolition"};

        A_Is_First a_is_first = s => 
        { 
            string[] els = s.Split();
            char el = s[0];
            return el == 'a';
        };

        for (int i = 0; i < array.Length; i++)
        {
            if (a_is_first(array[i]))
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
