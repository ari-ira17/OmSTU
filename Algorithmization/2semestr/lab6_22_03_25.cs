using System;

delegate void Border_Crossed_Handler();
class Event
{
    public event Border_Crossed_Handler Border_Crossed;
    public void On_Border_Crossed()
    {
        if (Border_Crossed != null) { Border_Crossed();}
    }
}

class Border_Controller
{
    public static void Checking(int x, int y, int x1, int x2, int y1, int y2, ref bool flag)
    {
        if (x < x1 || x > x2 || y < y1 || y > y2)
        {
            Console.WriteLine("Точка вышла за границы поля!");
            flag = false;
        }
    }
}

class Point
{
    public int X;
    public int Y;
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Laboratory_6
{
    static void Main()
    {
        Point point = new Point(50, 100);
        var random = new Random();
        int x1 = 0;
        int x2 = 1000;
        int y1 = 0;
        int y2 = 1000;
        bool flag = true;

        Event evnt = new Event();
        evnt.Border_Crossed += () => Border_Controller.Checking(point.X, point.Y, x1, x2, y1, y2, ref flag);
        
        while (flag)
        {
            point.X += random.Next(0, 70);
            point.Y += random.Next(0, 70);

            Console.WriteLine("x = {0} y = {1}", point.X, point.Y);
            evnt.On_Border_Crossed();
        }
    }
}
