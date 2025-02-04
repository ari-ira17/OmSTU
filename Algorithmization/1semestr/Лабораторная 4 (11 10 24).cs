using System;
using System.Reflection.Emit;
class Program_1 {
    static void Main() 
    {
        Console.WriteLine("Введите число элементов");
        int nums_of_numbers = Convert.ToInt32(Console.ReadLine());
        
        int counter = 0;
        while (counter < nums_of_numbers)
        {           
            counter += 1;
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num = num1;

            if (num1 <= 0)
            {
                break;
            }

            //определяем старшую степень
            int deg = 0;
            while (num1 > 0)
            {
                deg ++;
                num1 = num1 / 10;
            }
            deg -= 1;   //есть 10^0

            //прибавляем наоборот циферки (как разложение по степеням 10)
            int new_num = 0;    //будущее число
            while (num > 0)
            {
                if ((num % 10) % 2 == 0)
                {
                    num = num / 10;
                    deg -= 1;
                    new_num = new_num / 10;
                }
                else
                {
                   int deg_10 = (int)Math.Pow(10, deg);
                    new_num += (num % 10) * deg_10;
                    deg -= 1;
                    num = num / 10;
                } 
            }
            
            if (new_num == 0)
            {
                Console.WriteLine("Все цифры числа чётные");
            }
            else
            {
                Console.WriteLine(new_num);
            }

        }
  }
}
