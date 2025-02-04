using System;
class Furniture
{
    public string Name, City;
    public int Cost;
    public Furniture(string name, string city, int cost)
    {
        Name = name;
        City = city;
        Cost = cost;
    }
}

class Chairs : Furniture
{
    public int Chair_legs;
    public bool Softness;
    public Chairs(string name, string city, int cost, int chair_legs, bool softness) : base(name, city, cost)
    {
        Chair_legs = chair_legs;
        Softness = softness;
    }
}

class Tables : Furniture
{
    public int Table_legs;
    public string Tabletop_type;
    public Tables(string name, string city, int cost, int table_legs, string tabletop_type) : base(name, city, cost)
    {
        Table_legs = table_legs;
        Tabletop_type = tabletop_type;
    }
}

class Functions
{
    public static Chairs Chair_creation()
    {
        string name = "";
        while (name == "")
        {
            Console.WriteLine("Введите наименование стула");
            name = Console.ReadLine();
        }

        string city = "";
        while (city == "")
        {
            Console.WriteLine("Введите название города-производителя");
            city = Console.ReadLine();
        }

        int cost = 0;
        while (cost == 0)
        {
            Console.WriteLine("Введите стоимость стула");
            cost = Convert.ToInt32(Console.ReadLine());
        }

        int chair_legs = 0;
        while (chair_legs == 0)
        {
            Console.WriteLine("Введите количество ножек стула");
            chair_legs = Convert.ToInt32(Console.ReadLine());
        }

        string softness_ = "";
        bool softness = true; 
        while (softness_ == "")
        {
            Console.WriteLine("Мягкий ли стул?");
            softness_ = Console.ReadLine();
            if (softness_ == "Да") { softness = true; }
            else { softness = false; }
        }

        return new Chairs(name, city, cost, chair_legs, softness);
    }

    public static Tables Table_creation()
    {
        string name = "";
        while (name == "")
        {
            Console.WriteLine("Введите наименование стола");
            name = Console.ReadLine();
        }

        string city = "";
        while (city == "")
        {
            Console.WriteLine("Введите название города-производителя");
            city = Console.ReadLine();
        }

        int cost = 0;
        while (cost == 0)
        {
            Console.WriteLine("Введите стоимость стола");
            cost = Convert.ToInt32(Console.ReadLine());
        }

        int table_legs = 0;
        while (table_legs == 0)
        {
            Console.WriteLine("Введите количество ножек стола");
            table_legs = Convert.ToInt32(Console.ReadLine());
        }

        string tabletop_type= "";
        while (tabletop_type == "")
        {
            Console.WriteLine("Введите тип столешницы");
            tabletop_type = Console.ReadLine();
        }

        return new Tables(name, city, cost, table_legs, tabletop_type);
    }

    public static void Chairs_print(List<Chairs> chairs)
    {
        Console.WriteLine("Ваши стулья");
        foreach (Chairs chair in chairs)
        {
            Console.WriteLine($"Наименование: {chair.Name}");
            Console.WriteLine($"Город-производитель: {chair.City}");
            Console.WriteLine($"Стоимость: {chair.Cost}");
            Console.WriteLine($"Количество ножек: {chair.Chair_legs}");
            Console.WriteLine($"Мягкий ли: {chair.Softness}\n");
        }
    }

    public static void Tables_print(List<Tables> tables)
    {
        Console.WriteLine("Ваши столы");
        foreach (Tables table in tables)
        {
            Console.WriteLine($"Наименование: {table.Name}");
            Console.WriteLine($"Город-производитель: {table.City}");
            Console.WriteLine($"Стоимость: {table.Cost}");
            Console.WriteLine($"Количество ножек: {table.Table_legs}");
            Console.WriteLine($"Тип столешницы: {table.Tabletop_type}\n");
        }
    }
    
    public static void Search_by_city(List<Chairs> chairs, List<Tables> tables)
    {
        Console.WriteLine("Введите город-производитель, по которому осуществим выборку");
        string city = Console.ReadLine();

        foreach (Chairs chair in chairs)
        {
            if (chair.City == city)
            {
                Console.WriteLine($"Наименование: {chair.Name}");
            }
        }

        foreach(Tables table in tables)
        {
            if (table.City == city)
            {
                Console.WriteLine($"Наименование: {table.Name}");
            }
        }
    }
    public static void Search_by_chair_legs(List<Chairs> chairs)
    {
        Console.WriteLine("Введите количество ножек стульев, по которым осуществим выборку");
        int chair_legs = Convert.ToInt32(Console.ReadLine());

        foreach (Chairs chair in chairs)
        {
            if (chair.Chair_legs == chair_legs)
            {
                Console.WriteLine($"Наименование: {chair.Name}");
            }
        }
    }

    public static void Search_by_table_legs(List<Tables> tables)
    {
        Console.WriteLine("Введите количество ножек столов, по которым осуществим выборку");
        int table_legs = Convert.ToInt32(Console.ReadLine());

        foreach (Tables table in tables)
        {
            if (table.Table_legs == table_legs)
            {
                Console.WriteLine($"Наименование: {table.Name}");
            }
        }
    }
}

class Laboratory_12
{
    static void Main()
    {
        List<Chairs> chairs = new List<Chairs>();  
        List<Tables> tables = new List<Tables>();

        while (true)
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1. Заполнение");
            Console.WriteLine("2. Выборка по городу-производителю");
            Console.WriteLine("3. Выборка по количеству ножжек среди стульев");
            Console.WriteLine("4. Выборка по количеству ножек у столов");
            Console.WriteLine("5. Выход");

            string action = Console.ReadLine();
            if (action == "1")
            {
                string action_1 = "";
                Console.WriteLine("Хотите заполнить стулья или столы?");
                while (!(action_1 == "Стулья" || action_1 == "Столы"))
                {
                    action_1 = Console.ReadLine();
                    if  (action_1 == "Стулья")
                    {
                        Console.WriteLine("Сколько стульев хотите ввести?");
                        int n_chairs = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < n_chairs; i++)
                        {
                            chairs.Add(Functions.Chair_creation());
                        }
                        Functions.Chairs_print(chairs);
                    }
                    else if (action_1 == "Столы")
                    {
                        Console.WriteLine("Сколько столов хотите ввести?");
                        int n_tables = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < n_tables; i++)
                        {
                            tables.Add(Functions.Table_creation());
                        }
                        Functions.Tables_print(tables);
                    } 
                }
            }
            else if (action == "2")
            {
                if ((chairs.Count > 0) && (tables.Count > 0)) { Functions.Search_by_city(chairs, tables); }
                else { Console.WriteLine("Сначала введите данные"); }
            }
            else if (action == "3")
            {
                if (chairs.Count > 0) { Functions.Search_by_chair_legs(chairs); }
                else { Console.WriteLine("Сначала введите данные"); }
            }
            else if (action == "4")
            {
                if (tables.Count > 0) { Functions.Search_by_table_legs(tables); }
                else { Console.WriteLine("Сначала введите данные"); }
            }
            else { break; }
        }
        
    }
}
