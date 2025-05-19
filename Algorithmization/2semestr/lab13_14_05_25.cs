using System;

class Product 
{
    public int Product_Id;
    public string Product_Name;
    public Product(int product_id, string product_name)
    {
        Product_Id = product_id;
        Product_Name = product_name;
    }
}

class Producer
{
    public int Producer_Id;
    public string Producer_Name;
    public int Producer_Number;
    public Producer(int producer_id, string producer_name, int producer_number)
    {
        Producer_Id = producer_id;
        Producer_Name = producer_name;
        Producer_Number = producer_number;
    }
}

class Shipment
{
    public string Producer_Name;
    public int Product_Id;
    public string Shipment_Date;
    public int Quantity;
    public int Price;
    public Shipment(string producer_name, int product_id, string shipment_date, int quantity, int price)
    {
        Producer_Name = producer_name;
        Product_Id = product_id;
        Shipment_Date = shipment_date; 
        Quantity = quantity;
        Price = price;
    }
}

class Laboratory_13
{
    static void Main()
    {
        Console.Clear();

        List<Product> products = new List<Product>();
        List<Producer> producers = new List<Producer>();
        List<Shipment> shipments = new List<Shipment>();

        products.Add(new Product(1, "Ноутбук"));
        products.Add(new Product(2, "Смартфон"));
        products.Add(new Product(3, "Планшет"));

        producers.Add(new Producer(1, "Поставщик А", 123));
        producers.Add(new Producer(2, "Поставщик Б", 987));
        producers.Add(new Producer(3, "Поставщик В", 555));

        shipments.Add(new Shipment("Поставщик А", 1, "2023-01-10", 5, 500));
        shipments.Add(new Shipment("Поставщик А", 1, "2023-01-10", 10, 300));
        shipments.Add(new Shipment("Поставщик Б", 1, "2023-02-05", 3, 550));
        shipments.Add(new Shipment("Поставщик Б", 3, "2023-02-05", 7, 250));
        shipments.Add(new Shipment("Поставщик В", 2, "2023-03-01", 8, 320));
        shipments.Add(new Shipment("Поставщик В", 3, "2023-03-05", 4, 260));

        string action = "";

        while (action != "5")
        {
            Console.WriteLine("Mеню:");
            Console.WriteLine("1. Bыдать поставщика, который поставил товар на большую сумму");
            Console.WriteLine("2. Выдать поставки товаров, сгруппированных по датам");
            Console.WriteLine("3. Выдать товары, сгруппированные по поставщику и отсортированные по количеству");
            Console.WriteLine("4. Определить товар, который поставлялся чаще всего");
            Console.WriteLine("5. Выдать сумму поставок, сгриппированных по поставщику");
            Console.WriteLine("6. Выход");
            Console.WriteLine("Выберите действие из меню");

            action = Console.ReadLine();

            if (action == "1")
            {
                var shipments_1 = from shipment_1 in shipments
                    group shipment_1 by shipment_1.Producer_Name into g
                    select new
                    {
                        Name = g.Key,
                        Costs = g.Sum(ship => ship.Quantity * ship.Price)
                    };

                int max_cost = shipments_1.Max(x => x.Costs);

                foreach (var producer in shipments_1)
                {
                    if (producer.Costs == max_cost)
                    {
                        Console.WriteLine("Больше всех поставил -", producer.Name);
                        Console.WriteLine(producer.Costs);
                    }
                }
            }
            else if (action == "2")
            {
                var shipments_2 = from shipment_2 in shipments
                    join product in products on shipment_2.Product_Id equals product.Product_Id 
                    select new
                    {
                        Name = product.Product_Name,
                        Date = shipment_2.Shipment_Date
                    };

                var products_2 = from product_2 in shipments_2
                    group product_2 by product_2.Date;

                foreach (var product in products_2)
                {
                    Console.WriteLine(product.Key);
                    foreach(var pr in product)
                    {
                        Console.WriteLine(pr.Name);
                    }
                    Console.WriteLine();
                }
            }
             else if (action == "3")
            {
                var shipments_3 = from shipment_3 in shipments
                    join product in products on shipment_3.Product_Id equals product.Product_Id
                    select new
                    {
                        Name = product.Product_Name,
                        Ship = shipment_3.Quantity,
                        Producer = shipment_3.Producer_Name
                    };
                var group_3 = from ship_3 in shipments_3
                    group ship_3 by ship_3.Producer;

                foreach (var g_3 in group_3)
                {
                    Console.WriteLine(g_3.Key);
                    foreach(var product in g_3)
                    {
                        Console.WriteLine("{0} - {1}", product.Name, product.Ship);
                    }
                    Console.WriteLine();
                }
            }
            else if (action == "4")
            {
                var shipments_4 = from shipment_4 in shipments
                    group shipment_4 by shipment_4.Product_Id into g
                    select new
                    {
                        Name = g.Key,
                        Num = g.Sum(ship => ship.Quantity)
                    };
            
                int num = shipments_4.Max(x => x.Num);

                foreach (var product in shipments_4)
                {
                    if (product.Num == num)
                    {
                        Console.WriteLine("Самый поставляемый товар - {0}", product.Name);
                    }
                }
            }
            else if (action == "5")
            {
                var shipments_5 = from shipment_5 in shipments
                    group shipment_5 by shipment_5.Producer_Name into g
                    select new
                    {
                        Name = g.Key,
                        Costs = g.Sum(ship => ship.Quantity * ship.Price)
                    };

                foreach (var producer in shipments_5)
                {
                    Console.WriteLine(producer.Name);
                    Console.WriteLine(producer.Costs);
                    Console.WriteLine();
                }
            }
            else if (action == "6")
            { break; }
            else { Console.WriteLine("Некорректный ввод. Выберите из пунктов 1 - 6."); }
        }
    }
}
