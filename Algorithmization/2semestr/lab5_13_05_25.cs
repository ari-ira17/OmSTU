using System;
using System.Collections;

// 1-ое задание
class Phone
{
    public int Number;
    public string Telecom_Operator;
    public Phone(int number, string telecom_operator)
    {
        Number = number;
        Telecom_Operator = telecom_operator;
    }
}

class Laboratory_5_1
{
    static void Main()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        List<Phone> phones = new List<Phone>();
        
        Console.WriteLine("Введите число номеров");
        int num_of_numbers = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < num_of_numbers; i++)
        {
            Console.WriteLine("Введите номер");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите оператора связи");
            string telecom_operator = Console.ReadLine();
            Phone phone = new Phone(number, telecom_operator);
            phones.Add(phone);
        }

        foreach (Phone phone in phones)
        {
            if (! dictionary.ContainsKey(phone.Telecom_Operator))
            {
                dictionary.Add(phone.Telecom_Operator, 1);
            }
            else
            {
                dictionary[phone.Telecom_Operator] += 1;
            }
        }

        foreach (var el in dictionary)
        {
            Console.WriteLine("{0} имеет {1} номеров", el.Key, el.Value);
        }
    }
}


// 2-ое задание
delegate int Delegate(ref int a, int b);
class Elements
{
    public int A { get; set; }
    public int B { get; set; }
    public Elements(int a, int b)
    {
        A = a;
        B = b;
    }

    public static int Sum(ref int A, int B)
    {
        A = A + B;
        return A;
    }

    public static int Difference(ref int A, int B)
    {
        A = A - B;
        return A;
    }

    public static int Composition(ref int A, int B)
    {
        A = A * B;
        return A;
    }

    public static int Division(ref int A, int B)
    {
        if (B != 0) { A = A / B; return A; }
        else { Console.WriteLine("Ошибка: деление на 0"); return 0; }
    }
}

class Laboratory_5_2
{
    static void Main()
    {
        Console.Clear();

        Elements element_1 = new Elements(5, 10);
        int a1 = element_1.A;
        int b1 = element_1.B;

        Delegate method_1 = Elements.Sum;
        method_1 += Elements.Composition;
        method_1 += Elements.Difference;
        int result_1 = method_1(ref a1, b1);

        Console.WriteLine("Результат_1 = {0}", result_1);


        Elements element_2 = new Elements(100, 10);
        int a2 = element_2.A;
        int b2 = element_2.B;

        Delegate method_2 = Elements.Difference;
        method_2 += Elements.Division;
        method_2 += Elements.Composition;
        int result_2 = method_2(ref a2, b2);

        Console.WriteLine("Результат_2 = {0}", result_2);
    }
}
