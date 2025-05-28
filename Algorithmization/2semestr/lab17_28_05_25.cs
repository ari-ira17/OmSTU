using System;
using System.Diagnostics.CodeAnalysis;

unsafe class Functions
{
    public static void LeftOrRight(Phone* phone1, Phone* phone2)
        {
            if (phone2->Id < phone1->Id)
            {
                if (phone1->LeftBranch == null)
                    phone1->LeftBranch = phone2;
                else
                    LeftOrRight(phone1->LeftBranch, phone2);
            }
            else
            {
                if (phone1->RightBranch == null)
                    phone1->RightBranch = phone2;
                else
                    LeftOrRight(phone1->RightBranch, phone2);
            }
        }

    public static void PrintTree(Phone* phone, string branch = "Root")
    {
        if (phone != null)
        {
            if (phone->LeftBranch != null)
            {
                PrintTree(phone->LeftBranch, "Left");          
            }
            
            Console.WriteLine($"ID: {phone->Id}, Operator: {phone->Operator}, Branch: {branch}");
            
            if (phone->RightBranch != null)
            {
                
                PrintTree(phone->RightBranch, "Right");
            }
        }
    }
}

unsafe struct Phone
    {
        public int Id;
        public string Operator;
        public Phone* LeftBranch;
        public Phone* RightBranch;

        public Phone(int id, string op, Phone* l_b = null, Phone* r_b = null)
        {
            Id = id;
            Operator = op;
            LeftBranch = l_b;
            RightBranch = r_b;
        }
    }

class Laboratory_17
{
    unsafe static void Main()
    {
        Console.Clear();

        Phone phone_1 = new Phone(25, "Megafon");
        Phone* head = &phone_1;

        Phone phone_2 = new Phone(27, "MTS");
        Phone phone_3 = new Phone(15, "YOTA");
        Phone phone_4 = new Phone(13, "Tele2");
        Phone phone_5 = new Phone(30, "MTS");

        Functions.LeftOrRight(head, &phone_2);
        Functions.LeftOrRight(head, &phone_3);
        Functions.LeftOrRight(head, &phone_4);
        Functions.LeftOrRight(head, &phone_5);

        Console.WriteLine("Бинарное дерево");
        Functions.PrintTree(head);
    }
}
