using System;
using System.IO;
using System.Text;

class Laboratory_11
{
    static void Main()
    {
        Console.Clear();
        
        string file_path = @"D:\универ\алгоритмизация\2 семестр\lab11_24_04_25\lab11_lines.txt";
        string[] lines = File.ReadAllLines(file_path);
        List<string> approved_lines = new List<string>();
        
        foreach (string line in lines)
        {
            char[] line_elements = line.ToCharArray(); // 'a' 'b' '1' '2' '3'
            bool even_exist = false;

            for (int i = 0; i < line_elements.Length; i++)
            {
                string s = "";
                if (char.IsDigit(line_elements[i]))
                {
                    s += Convert.ToString(line_elements[i]);
                    while ((i + 1) < line_elements.Length && char.IsDigit(line_elements[i + 1]))
                    {
                        s += Convert.ToString(line_elements[i + 1]);
                        i ++;
                    }
                    int num = Convert.ToInt32(s);
                    if (num % 2 == 0) { even_exist = true; }
                }
            }
            if (even_exist) { approved_lines.Add(line); }
        }

        File.WriteAllLines(@"D:\универ\алгоритмизация\2 семестр\lab11_24_04_25\lab11_approved_lines.txt", approved_lines);

        string read_approved_lines = File.ReadAllText(@"D:\универ\алгоритмизация\2 семестр\lab11_24_04_25\lab11_approved_lines.txt");
        Console.WriteLine("Строки, содержащие четные числа:");
        Console.WriteLine(read_approved_lines); 
    }
}
