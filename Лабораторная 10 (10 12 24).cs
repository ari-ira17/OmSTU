using System;
class Car
{
    public string Name;
    public string Year;
    public string Colour;
    public string Country;
    public Car(string name, string year, string colour, string country)
    {
        Name = name;
        Year = year;
        Colour = colour;
        Country = country;
    }
}

public class Functions
{
    public static string[,] Filling()
    {
        Console.WriteLine("Введите число машин");
        int n = Convert.ToInt32(Console.ReadLine());
        string[,] cars = new string[n, 4]; 
        for (int i = 0; i < n; i++)
        {
            string name = "";
            while (name == "")
            {
                Console.WriteLine($"Введите марку машины {i + 1}");
                name = Console.ReadLine();
            }

            string year = "";
            while (year == "")
            {
                Console.WriteLine($"Введите год выпуска машины {i + 1}");
                year = Console.ReadLine();
            }

            string colour = "";
            while (colour == "")
            {
                Console.WriteLine($"Введите цвет машины {i + 1}");
                colour = Console.ReadLine();
            }
            
            string country = "";
            while (country == "")
            {
                Console.WriteLine($"Введите страну выпуска машины {i + 1}");
                country = Console.ReadLine();
            }
            
            Car our_car = new Car(name, year, colour, country);
            cars[i, 0] = our_car.Name;
            cars[i, 1] = our_car.Year;
            cars[i, 2] = our_car.Colour;
            cars[i, 3] = our_car.Country;
        }
        
        Console.WriteLine("\nИнформация о машинах:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Машина {i + 1}:");
            Console.WriteLine($"Марка: {cars[i, 0]}");
            Console.WriteLine($"Год выпуска: {cars[i, 1]}");
            Console.WriteLine($"Цвет: {cars[i, 2]}");
            Console.WriteLine($"Страна: {cars[i, 3]}\n");
        }
        return cars;
    }

    public static void Choose_Name(string[,] cars)
    {
        Console.WriteLine("Введите марку, по которой осуществим выбор");
        string need_name = Console.ReadLine();
        string[,] cars_for_choose_name = cars;
        for (int i = 0; i < cars_for_choose_name.GetLength(0); i ++)
        {
            if (cars[i, 0] == need_name)
            {
                Console.WriteLine($"Вам подходит машина {i + 1}");
                Console.WriteLine($"Марка: {cars[i, 0]}");
                Console.WriteLine($"Год выпуска: {cars[i, 1]}");
                Console.WriteLine($"Цвет: {cars[i, 2]}");
                Console.WriteLine($"Страна: {cars[i, 3]}\n");
            }
        }
    }

    public static void Choose_Year(string[,] cars)
    {
        Console.WriteLine("Введите год, по которому осуществим выбор");
        string need_year = Console.ReadLine();
        string[,] cars_for_choose_year = cars;
        for (int i = 0; i < cars_for_choose_year.GetLength(0); i ++)
        {
            if (cars[i, 1] == need_year)
            {
                Console.WriteLine($"Вам подходит машина {i + 1}");
                Console.WriteLine($"Марка: {cars[i, 0]}");
                Console.WriteLine($"Год выпуска: {cars[i, 1]}");
                Console.WriteLine($"Цвет: {cars[i, 2]}");
                Console.WriteLine($"Страна: {cars[i, 3]}\n");
            }
        }
    }

    public static void Choose_Country(string[,] cars)
    {
        Console.WriteLine("Введите страну, по которой осуществим выбор");
        string need_country = Console.ReadLine();
        string[,] cars_for_choose_country = cars;
        for (int i = 0; i < cars_for_choose_country.GetLength(0); i ++)
        {
            if (cars[i, 3] == need_country)
            {
                Console.WriteLine($"Вам подходит машина {i + 1}");
                Console.WriteLine($"Марка: {cars[i, 0]}");
                Console.WriteLine($"Год выпуска: {cars[i, 1]}");
                Console.WriteLine($"Цвет: {cars[i, 2]}");
                Console.WriteLine($"Страна: {cars[i, 3]}\n");
            }
        }
    }
}

class Laboratory_10
{
    static void Main()
    {
        string[,] cars = null; 

        while (true)
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1. Заполнение");
            Console.WriteLine("2. Выборка по марке");
            Console.WriteLine("3. Выборка по году выпуска");
            Console.WriteLine("4. Выборка по стране выпуска");
            Console.WriteLine("5. Выход");

            string action = Console.ReadLine();

            if (action == "5") 
            { break; }
            
            void What_To_do(string action)
            {
                switch (action)
                {
                    case "1":
                        cars = Functions.Filling(); 
                        break;
                    case "2":
                        if (cars != null)
                        { Functions.Choose_Name(cars);}
                        else
                        { Console.WriteLine("Сначала опишите машины");}
                        break;
                    case "3":
                        if (cars != null)
                        { Functions.Choose_Year(cars);}
                        else
                        { Console.WriteLine("Сначала опишите машины");}
                        break;
                    case "4":
                        if (cars != null)
                        { Functions.Choose_Country(cars);}
                        else
                        { Console.WriteLine("Сначала опишите машины");}
                        break;
                }
            }
            What_To_do(action);
        }
    }
}