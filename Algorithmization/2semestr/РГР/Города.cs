using System;
using System.IO;

class Cities
{
    static void Main()
    {
        string file_path = @"D:\универ\алгоритмизация\2 семестр\РГР 2 семестр\Города\input_s1_02.txt";
        string[] lines = File.ReadAllLines(file_path);

        string[] first_line = lines[0].Split(' ');
        int n = Convert.ToInt32(first_line[0]);
        int m = Convert.ToInt32(first_line[1]);

        int[][] matrix = new int[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                if (i == j) { matrix[i][j] = 0; }
                else { matrix[i][j] = Int32.MaxValue / 2; }
                
            }
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = lines[i + 1].Split(' ');
            int u = Convert.ToInt32(line[0]);       
            int v = Convert.ToInt32(line[1]);       
            int weight = Convert.ToInt32(line[2]);      

            matrix[u - 1][v - 1] = weight;
            matrix[v - 1][u - 1] = weight;
        }
        
        for (int k = 1; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][k] + matrix[k][j] < matrix[i][j])
                    {
                        matrix[i][j] = matrix[i][k] + matrix[k][j];
                    }
                }
            }
        } 

        int[] maximum = new int[n];
        for (int i = 0; i < n; i++)
        {
            maximum[i] = matrix[i].Max();
        }
        string ans = Convert.ToString(maximum.Max());
        
        File.WriteAllText(@"D:\универ\алгоритмизация\2 семестр\РГР 2 семестр\Города\answer_02.txt", ans);
    }
}
