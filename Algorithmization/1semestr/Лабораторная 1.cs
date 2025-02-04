using System;
using System.Reflection.Emit;
class Program {
    static void Main() {
        // №1
        int a, b;
        a = Convert.ToInt32(Console.ReadLine());
        b = Convert.ToInt32(Console.ReadLine());
        a = a * b;
        b = a / b;
        a = a / b;
        Console.WriteLine(a);
        Console.WriteLine(b);

        // №2
        // int a, b, m;
        // a = Convert.ToInt32(Console.ReadLine());
        // b = Convert.ToInt32(Console.ReadLine());
        // a = Math.Abs(a);
        // b = Math.Abs(b);
        // m = (a + b + Math.Abs(a - b))/2;

        // Console.WriteLine(m);
    
        // №3
        // int l, m, p, n, c;
        // l = Convert.ToInt32(Console.ReadLine());
        // m = Convert.ToInt32(Console.ReadLine());
        // p = Convert.ToInt32(Console.ReadLine());
        // n = Convert.ToInt32(Console.ReadLine());

        // c = 2*n*p + l*(n + 1)*n + 2*n*m;
        // Console.WriteLine(c);
        
    }
}
