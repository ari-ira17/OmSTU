using System;
using System.Linq.Expressions;

public class Phone
{
    public int Number;
    public int Year;
    public string Telecom;
    public string Full_Name;

    public Phone(int num, int year, string telecom, string f_n)
    {
        Number = num;
        Year = year;
        Telecom = telecom;
        Full_Name = f_n;
    }
}

class Functions
{
    public static void Phones_Print(Phone phone)
    {
        Console.WriteLine("Номер телефона: {0}", phone.Number);
        Console.WriteLine("Год заключения договора: {0}",phone.Year);
        Console.WriteLine("Оператор связи: {0}",phone.Telecom);
        Console.WriteLine("Пользователь: {0}", phone.Full_Name);
        Console.WriteLine();
    }
}


class Laboratory_12
{
    static void Main()
    {
        List<Phone> phones = new List<Phone>();
        Phone phone_1 = new Phone(1704, 2020, "Megafon", "Aristova IV");
        Phone phone_2 = new Phone(1804, 2021, "MTS", "Aristova IV");
        Phone phone_3 = new Phone(1508, 2019, "MTS", "Semikin ND");
        Phone phone_4 = new Phone(1608, 2021, "Tele2", "Semikin ND");

        phones.Add(phone_1);
        phones.Add(phone_2);
        phones.Add(phone_3);
        phones.Add(phone_4);

        string action = "";

        while (action != "5")
        {
            Console.WriteLine("Mеню:");
            Console.WriteLine("1. Группировка по году заключения договора");
            Console.WriteLine("2. Группировка по оператору связи");
            Console.WriteLine("3. Поиск по номеру телефона");
            Console.WriteLine("4. Поиск по ФИО владельца");
            Console.WriteLine("5. Выход");
            Console.WriteLine("Выберите действие из меню");

            action = Console.ReadLine();

            if (action == "1")
            {
                var phones_by_year = from phone in phones
                    group phone by phone.Year;
                
                Console.WriteLine();
                Console.WriteLine("Группировка по году заключения договора");
                foreach (var phones_year in phones_by_year)
                {
                    foreach (var phone_by_year in phones_year)
                    {
                        Functions.Phones_Print(phone_by_year);
                    }
                    Console.WriteLine();
                }
            }
            else if (action == "2")
            {
                var phones_by_telecom = from phone in phones
                    group phone by phone.Telecom;
                
                Console.WriteLine();
                Console.WriteLine("Группировка по опереатору связи");
                foreach (var phones_telecom in phones_by_telecom)
                {
                    foreach (var phone_by_telecom in phones_telecom)
                    {
                        Functions.Phones_Print(phone_by_telecom);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            else if (action == "3")
            {
                Console.WriteLine("Введите номер");
                int number = Convert.ToInt32(Console.ReadLine());
                var phones_by_number = from phone in phones
                    where phone.Number == number
                    select phone;

                Console.WriteLine("Результаты поиска по номеру");
                foreach (var phone_by_number in phones_by_number)
                {
                    Functions.Phones_Print(phone_by_number);
                }
            }
            else if (action == "4")
            {
                Console.WriteLine("Введите ФИО пользователя");
                string f_n = Console.ReadLine();
                var phones_by_full_name = from phone in phones
                    where phone.Full_Name == f_n
                    select phone;

                Console.WriteLine("Результаты поиска по ФИО");
                foreach (var phone_by_full_name in phones_by_full_name)
                {
                    Functions.Phones_Print(phone_by_full_name);
                }
            }
            else { Console.WriteLine("Некорректный ввод. Выберите из пунктов 1 - 5."); }
        }
    }
}
