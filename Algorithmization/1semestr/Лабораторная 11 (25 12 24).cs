    using System;
    using System.Data;
    using System.Security.Cryptography.X509Certificates;
    class Planes
    {
        public string Departure_City;   
        public string City_Of_Arrival; 
        public string Flight_Time;    
        public string Plane_Name;

        public Planes(string departure_city, string city_of_arrival, string flight_time, string plane_name)
        {
            Departure_City = departure_city;
            City_Of_Arrival = city_of_arrival;
            Flight_Time = flight_time;
            Plane_Name = plane_name;
        }
    }

    public class Functions
    {
        public static string[,] Filling()
        {
            Console.WriteLine("Введите число самолетов");
            int n = Convert.ToInt32(Console.ReadLine());
            string[,] planes = new string[n, 4];

            for (int i = 0; i < n; i++)
            {
                string departure_city = "";
                while (departure_city == "")
                {
                    Console.WriteLine("Введите город отправления");
                    departure_city = Console.ReadLine();
                }

                string city_of_arrival = "";
                while (city_of_arrival == "")
                {
                    Console.WriteLine("Введите город прибытия");
                    city_of_arrival = Console.ReadLine();
                }

                string flight_time = "";
                while (flight_time == "")
                {
                    Console.WriteLine("Введите время в пути (в минутах)");
                    flight_time = Console.ReadLine();
                }

                string plane_name = "";
                while (plane_name == "")
                {
                    Console.WriteLine("Введите тип самолета");
                    plane_name = Console.ReadLine();
                }

                Planes our_plane = new Planes(departure_city, city_of_arrival, flight_time, plane_name);
                planes[i, 0] = our_plane.Departure_City;
                planes[i, 1] = our_plane.City_Of_Arrival;
                planes[i, 2] = our_plane.Flight_Time;
                planes[i, 3] = our_plane.Plane_Name;
            }

            Console.WriteLine("\nИнформация о самолетах");
            for (int i = 0; i < n; i ++)
            {
                Console.WriteLine($"Самолет {i + 1}:");
                Console.WriteLine($"Город отправления: {planes[i, 0]}");
                Console.WriteLine($"Город прибытия: {planes[i, 1]}");
                Console.WriteLine($"Время в пути (в минутах): {planes[i, 2]}");
                Console.WriteLine($"Тип самолета: {planes[i, 3]}\n");
            }
            return planes;
        }

        public static void Choosing_Name(string[,] planes)
        {
            Console.WriteLine("Введите тип самолета, по которому осуществим выборку");
            string need_type = Console.ReadLine();
            string[,] planes_for_choosing_name = planes;

            Console.WriteLine($"\nСамолеты типа {need_type}");
            for (int i = 0; i < planes_for_choosing_name.GetLength(0); i++)
            {
                if (planes_for_choosing_name[i, 3] == need_type)
                {
                    Console.WriteLine($"Самолет {i + 1}:");
                    Console.WriteLine($"Город отправления: {planes[i, 0]}");
                    Console.WriteLine($"Город прибытия: {planes[i, 1]}");
                    Console.WriteLine($"Время в пути (в минутах): {planes[i, 2]}");
                    Console.WriteLine($"Тип самолета: {planes[i, 3]}\n");
                }
            }
            
        }
    }

    public class Stations
    {
        public string[,] Planes_Stations;   // сделать массив Plane[] чтобы не извращать код :)
        public string City_Stations;

        public Stations(string[,] planes, string city_stations)
        {
            Planes_Stations = planes;
            City_Stations = city_stations;
        }
        
        public void Where_We_Can_Go()
        {
            Console.WriteLine($"\nИз населенного пункта {City_Stations} можно полететь в следующие города:");

            for (int i = 0; i < Planes_Stations.GetLength(0); i++)
            {
                if (Planes_Stations[i, 0] == City_Stations)
                {
                    Console.WriteLine(Planes_Stations[i, 1]);
                }
                else if (Planes_Stations[i, 1] == City_Stations)
                {
                    Console.WriteLine(Planes_Stations[i, 0]);
                }

            }
        }
    }

    class Laboratory_11
    {
        static void Main()
        {
            string[,] planes = null;
            while (true)
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1. Заполнение");
                Console.WriteLine("2. Выборка по городу назначения");
                Console.WriteLine("3. Выборка по городу типу самолета");
                Console.WriteLine("4. Выход");

                string action = Console.ReadLine();

                if (action == "4") { break; }

                void What_to_do(string action)
                {
                    switch(action)
                    {
                        case "1":
                        planes = Functions.Filling(); 
                        break;

                        case "2":
                        if (planes != null)
                        {
                            Console.WriteLine("Введите город назначения:");
                            string city = Console.ReadLine();
                            Stations station = new Stations(planes, city);  
                            station.Where_We_Can_Go(); 
                        }
                        break;

                        case "3":
                        if (planes != null) {Functions.Choosing_Name(planes);}
                        break;
                    }
                }

                What_to_do(action);
            }
        }
    }
