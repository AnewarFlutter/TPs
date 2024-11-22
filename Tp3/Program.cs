using System;

namespace Tp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Demander les bornes
            int borneInf, borneSup;
            Console.WriteLine("Veuillez saisir la borne inférieure :");
            borneInf = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir la borne supérieure :");
            borneSup = int.Parse(Console.ReadLine());

            // Vérifier que la borne inférieure est inférieure à la borne supérieure
            if (borneInf >= borneSup)
            {
                Console.WriteLine("La borne inférieure doit être inférieure à la borne supérieure. Veuillez réessayer.");
                return;
            }

            // Générer un nombre aléatoire entre borneInf et borneSup
            Random random = new Random();
            int nombreADeviner = random.Next(borneInf, borneSup + 1);

            // Tableau pour stocker les choix déjà faits
            int[] choixFaits = new int[10];
            int index = 0;
            int tentatives = 0;

            while (true)
            {
                try
                {
                    // Demander à l'utilisateur de choisir un nombre dans l'intervalle
                    Console.WriteLine($"Choisissez un nombre entre {borneInf} et {borneSup} :");
                    int nombre = int.Parse(Console.ReadLine());
                    tentatives++;

                    // Vérifier si le nombre est dans la plage correcte
                    if (nombre < borneInf || nombre > borneSup)
                    {
                        // Lever une exception si le nombre n'est pas compris entre borneInf et borneSup
                        throw new Exception($"Saisissez un nombre compris entre {borneInf} et {borneSup}.");
                    }

                    // Afficher le choix fait et le stocker dans le tableau
                    Console.WriteLine($"Vous avez choisi : {nombre}");
                    choixFaits[index++] = nombre;

                    // Afficher les choix précédents
                    Console.WriteLine("Choix déjà faits :");
                    for (int i = 0; i < index; i++)
                    {
                        Console.Write(choixFaits[i] + " ");
                    }
                    Console.WriteLine();

                    // Vérifier si l'utilisateur a trouvé le bon nombre
                    if (nombre == nombreADeviner)
                    {
                        Console.WriteLine("Félicitations, vous avez trouvé le bon nombre !");
                        // Calculer la note
                        double note = (double)(borneSup - borneInf + 1) / tentatives;
                        Console.WriteLine($"Votre note est : {note:F2}");  // Affiche la note avec 2 décimales
                        break;  // Quitte la boucle si le joueur a gagné
                    }
                    else
                    {
                        Console.WriteLine("Ce n'est pas le bon nombre, essayez encore.");
                    }
                }
                catch (Exception ex)
                {
                    // Afficher le message d'erreur si une exception est levée
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
