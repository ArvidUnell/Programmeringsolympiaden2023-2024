using System;
namespace uppg4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Björns protein?");
            string protein;
            while (true)
            {
                protein = Console.ReadLine();
                if (protein.Length > 32)
                {
                    Console.WriteLine("Proteinet är för långt. Försök igen.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("k?");
            byte k;
            while (true)
            {
                try
                {
                    k = byte.Parse(Console.ReadLine());
                    if (k < 1)
                    {
                        Console.WriteLine("k kan inte vara mindre än 1. Försök igen");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Talet är för stort. Försök igen");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Det är inte ett giltigt tal. Försök igen.");
                }
            }
            if (k > 32) //om det kan klippa det största proteinet behöver det inte vara större än 32
            {
                k = 32;
            }


            byte minSvar = (byte)Math.Ceiling((protein.Length - 1) / (double)k); //initialiseras till om man skulle klippa bort alla bokstäver förutom 1

            string alfabet = "abcdefghijklmnopqrstuvwxyz";
            string bokstäver = "";

            for (int i = 0;i < alfabet.Length; i++) //lägger alla proteinets bokstäver i en string
            {
                if (protein.Contains(alfabet[i]))
                {
                    bokstäver += alfabet[i];
                }
            }

            for (int i = 0; i < bokstäver.Length; i++)
            {
                byte svarBokstav = 0; // minsta antal klippningar för denna bokstav

                byte förstIndex = (byte)protein.IndexOf(bokstäver[i]);
                byte sistIndex = (byte)protein.LastIndexOf(bokstäver[i]);

                svarBokstav += (byte)Math.Ceiling(förstIndex / (double)k); //hur många klipp som krävs för att klippa bort allt innan en sekvens som börjar och slutar med bokstaven
                svarBokstav += (byte)Math.Ceiling((protein.Length-sistIndex-1) / (double)k); //samma fast efter sekvensen

                if (svarBokstav >= minSvar) //om antal klipp inte är minst är de ingen mening att fortsätta denna bokstaven
                {
                    continue;
                }

                string klipptProtein = protein.Substring(förstIndex, sistIndex - förstIndex + 1); //"klipper bort" de bokstäverna

                /*if (klipptProtein.Distinct().Count() > 1) //om det fortfarande finns andra bokstäver
                {
                    byte förstIndexAnnan = (byte)klipptProtein.IndexOf(klipptProtein.Trim(bokstäver[i])[0]);
                    byte sistIndexAnnan = (byte)klipptProtein.LastIndexOf(klipptProtein.Trim(bokstäver[i])[]);
                }*/

                svarBokstav += (byte)Math.Ceiling(klipptProtein.Trim(bokstäver[i]).Length / (double)k);


                if (svarBokstav < minSvar)
                {
                    minSvar = svarBokstav;
                }
            }


            Console.WriteLine($"\nSvar: {minSvar}");

            Console.ReadKey();
        }
    }
}