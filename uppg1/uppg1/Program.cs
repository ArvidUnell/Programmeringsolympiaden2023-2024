using System;
namespace uppg1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ordet?");
            string ord;

            while (true)
            {
                ord = Console.ReadLine();

                if (ord.Length <= 9)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ordet är för långt. Försök igen.");
                }
            }


            Console.WriteLine("Antal upprepningar?");
            byte antal;

            while (true)
            {
                try
                {
                    antal = byte.Parse(Console.ReadLine());
                    if (antal <= 9)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Det är inte ett giltigt tal. Försök igen");
                }
                catch (OverflowException)
                {

                }
                Console.WriteLine("Talet är för stort eller för litet. Försök igen");
            }

            Console.Write("\nSvar: ");

            for (int i = 0; i < antal; i++)
            {
                Console.Write(ord);
            }

            Console.ReadKey();
        }
    }
}