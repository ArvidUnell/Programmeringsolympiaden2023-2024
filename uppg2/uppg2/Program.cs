using System;
namespace uppg2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N?");
            int N;
            while (true)
            {
                try
                {
                    N = int.Parse(Console.ReadLine());
                    break;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Det numre är för stort. Försök igen");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Det är inte ett giltigt tal. Försök igen");
                }
            }

            int antal = 0;

            for (int i = 1; i*i*i + 3*i*i + 2*i < N; i++)
            {
                antal++;
            }

            Console.WriteLine($"Svar: {antal}");

            Console.ReadKey();
        }
    }
}