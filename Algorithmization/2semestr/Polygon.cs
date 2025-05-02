using System;
using System.IO.Pipes;

public class Point
{
    public double X;
    public double Y;

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static List<Point> Sorted_Points(List<Point> points)
    {
        List<Point> sorted_points = points.OrderBy(num => num.X).ThenBy(num => num.Y).ToList();
        return sorted_points;
    }
}

public class Algorithm
{
    static double Cross(Point x, Point y, Point z)
    {
        return (y.X - x.X) * (z.Y - x.Y) - (y.Y - x.Y) * (z.X - x.X);
    }

    public static List<Point> Andrew_Algorithm(List<Point> points)
    {
        if (points == null || points.Count < 3)
            return points;
        
        List<Point> unique_points = new List<Point>(points.Distinct().ToList());
        List<Point> upper = new List<Point>();
        List<Point> lower = new List<Point>();

        foreach (Point p in unique_points)
        {
            while (upper.Count >= 2 && Cross(upper[upper.Count - 2], upper[upper.Count - 1], p) <= 0)
            {
                upper.RemoveAt(upper.Count - 1);
            }
            upper.Add(p);
        }
        
        for (int i = unique_points.Count - 1; i >= 0; i--)
        {
            var p = unique_points[i];
            while (lower.Count >= 2 && Cross(lower[lower.Count - 2], lower[lower.Count - 1], p) <= 0)
            {
                lower.RemoveAt(lower.Count - 1);
            }
            lower.Add(p);
        }

        for (int i = 1; i < lower.Count - 1; i++)
        { upper.Add(lower[i]); }
        upper.Distinct();

        return upper;
    }
}


class Polygon
{
    static void Main()
    {
        Console.Clear();

        string file_path = @"D:\универ\алгоритмизация\2 семестр\РГР 2 семестр\Многоугольник\input_s1_02.txt";
        string[] lines = File.ReadAllLines(file_path);

        List<Point> points = new List<Point>();

        int n = Convert.ToInt32(lines[0]);
        for (int i = 1; i <= n; i++)        
        {
            string[] line = lines[i].Split(' ');
            int x = Convert.ToInt32(line[0]);  
            int y = Convert.ToInt32(line[1]); 
            Point point = new Point(x, y);
            points.Add(point);
        }

        points = Point.Sorted_Points(points);

        if (Algorithm.Andrew_Algorithm(points).Count == 0)
        { Console.WriteLine("Многоугольник не является выпуклым"); }
        else
        {
            points = Algorithm.Andrew_Algorithm(points);
            double area = 0;
        
            for (int i = 0; i < points.Count; i++)
            {
                int j = (i + 1) % points.Count;
                area += (points[i].Y + points[j].Y) * (points[i].X - points[j].X);
            }
            
            string ans = Convert.ToString(Math.Abs(area) / 2);

            File.WriteAllText(@"D:\универ\алгоритмизация\2 семестр\РГР 2 семестр\Многоугольник\answer_02.txt", ans);
        }
    }
}
