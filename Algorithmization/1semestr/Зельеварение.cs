//
using System;
using System.Globalization;
class Potions_Making()
    {
        static void Main()
        {
            Console.WriteLine("Введите число заклинаний");
            int n = Convert.ToInt32(Console.ReadLine());

            string spell = "";

            for (int i = 0; i < n; i ++)
            {
                string spell_now = Console.ReadLine();
                string[] spell_now_splitted = spell_now.Split(" ");     
                string action = spell_now_splitted[0];      

                string ingredients = "";
                for (int j = 1; j < spell_now_splitted.Length; j ++)
                {
                    int counter = 0;
                    foreach (char el in spell_now_splitted[j])
                    {
                        if (Char.IsDigit(el))
                        {
                            counter++;
                        }
                    }
                    
                    if (counter == 0)
                    {
                        ingredients += spell_now_splitted[j];
                    }

                }       

                string Spell_Now_Done(string action, string ingredients)
                {
                    {
                        switch (action)
                        {
                            case "DUST": return "DT" + spell + ingredients + "TD";
                            case "WATER": return "WT" + spell + ingredients + "TW";
                            case "MIX": return "MX" + spell + ingredients + "XM";
                            case "FIRE": return "FR" + spell + ingredients + "RF";
                            default: return spell;
                        }
                    }
                }

                spell = Spell_Now_Done(action, ingredients);
            }

            Console.WriteLine(spell);
        }
    }
