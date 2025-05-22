using System;
using System.Diagnostics.Contracts;

class Laptop_1
{
    public int Laptop_Id;
    public string OS;
    public Laptop_1(int id, string os)
    {
        Laptop_Id = id;
        OS = os;
    }
}

class Laptop_2
{
    public int Laptop_Id;
    public string Producer;
    public Laptop_2(int id, string pr)
    {
        Laptop_Id = id;
        Producer = pr;
    }
}

class Students
{
    public int Student_ID;
    public int Class;
    public string Name;
    public bool Has_A_Laptop;
    public string OS;
    public int Producer_Id;
    public Students(int s_id, int cl, string name, bool h_a_l, string os, int pr_id)
    {
        Student_ID = s_id;
        Class = cl;
        Name = name;
        Has_A_Laptop = h_a_l;
        OS = os;
        Producer_Id = pr_id;
    }   
    public Students(int s_id, int cl, string name, bool h_a_l)
    {
        Student_ID = s_id;
        Class = cl;
        Name = name;
        Has_A_Laptop = h_a_l;
        OS = "";
        Producer_Id = 0;
    }   
}


class Laboratory_14
{
    static void Main()
    {
        Console.Clear();

        List<Laptop_1> laptops_1 = new List<Laptop_1>();
        List<Laptop_2> laptops_2 = new List<Laptop_2>();
        List<Students> students = new List<Students>();

        laptops_1.Add(new Laptop_1(1, "windows 10"));
        laptops_1.Add(new Laptop_1(2, "windows 11"));
        laptops_1.Add(new Laptop_1(3, "sequoia 15"));

        laptops_2.Add(new Laptop_2(1, "asus"));
        laptops_2.Add(new Laptop_2(2, "lenovo"));
        laptops_2.Add(new Laptop_2(3, "apple"));

        students.Add(new Students(1, 8, "Ivanov ER", true, "windows 10", 10));
        students.Add(new Students(2, 10, "Sidorov BK", true, "windows 11", 20));
        students.Add(new Students(3, 11, "Egorov TL", true, "sequoia 15", 30));
        students.Add(new Students(4, 11, "Popov NM", true, "sequoia 15", 30));
        students.Add(new Students(3, 11, "Smirnov DP", false));

        string action = "";

        while (true)
        {
            Console.WriteLine("Mеню:");
            Console.WriteLine("1. Выдать список учеников, которые имеют ноутбук");
            Console.WriteLine("2. Выдать список учеников, сгруппированных по классу и отсортированных по марке ноутбука внутри класса");
            Console.WriteLine("3. Выборка учеников, у которых марка ноута соответсвует заданному");
            Console.WriteLine("4. Группировка учеников по типу ОС");
            Console.WriteLine("5. Выход");
            Console.WriteLine("Выберите действие из меню");

            action = Console.ReadLine();

            if (action == "1")
            {
                var has_a_laptop = from student in students
                    where student.Has_A_Laptop == true
                    select student;
                
                Console.WriteLine("Студенты, имеющие ноутбук:");
                foreach (Students student in has_a_laptop)
                {
                    Console.WriteLine(student.Name);
                }
            }
            else if (action == "2")
            {
                var has_a_laptop = from student in students
                    where student.Has_A_Laptop == true
                    select student;
                
                var name_class_os = from student in has_a_laptop
                    join l_1 in laptops_1 on student.OS equals l_1.OS
                    select new
                    {
                        Name = student.Name,
                        Class = student.Class,
                        OS = student.OS,
                        Laptop_Id = l_1.Laptop_Id
                    };

                var name_class_producer = from student in name_class_os
                    join l_2 in laptops_2 on student.Laptop_Id equals l_2.Laptop_Id
                    select new
                    {
                        Name = student.Name,
                        Class = student.Class,
                        OS = student.OS,
                        Producer = l_2.Producer
                    };
                
                var grouped = from student in name_class_producer
                         orderby student.Class
                         group student by student.Class into classGroup
                         select new {
                             Class = classGroup.Key,
                             Students = from s in classGroup
                                       orderby s.Producer
                                       select s
                         };

                foreach (var class_group in grouped)
                {
                    Console.WriteLine("Класс: {0}", class_group.Class);
                    foreach (var student in class_group.Students)
                    {
                        Console.WriteLine("{0} - {1}", student.Name, student.Producer);
                    }
                }
            }
            else if (action == "3")
            {
                var has_a_laptop = from student in students
                    where student.Has_A_Laptop == true
                    select student;
                
                var name_class_os = from student in has_a_laptop
                    join l_1 in laptops_1 on student.OS equals l_1.OS
                    select new
                    {
                        Name = student.Name,
                        Laptop_Id = l_1.Laptop_Id
                    };

                var name_class_producer = from student in name_class_os
                    join l_2 in laptops_2 on student.Laptop_Id equals l_2.Laptop_Id
                    select new
                    {
                        Name = student.Name,
                        Producer = l_2.Producer
                    };

                Console.WriteLine("Введите марку ноутбука");
                string producer_from_user = "apple";

                Console.WriteLine("Ученики с заданным ноутбуком:");
                foreach (var student in name_class_producer)
                {
                    if (student.Producer == producer_from_user)
                    {
                        Console.WriteLine(student.Name);
                    }
                }
            }
            else if (action == "4")
            {
                var has_a_laptop = from student in students
                    where student.Has_A_Laptop == true
                    select student;
                
                var grouped_by_os = from student in has_a_laptop
                    group student by student.OS;

                Console.WriteLine("Студенты, сгуппированные по типу ОС");
                foreach (var os in grouped_by_os)
                {
                    Console.WriteLine(os.Key);
                    foreach (var student in os)
                    {
                        Console.WriteLine(student.Name);
                    }
                    Console.WriteLine();
                }
            }
            else if (action == "5")
            {
                break;
            }
            else { Console.WriteLine("Некорректный ввод. Выберите из пунктов 1 - 5."); }
        }
    }
}
