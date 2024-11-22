using System;

namespace Tp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le jeu 'Devine le nombre' !");
            bool continuerJeu = true;

            while (continuerJeu)
            {
                // Étape 3 : Personnalisation des bornes
                Console.WriteLine("\nDéfinissez les bornes pour l'intervalle.");
                int minIntervalle = LireBorne("Entrez la borne minimale : ");
                int maxIntervalle = LireBorne("Entrez la borne maximale : ", minIntervalle);

                // Génération du nombre aléatoire à trouver
                Random generateurAleatoire = new Random();
                int nombreCible = generateurAleatoire.Next(minIntervalle, maxIntervalle + 1);

                List<int> tentativesJoueur = new List<int>();
                int nombreTentatives = 0;
                bool aGagne = false;

                Console.WriteLine($"\nDevinez le nombre caché entre {minIntervalle} et {maxIntervalle} !");

                // Étape 2 : Gestion des exceptions et boucle
                while (!aGagne)
                {
                    try
                    {
                        Console.Write("\nFaites votre choix : ");
                        int choixUtilisateur = LireNombre(minIntervalle, maxIntervalle);

                        nombreTentatives++;
                        tentativesJoueur.Add(choixUtilisateur);

                        if (choixUtilisateur == nombreCible)
                        {
                            aGagne = true;
                            Console.WriteLine("\nBravo, vous avez trouvé le nombre caché !");
                        }
                        else
                        {
                            Console.WriteLine("Mauvaise réponse, tentez à nouveau !");
                        }

                        Console.WriteLine($"Vos tentatives précédentes : {string.Join(", ", tentativesJoueur)}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message}");
                    }
                }

                // Calcul de la note
                double scoreFinal = Math.Round((double)(maxIntervalle - minIntervalle + 1) / nombreTentatives, 2);
                Console.WriteLine($"\nVotre score est : {scoreFinal}");

                // Rejouer ?
                string reponseUtilisateur;
                do
                {
                    Console.Write("\nSouhaitez-vous rejouer ? (oui/non) : ");
                    reponseUtilisateur = Console.ReadLine().Trim().ToLower();

                    // Vérification des réponses valides
                    if (string.IsNullOrEmpty(reponseUtilisateur) || (reponseUtilisateur != "oui" && reponseUtilisateur != "o" && reponseUtilisateur != "non" && reponseUtilisateur != "n"))
                    {
                        Console.WriteLine("Réponse invalide. Veuillez réessayer.");
                    }
                }
                while (string.IsNullOrEmpty(reponseUtilisateur) || (reponseUtilisateur != "oui" && reponseUtilisateur != "o" && reponseUtilisateur != "non" && reponseUtilisateur != "n"));

                // Décision de rejouer ou non
                continuerJeu = reponseUtilisateur == "oui" || reponseUtilisateur == "o";
            }

            Console.WriteLine("Merci d'avoir joué ! À bientôt !");
        }

        /// <summary>
        /// Lecture sécurisée d'un nombre entier dans une plage donnée.
        /// </summary>
        static int LireNombre(int min, int max)
        {
            if (!int.TryParse(Console.ReadLine(), out int nombre) || nombre < min || nombre > max)
            {
                throw new ArgumentException($"Veuillez saisir un nombre entre [{min}, {max}].");
            }

            return nombre;
        }

        /// <summary>
        /// Lecture sécurisée d'une borne pour définir l'intervalle.
        /// </summary>
        static int LireBorne(string message, int min = int.MinValue)
        {
            while (true)
            {
                Console.Write(message);
                try
                {
                    int borne = int.Parse(Console.ReadLine());
                    if (borne <= min)
                    {
                        Console.WriteLine($"Veuillez entrer une valeur supérieure à {min}.");
                    }
                    else
                    {
                        return borne;
                    }
                }
                catch
                {
                    Console.WriteLine("Veuillez saisir un nombre entier valide.");
                }
            }
        }
    }
}
