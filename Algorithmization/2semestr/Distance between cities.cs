using System;
using System.Security.AccessControl;

class Distance_Between_Cities
{
    static void Main()
    {
        Console.Clear();

        string file_path = @"D:\универ\алгоритмизация\2 семестр\РГР 2 семестр\Расстояние между городами\input2.txt";
        string[] lines = File.ReadAllLines(file_path);

        string[] line_1 = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int x1 = Convert.ToInt32(line_1[0]);  
        int y1 = Convert.ToInt32(line_1[1]);  

        string[] line_2 = lines[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int x2 = Convert.ToInt32(line_2[0]);  
        int y2 = Convert.ToInt32(line_2[1]);  

        string[] line_3 = lines[2].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int r = Convert.ToInt32(line_3[0]);  
        

        double fi_1 = x1 / 180.0 * Math.PI;
        double lambda_1 = y1 / 180.0 * Math.PI;
        double fi_2 = x2 / 180.0 * Math.PI;
        double lambda_2 = y2 / 180.0 * Math.PI;
        double lambda = Math.Abs(lambda_1 - lambda_2);
        
        double acosArgument = Math.Sin(fi_1) * Math.Sin(fi_2) + Math.Cos(fi_1) * Math.Cos(fi_2) * Math.Cos(lambda);
        acosArgument = Math.Max(-1.0, Math.Min(1.0, acosArgument)); 
        double angle = Math.Acos(acosArgument);

        double distance = r * angle;
        
        string ans = Convert.ToString(Math.Round(distance, 3));
        File.WriteAllText(@"D:\универ\алгоритмизация\2 семестр\РГР 2 семестр\Расстояние между городами\answer_02.txt", ans);
    }
}
