using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Laboratory_4
{
    static void Main()
    {
        // 1-ое задание

        Console.WriteLine("Введите выражение в постфиксной польской форме записи");
        string line = Console.ReadLine();
        string[] elements = line.Split();
        bool flag = true;

        Stack stack = new Stack();

        for (int i = 0; i < elements.Length; i++)
        {
            string el = elements[i];

            if (el != "*" & el != "+" & el != "-" & el != "/")
            {
                stack.Push(Convert.ToInt32(el));
            }

            else if ((el == "*" || el == "+" || el == "-" || el == "/") && stack.Count >= 2)
            {
                int a = (int)stack.Pop();
                int b = (int)stack.Pop();

                if (el == "*")
                {
                    stack.Push(a * b);
                }

                else if (el == "+")
                {
                    stack.Push(a + b);
                }

                else if (el == "/")
                {
                    if (a != 0) { stack.Push(b / a); }
                    else { flag = false; }
                    
                }

                else if (el == "-")
                {
                    stack.Push(b - a);
                }
            }
        }

        if (stack.Count == 1 && flag)
        {
            foreach (int st in stack)
            {
                Console.WriteLine("Значение выражения = {0}", st);
            }
        }
        else { Console.WriteLine("Неверная форма записи"); }


        // 2-ое задание
        int[] array = {1, 2, 2, 3, 5, 7};

        HashSet<int> set_array = new HashSet<int>(array);   
        Console.WriteLine("Множество массива:");
        foreach (int el in set_array) {Console.Write("{0}\t", el);}
        Console.WriteLine();

        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        foreach (int el in array)
        {
            if (! dictionary.ContainsKey(el))
            {
                dictionary.Add(el, 1);
            }
            else{
                dictionary[el] += 1;
            }
        }

        ICollection<int> dict = dictionary.Keys;

        foreach (int d in dict)
        {
            Console.WriteLine("{0}, число повторов: {1}", d, dictionary[d]);   
        }
    }
}
