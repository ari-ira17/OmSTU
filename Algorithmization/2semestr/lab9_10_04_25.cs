using System;

class Array<A>
{
    public A[] Our_Array;
    public int Length;
    public Array(A[] our_array, int length)    
    {
        Our_Array = our_array;
        Length = length;
    }

    public Array<A> Array_Append(A element)
    {
        A[] array_append = new A[Length + 1];
        for (int i = 0; i < Length; i++)
        {
            array_append[i] = Our_Array[i];
        }
        array_append[Length] = element; 
        return new Array<A>(array_append, Length + 1);
    }


    public void Array_Remove(int index)
    {
        if (index >= Length - 1 || index < 0)
        {
            Console.WriteLine("Ошибка: выход за пределы массива!");
        }
        else 
        {
            A[] array_remove = new A[Length - 1];
            for (int j = 0; j < Length - 1; j++)
            {
                if (j < index) { array_remove[j] = Our_Array[j]; }
                else { array_remove[j] = Our_Array[j + 1]; }
            }

            Console.WriteLine();
            foreach (var el in array_remove) { Console.Write(el + " "); }
        }
    }

    public void Array_Show(int index)
    {
        if (index >= Length - 1 || index < 0)
        {
            Console.WriteLine("Ошибка: выход за пределы массива!");
        }
        else
        {
            Console.WriteLine();
            for (int k = 0; k < Length; k++)
            {
                if (k == index) { Console.WriteLine(Our_Array[k]); }
            }
        }
    }
}

class Laboratory_10
{
    static void Main()
    {
        Console.Clear();
        Array<int> int_array = new Array<int>(new int[] {1, 2, 3}, 3);
        int_array = int_array.Array_Append(4);
        
        foreach (var el in int_array.Our_Array)
        {
            Console.Write(el + " ");
        }


        Array<string> string_array = new Array<string>(new string[] {"a", "b", "c", "d"}, 4);
        string_array.Array_Remove(0);

        Array<double> double_array = new Array<double>(new double[] {1.0, 1.1, 1.2, 1.3, 1.4}, 5);
        double_array.Array_Show(1);
        
    }
}