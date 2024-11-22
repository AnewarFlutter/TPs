using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList listeÉtudiants = new SortedList();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Ajouter un étudiant");
                Console.WriteLine("2. Afficher les informations d’un étudiant");
                Console.WriteLine("3. Afficher les informations de tous les étudiants");
                Console.WriteLine("4. Quitter");
                Console.Write("Choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterÉtudiant(listeÉtudiants);
                        break;
                    case "2":
                        AfficherUnÉtudiant(listeÉtudiants);
                        break;
                    case "3":
                        AfficherTousLesÉtudiants(listeÉtudiants);
                        break;
                    case "4":
                        Console.WriteLine("Programme terminé.");
                        return;
                    default:
                        Console.WriteLine("Choix invalide, réessayez.");
                        break;
                }
            }
        }

        static void AjouterÉtudiant(SortedList liste)
        {
            Console.Write("Entrez le nom de l'étudiant : ");
            string nom = Console.ReadLine();

            Console.Write("Entrez la note de Contrôle Continu : ");
            double noteCC = double.Parse(Console.ReadLine());

            Console.Write("Entrez la note de Devoir : ");
            double noteDevoir = double.Parse(Console.ReadLine());

            Etudiant etudiant = new Etudiant
            {
                Nom = nom,
                NoteCC = noteCC,
                NoteDevoir = noteDevoir
            };

            liste.Add(nom, etudiant);
            Console.WriteLine("Étudiant ajouté avec succès !");
        }

        static void AfficherUnÉtudiant(SortedList liste)
        {
            Console.Write("Entrez le nom de l'étudiant à rechercher : ");
            string nom = Console.ReadLine();

            if (liste.ContainsKey(nom))
            {
                Etudiant etudiant = (Etudiant)liste[nom];
                Console.WriteLine($"Nom: {etudiant.Nom}, Note CC: {etudiant.NoteCC}, Note Devoir: {etudiant.NoteDevoir}, Moyenne: {etudiant.CalculerMoyenne():F2}");
            }
            else
            {
                Console.WriteLine("Étudiant introuvable.");
            }
        }

        static void AfficherTousLesÉtudiants(SortedList liste)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Aucun étudiant dans la liste.");
                return;
            }

            foreach (DictionaryEntry entry in liste)
            {
                Etudiant etudiant = (Etudiant)entry.Value;
                Console.WriteLine($"Nom: {etudiant.Nom}, Note CC: {etudiant.NoteCC}, Note Devoir: {etudiant.NoteDevoir}, Moyenne: {etudiant.CalculerMoyenne():F2}");
            }
        }
    }
}
