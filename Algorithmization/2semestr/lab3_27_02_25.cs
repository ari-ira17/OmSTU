using System;
using System.Collections;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
class Laboratory_3
{
    static void Main()
    {
        Console.WriteLine("Введите математическое выражение");
        string line = Console.ReadLine();       
        line = line.Replace(" ", "");
        char[] elements = line.ToCharArray();    

        Stack stack = new Stack();
        Dictionary<char, char> staples = new Dictionary<char, char>();
        staples.Add('(', ')');
        staples.Add('{', '}');
        staples.Add('[', ']');

        bool flag = true;       // все хорошо

        foreach (char el in elements)
        {
            if ("({[".Contains(el))
            {
                stack.Push(el);
            }
            else if (")}]".Contains(el))
            {
                if (stack.Count == 0)
                {
                    flag = false;
                    break;
                }

                char last_in_stack = (char)stack.Pop();
                if (staples[last_in_stack] != el)
                {
                    flag = false;
                    break;
                }
            }
        }  

        if (stack.Count != 0)
        {
            flag = false;
        }

        if (flag)
        {
            Console.WriteLine("Правильная последовательность");
        }
        else
        {
            Console.WriteLine("Неравильная последовательность");
        }        
    }
}
