using System;
using System.Collections.Generic;

namespace Tp1
{
    class Program
    {
        static void Main()
        {
            List<(int entier, string hexadecimal)> conversions = new List<(int, string)>();
            bool continuer = true;

            while (continuer)
            {
                Console.Write("Entrez un entier à convertir en hexadécimal (ou tapez 'exit' pour quitter) : ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    continuer = false;
                    break;
                }

                if (int.TryParse(input, out int entier))
                {
                    if (entier < 0)
                    {
                        Console.WriteLine("Veuillez entrer un entier valide (pas de nombre négatif) !");
                        continue;
                    }

                    string hexadecimal = ConvertirEnHexadecimal(entier);
                    conversions.Add((entier, hexadecimal));
                    Console.WriteLine($"L'entier {entier} en hexadécimal est : {hexadecimal}");
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un entier valide !");
                }
            }

            Console.WriteLine("\nListe des conversions :");
            foreach (var (entier, hexadecimal) in conversions)
            {
                Console.WriteLine($"{entier} -> {hexadecimal}");
            }
        }

        static string ConvertirEnHexadecimal(int entier)
        {
            string hexChars = "0123456789ABCDEF";
            List<char> resteHex = new List<char>();

            do
            {
                int reste = entier % 16;
                resteHex.Add(hexChars[reste]);
                entier /= 16;
            } while (entier > 0);

            resteHex.Reverse();
            return new string(resteHex.ToArray());
        }
    }
}
