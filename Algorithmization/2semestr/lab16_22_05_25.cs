using System;

class Function
{
    public static bool Is_Polindrom(int num)
    {
        string num_to_string = Convert.ToString(Math.Abs(num));
        string num_reverse = "";

        for (int i = num_to_string.Length - 1; i >= 0; i--)
        {
            num_reverse += num_to_string[i];
        }

        if (num_to_string == num_reverse) { return true; }
        else { return false; }
    }
}

class Laboratory_16_1
{
    unsafe static void Main()  
    {
        int array_length = 5;

        int* nums = stackalloc int[array_length];

        nums[0] = 23;
        nums[1] = 777;
        nums[2] = 99888899;
        nums[3] = 45;
        nums[4] = 1;

        for (int i = 0; i < array_length; i++)
        {
            if (Function.Is_Polindrom(*(nums + i))) { Console.WriteLine(*(nums + i)); }
        }
    }
}


class Laboratory_16_2
{
    unsafe static void Main()
    {
        string[] poetry = new string[4]{"Чем меньше женщину мы любим,", "Тем легче нравимся мы ей", "И тем ее вернее губим", "Средь обольстительных сетей."};

        int* periodicity = stackalloc int[256];

        for (int i = 0; i < 256; i++)
        {
            *(periodicity + i) = 0;
        }

        for (int j = 0; j < poetry.Length; j++)
        {
            string[] line = poetry[j].Split(" ");

            for (int k = 0; k < line.Length; k++)
            {
                char symbol = Convert.ToChar(line[k]);
                int asciiCode = Convert.ToInt32(symbol);
                *(periodicity + asciiCode) += 1;
            }
        }
    }
}
