using System;
class Laboratory_7
{
    // ввод одной из строк зубчатого массива
    static int[] Elements(int[] elements_inside, int length)
    {
        Console.WriteLine("Введите элементы строки через Enter");
        
        for (int i = 0; i < length; i++)
        {
            elements_inside[i] = Convert.ToInt32(Console.ReadLine());
        }

        return elements_inside;
    }
    

    static void Main()
    {
        Console.WriteLine("Введите число строк массива");
        int rows_main = Convert.ToInt32(Console.ReadLine()); // строки в общем массиве

        int[][] matrix = new int [rows_main][];

        for (int i = 0; i < rows_main; i ++)
        {
            Console.WriteLine("Введите число элементов строки");
            int num_of_elements = Convert.ToInt32(Console.ReadLine());

            int[] elements_inside = new int[num_of_elements];

            matrix[i] = Elements(elements_inside, num_of_elements);
        }   // получили заполеннный зубчатый массив (заполненение через функцию)

        // 1-ое задание
        for (int i = 0; i < rows_main; i++)
        {
            int summ = matrix[i].Sum();
            int maxx = matrix[i].Max();

            if (maxx > summ - maxx)
            {
                Console.WriteLine($"Номер строки, в которой max элемент больше sum - {i + 1}");
            } 
        }

        // 2-ое задание
         for (int i = 0; i < rows_main; i++)
        {
            int length_minn = int.MaxValue; 
            bool found = false; 

            for (int j = 0; j < matrix[i].Length - 1; j++)
            {
                int difference = matrix[i][j] - matrix[i][j + 1]; 

                if (difference > 0)
                {
                    int length = 2; 

                    for (int k = j + 1; k < matrix[i].Length - 1; k++)
                    {
                        if (matrix[i][k] - matrix[i][k + 1] == difference) 
                        {
                            length++;
                        }
                        else
                        {
                            break; 
                        }
                    }

                    if (length >= 2 && length < length_minn)
                    {
                        length_minn = length;
                        found = true;
                    }
                }
            }

            if (found == false)
            {
                Console.WriteLine($"В строке {i + 1} нет равномерно убывающих подпоследовательностей.");
            }
            else
            {
                Console.WriteLine($"Наименьшая длина равномерно убывающей подпоследовательности в строке {i + 1} = {length_minn}");
            }
        }
    }
}
