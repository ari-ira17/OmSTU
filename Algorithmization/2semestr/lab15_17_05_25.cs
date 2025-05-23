using System;
using System.ComponentModel.Design;

class Car
{
    public int CarId;
    public string CarBrand;
    public string CarModel;
    public Car(int c_id, string c_brand, string c_model)
    {
        CarId = c_id;
        CarBrand = c_brand;
        CarModel = c_model;
    }
}

class Driver 
{
    public int DriverId;
    public string Name;
    public int CarId;
    public Driver(int d_id, string name, int c_id)
    {
        DriverId = d_id;
        Name = name;
        CarId = c_id;
    }
}

class CarService
{
    public int CarId;
    public string Service;
    public int Cost;
    public DateTime Date;
    public CarService(int c_id, string s, int c, DateTime d)
    {
        CarId = c_id;
        Service = s;
        Cost = c;
        Date = d;
    }
}


class Laboratory_15
{
    static void Main()
    {
        Console.Clear();

        List<Car> cars = new List<Car>()
        {
            new Car(1, "audi", "q7"),
            new Car(2, "audi", "a3"),
            new Car(3, "bmw", "m3"),
            new Car(4, "porshe", "911"),
        };

        List<Driver> drives = new List<Driver>()
        {
            new Driver(1, "Ivanov ER", 1),
            new Driver(2, "Sidorov BK", 2),
            new Driver(3, "Egorov TL", 3),
            new Driver(4, "Smirnov DP", 4)
        };

        List<CarService> car_service = new List<CarService>()
        {
            new CarService(1, "outside mirror", 11000, new DateTime(2025, 5, 1)),
            new CarService(2, "wheels", 12000, new DateTime(2025, 5, 3)),
            new CarService(3, "headlights", 13000, new DateTime(2025, 5, 3)),
            new CarService(4, "door handle", 14000, new DateTime(2025, 5, 6))
        };


        while (true)
        {
            Console.WriteLine("Mеню:");
            Console.WriteLine("1. Выдать пользователей, сгруппированных по марке машины");
            Console.WriteLine("2. Выдать пользователей, сгруппированных по дате обращения в автосервис и отсортированных по услуге");
            Console.WriteLine("3. Выдать на какую сумму оказаны услуги в заданный интервал времени");
            Console.WriteLine("4. Выход");
            Console.WriteLine("Выберите действие из меню");

            string action = Console.ReadLine();

            if (action == "1")
            {
                var connecting_tables = from service in car_service
                    join drive in drives on service.CarId equals drive.CarId    
                    join car in cars on service.CarId equals car.CarId       
                    select new
                    {
                        Name = drive.Name,
                        Brand = car.CarBrand
                    };

                var grouped_by_brand = from drive in connecting_tables
                    group drive by drive.Brand;

                foreach (var brands in grouped_by_brand)
                {
                    Console.WriteLine(brands.Key);
                    foreach(var drive in brands)
                    {
                        Console.WriteLine(drive.Name);
                    }
                    Console.WriteLine();
                }
            }
            else if (action == "2")
            {
                var connecting_tables = from service in car_service
                    join car in cars on service.CarId equals car.CarId  
                    join drive in drives on car.CarId equals drive.CarId
                    select new
                    {
                        Name = drive.Name,
                        Date = service.Date,
                        Service = service.Service
                    };
                
                var grouped_by_date = from drive in connecting_tables
                    group drive by drive.Date;

                foreach (var date in grouped_by_date)
                {
                    Console.WriteLine(date.Key);
                    foreach(var drive in date)
                    {
                        Console.WriteLine(drive.Name);
                    }
                    Console.WriteLine();
                }
            }
            else if (action == "3")
            {
                DateTime date_from = new DateTime(2025, 5, 2);
                DateTime date_to = new DateTime(2025, 5, 7);

                var in_period = from service in car_service
                    where service.Date >= date_from && service.Date <= date_to
                    select service.Cost;

                int res = in_period.Sum();

                Console.WriteLine("За выбранный период стоимость услуг составила {0}", res);
                Console.WriteLine();
            }
            else if (action == "4")
            {
                break;
            }
            else { Console.WriteLine("Некорректный ввод. Выберите из пунктов 1 - 4."); }
        }
    }
}
