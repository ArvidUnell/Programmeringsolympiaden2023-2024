using System;
namespace uppg3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n?");
            int n;
            while (true)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n >= 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Talet är för litet. Försök igen.");
                    }
                }
                catch
                {
                    Console.WriteLine("Det är inte ett giltigt tal. Försök igen.");
                }
            }

            Console.WriteLine("m?");
            byte m;
            while (true)
            {
                try
                {
                    m = byte.Parse(Console.ReadLine());
                    if (m <= 6 && m >= 1)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Det är inte ett giltigt tal. Försök igen.");
                    continue;
                }
                catch (OverflowException)
                {

                }
                Console.WriteLine("Talet är för stort eller för litet. Försök igen.");
            }

            char[,] torg = new char[m,n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Rad {i+1}?");
                string rad = Console.ReadLine();

                while (true)
                {
                    try
                    {
                        for (int j = 0; j < m; j++)
                        {
                            torg[j, i] = rad[j];
                        }
                        break;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Du skrev in för få element. Försök igen");
                    }
                }
            }


            int nux = 0;
            int nuy = 0;
            string svar = "";
            bool hittadx = false;
            bool hittady = false;

            if (torg[0,0] != '.')
            {
                svar += torg[0, 0];
            }
            while (!(nux == m-1 && nuy == n-1) && (nux < m && nuy <n))
            {
                for (int i = nux+1; i < m ; i++) //kollar efter bokstav till höger
                {
                    if (torg[i,nuy] != '.')
                    {
                        nux = i;
                        svar += torg[i, nuy];
                        hittadx = true;
                        break;
                    }
                }

                if (!hittadx)
                {
                    for (int i = nuy + 1; i < n; i++) //kollar efter bokstav neråt endast om ingen hittades till höger
                    {
                        if (torg[nux, i] != '.')
                        {
                            nuy = i;
                            svar += torg[nux, i];
                            hittady = true;
                            break;
                        }
                    }
                }

                if (hittadx == false && hittady == false) 
                {
                    nux++;
                }

                hittadx = false;
                hittady = false;
            }

            Console.WriteLine($"\nSvar: {svar}");

            Console.ReadKey();
        }
    }
}