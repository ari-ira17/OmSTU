using System;
delegate void Finish_Handler();     

class Finish_Event()        
{
    public event Finish_Handler Event;
    public void On_Finish_Event()   
    {
        if (Event != null)
        {
            Event();
        }
    }
}

class Finish_Check
{
    public static bool Checking(string name, int speed, int time, ref int location, int end)
    {
        location += speed * time;     
        if (location >= end) 
        {
            Console.WriteLine("Победитель - {0}", name);
            return false;
        }
        return true;
    }
}

public class Car
{
    public string Name;
    public int Speed;
    public int Location;
    public Car(string name, int speed, int location)
    {
        Name = name;
        Speed = speed;
        Location = location;
    }
}

class Laboratory_7
{
    static void Main()
    {
        Finish_Event finish_event = new Finish_Event();
        var random = new Random();

        int start = 0;
        int end = 100_000;
        int time = 30;
        bool flag = true;

        Car car_1 = new Car("car_1", random.Next(0, 60), start);
        Car car_2 = new Car("car_2", random.Next(0, 60), start);
        Car car_3 = new Car("car_3", random.Next(0, 60), start);

        finish_event.Event += () => flag &= Finish_Check.Checking(car_1.Name, car_1.Speed, time, ref car_1.Location, end);
        finish_event.Event += () => flag &= Finish_Check.Checking(car_2.Name, car_2.Speed, time, ref car_2.Location, end);
        finish_event.Event += () => flag &= Finish_Check.Checking(car_3.Name, car_3.Speed, time, ref car_3.Location, end);

        while (flag)
        {
            car_1.Speed = random.Next(0, 60);
            Console.WriteLine("car_1.Speed = {0}, car_1.Location = {1}", car_1.Speed, car_1.Location);
            car_2.Speed = random.Next(0, 60);
            Console.WriteLine("car_2.Speed = {0}, car_2.Location = {1}", car_2.Speed, car_2.Location);
            car_3.Speed = random.Next(0, 60);
            Console.WriteLine("car_3.Speed = {0}, car_3.Location = {1}", car_3.Speed, car_3.Location);
            
            finish_event.On_Finish_Event();
        }
    }
}
