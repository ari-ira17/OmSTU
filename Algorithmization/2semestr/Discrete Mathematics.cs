using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography.X509Certificates;

class Dicrete_Mathematics
{
    static void Main()
    {
        int n;
        int[] costs = Array.Empty<int>();
        int num_of_roads;
        int[] roads = Array.Empty<int>();

        string file_path = @"D:\универ\алгоритмизация\2 семестр\РГР 2 семестр\input.txt";

        using (StreamReader file = new StreamReader(file_path))
        {
            n = int.Parse(file.ReadLine());
            costs = file.ReadLine().Split(' ').Select(int.Parse).ToArray();
            num_of_roads = int.Parse(file.ReadLine());
            roads = file.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                matrix[i][j] = 0;
            }
        }

        for (int i = 0; i < roads.Length; i+=2)
        {
            int[] edge = {roads[i], roads[i + 1]};
            matrix[edge[0] - 1][edge[1] - 1] = costs[i / 2];
            matrix[edge[1] - 1][edge[0] - 1] = costs[i / 2];
        }
        
        int maximum = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] > maximum)
                { maximum = matrix[i][j]; }
            }
        }
        
        int infinity = maximum * 1000;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 0 && i != j) {matrix[i][j] = infinity;}
            }
        }

        for (int k = 1; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = Math.Min(matrix[i][k] + matrix[k][j], matrix[i][j]);
                }
            }
        }

        int cost = matrix[0][n - 1];
        string ans;
        if (cost == 0)
        { ans = "-1"; }
        else
        { ans = Convert.ToString(cost); }

        File.WriteAllText(@"D:\универ\алгоритмизация\2 семестр\РГР 2 семестр\answer.txt", ans);
    }
}
