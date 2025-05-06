using System;

public class Largest_Rectangle_Algorithm 
{
    public static int Largest_Rectangle_Area(int[] heights) 
    {
        var stack = new Stack<int>();
        stack.Push(-1);
        int max_area = 0;
        
        for (int i = 0; i < heights.Length; i++)
        {
            while (stack.Peek() != -1 && heights[stack.Peek()] >= heights[i])
                max_area = Math.Max(max_area, heights[stack.Pop()] * (i - stack.Peek() - 1));
            stack.Push(i);
        }
        
        while (stack.Peek() != -1)
            max_area = Math.Max(max_area, heights[stack.Pop()] * (heights.Length - stack.Peek() - 1));
        
        return max_area;
    }
}


class Rectangle
{
    static void Main()
    {
        Console.Clear();

        string file_path = @"D:\универ\алгоритмизация\2 семестр\РГР 2 семестр\Прямоугольник\input_s1_02.txt";
        string[] lines = File.ReadAllLines(file_path);


        string[] line_1 = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int x = Convert.ToInt32(line_1[0]);    
        int y = Convert.ToInt32(line_1[1]);    

        int[][] matrix = new int[y][];
        for (int i = 0; i < y; i++)
        {
            matrix[i] = new int[x];
        }


        int n = Convert.ToInt32(lines[1]);     

        for (int i = 2; i < n + 2; i++)
        {
            string[] line = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int x_i = Convert.ToInt32(line[0]) - 1;     
            int y_i = Convert.ToInt32(line[1]) - 1;     
            matrix[y_i][x_i] = 1;
        }


        int[] heights = new int[x];
        int max_area = 0;

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (matrix[i][j] == 1)
                {
                    heights[j] = 0;
                }
                else
                {
                    heights[j]++;
                }
            }
            max_area = Math.Max(max_area, Largest_Rectangle_Algorithm.Largest_Rectangle_Area(heights));
        }
        string ans = Convert.ToString(max_area);

        File.WriteAllText(@"D:\универ\алгоритмизация\2 семестр\РГР 2 семестр\Прямоугольник\answer_02.txt", ans);
    }
}
