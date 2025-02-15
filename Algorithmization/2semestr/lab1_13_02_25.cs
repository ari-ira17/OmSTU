using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

class Phones
{
    public int Number;
    public string Telecom_Provider;
    public int Year;

    public Phones(int number, string telecom_provider, int year)
    {
        Number = number;
        Telecom_Provider = telecom_provider;
        Year = year;
    }
}

class Users
{
    public string Surname;
    public string Name;
    public string Patronymic;
    public List<int> Numbers =  new List<int>();

    public Users(string surname, string name, string patronymic, List<int> numbers)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        Numbers = numbers;
    }
}

class Functions
{
    public static Phones Phones_description()
    {
        int number = 0;
        while (number == 0)
        {
            Console.WriteLine("Введите номер телефона в формате 8**********");
            number = Convert.ToInt32(Console.ReadLine());
        }

        string telecom_provider = "";
        while (telecom_provider == "")
        {
            Console.WriteLine("Введите оператор связи указанного телефона");
            telecom_provider = Console.ReadLine();
        }

        int year = 0;
        while (year == 0)
        {
            Console.WriteLine("Введите год заключения договора в формате ГГГГ");
            year = Convert.ToInt32(Console.ReadLine());
        }
        
        return new Phones(number, telecom_provider, year);
    }

    public static Users Users_description()
    {
        string surname = "";
        while (surname == "")
        {
            Console.WriteLine("Введите фамилию");
            surname = Console.ReadLine();
        } 

        string name = "";
        while (name == "")
        {
            Console.WriteLine("Введите имя");
            name = Console.ReadLine();
        }

        string patronymic = "";
        while (patronymic == "")
        {
            Console.WriteLine("Введите отчество");
            patronymic = Console.ReadLine();
        }

        List<int> numbers =  new List<int>();
        string flag = "да";
        while (flag == "да")
        {
            Console.WriteLine("Введите номер телефона в формате 8**********");
            int number = Convert.ToInt32(Console.ReadLine());
            numbers.Add(number);
            Console.WriteLine("Продолжить заполнение или закончить (да/нет)?");
            flag = Console.ReadLine();
        }

        return new Users(surname, name, patronymic, numbers);
    }

    public static void Phones_Print(List<Phones> phones)
    {
        Console.WriteLine("Информация о номерах телефонов");
        foreach (Phones phone in phones)
        {
            Console.WriteLine($"Номер телефона: {phone.Number}");
            Console.WriteLine($"Оператор связи: {phone.Telecom_Provider}");
            Console.WriteLine($"Год заключения договора: {phone.Year}\n");
        }
    }

    public static void Users_Print(List<Users> users)
    {
        Console.WriteLine("Информация о пользователях");
        foreach (Users user in users)
        {
            Console.WriteLine($"Фамилия: {user.Surname}");
            Console.WriteLine($"Имя: {user.Name}");
            Console.WriteLine($"Отчество: {user.Patronymic}");
            Console.WriteLine("Номера телефонов:");
            foreach (int number in user.Numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
        }
    }

    public static void Number_Search(List<Phones> phones, List<Users> users)
    {
        Console.WriteLine("Введите номер, по которому будет осуществлен поиск");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Номер, по которому будет осуществлен поиск: {number}");
        foreach (Phones phone in phones)
        {
            if (phone.Number == number)
            {
                foreach (Users user in users)
                {
                    foreach (int number_user in user.Numbers)
                    {
                        if (phone.Number == number_user)
                        {
                            Console.WriteLine($"Фамилия: {user.Surname}");
                            Console.WriteLine($"Имя: {user.Name}");
                            Console.WriteLine($"Отчество: {user.Patronymic}");
                            Console.WriteLine($"Оператор связи: {phone.Telecom_Provider}");
                            Console.WriteLine($"Год заключения договора: {phone.Year}\n");
                        }
                    }
                }
            }
        }
    }

    public static void Telecom_Provider_Search(List<Phones> phones, List<Users> users)
    {
        Console.WriteLine("Введите оператора, по которому будет осуществлен поиск");
        string telecom_provider = Console.ReadLine();
        Console.WriteLine($"Оператор, по которому будет осуществлен поиск: {telecom_provider}");
        foreach (Phones phone in phones)
        {
            if (phone.Telecom_Provider == telecom_provider)
            {
                int number = phone.Number;
                foreach (Users user in users)
                {
                    foreach (int number_user in user.Numbers)
                    {
                        if (number == number_user)
                        {
                            Console.WriteLine($"Фамилия: {user.Surname}");
                            Console.WriteLine($"Имя: {user.Name}");
                            Console.WriteLine($"Отчество: {user.Patronymic}");
                            Console.WriteLine($"Номер телефона: {number}");
                            Console.WriteLine($"Год заключения договора: {phone.Year}\n");
                        }
                    }
                }
            }
        }
    }

    public static void Year_Search(List<Phones> phones, List<Users> users)
    {
        Console.WriteLine("Введите год заключения договора, по которому будет осуществлен поиск");
        int year = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Год заключения договора, по которому будет осуществлен поиск: {year}");
        foreach (Phones phone in phones)
        {
            if (phone.Year == year)
            {
                int number = phone.Number;
                foreach (Users user in users)
                {
                    foreach (int number_user in user.Numbers)
                    {
                        if (number == number_user)
                        {
                            Console.WriteLine($"Фамилия: {user.Surname}");
                            Console.WriteLine($"Имя: {user.Name}");
                            Console.WriteLine($"Отчество: {user.Patronymic}");
                            Console.WriteLine($"Номер телефона: {number}");
                            Console.WriteLine($"Оператор связи: {phone.Telecom_Provider}\n");
                        }
                    }
                }
            }
        }
    }
}

class Laboratory_1
{
    static void Main()
    {
        List<Phones> phones = new List<Phones>();
        List<Users> users = new List<Users>();

        while (true)
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1. Заполнение");
            Console.WriteLine("2. Выборка данных по номеру телефона");
            Console.WriteLine("3. Выборка данных по оператору связи");
            Console.WriteLine("4. Выборка данных по году заключения договора");
            Console.WriteLine("5. Выход");

            string action = Console.ReadLine();

            if (action == "1")
            {
                Console.WriteLine("1. Заполнение номеров телефонов");
                Console.WriteLine("2. Заполнение пользователей");
                string action_filling = Console.ReadLine();

                if (action_filling == "1")
                {
                    string flag = "да";
                    while (flag == "да")
                    {
                        phones.Add(Functions.Phones_description());
                        Console.WriteLine("Продолжить ввод (да/нет?");
                        flag = Console.ReadLine();
                    }
                    Functions.Phones_Print(phones); 
                }
                else if (action_filling == "2")
                {
                    string flag = "да";
                    while (flag == "да")
                    {
                        users.Add(Functions.Users_description());
                        Console.WriteLine("Продолжить ввод (да/нет)?");
                        flag = Console.ReadLine();
                    }
                    Functions.Users_Print(users);
                } 
            }
            
            else if (action == "2" && phones.Count != 0 && users.Count != 0)
            { Functions.Number_Search(phones, users); } 

            else if (action == "3" && phones.Count != 0 && users.Count != 0)
            { Functions.Telecom_Provider_Search(phones, users); }

            else if (action == "4" && phones.Count != 0 && users.Count != 0)
            { Functions.Year_Search(phones, users); }

            else 
            { break; }
        }
    }
}
