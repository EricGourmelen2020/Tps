using Module03_TP01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module03_TP01
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).AddFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).AddFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).AddFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).AddFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).AddFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
        static void Main(string[] args)
        {
            InitialiserDatas();

            System.Console.WriteLine("Module03_TP01 Les auteurs");
            System.Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            System.Console.WriteLine("\nLes prénoms des auteurs ayant un nom de famille commençant par 'G'\n");

            IEnumerable<Auteur> prenomAuteurG = ListeAuteurs.Where(a => a.Nom[0] == 'G');

            foreach (Auteur auteur in prenomAuteurG)
            {
                Console.WriteLine(auteur.Prenom);
            }

            //System.Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            //System.Console.WriteLine("\nl'auteur ayant écrit le plus de livres\n");

            //Auteur auteurPlusLivres = ListeAuteurs.OrderByDescending(a => ListeLivres.Count(l => l.Auteur == a)).FirstOrDefault();

            //Console.WriteLine($"{auteurPlusLivres.Nom} {auteurPlusLivres.Prenom}");

            //System.Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            //System.Console.WriteLine("\nafficher le nombre moyen de pages par auteur\n");

            System.Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            System.Console.WriteLine("\nLe titre du livre avec le plus de pages\n");

            Livre livrePlusPages = ListeLivres.OrderByDescending(l => l.NbPages).First();

            System.Console.WriteLine(livrePlusPages.Titre);

            System.Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            System.Console.WriteLine("\nLa moyenne des factures\n");

            var moyenneFactures = ListeAuteurs.Sum(a => a.Factures.Sum(f => f.Montant)) / ListeAuteurs.SelectMany(a => a.Factures).Count();

            System.Console.WriteLine(moyenneFactures);

            System.Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            System.Console.WriteLine("\nla liste des auteurs et leurs livres\n");

            foreach (Auteur a in ListeAuteurs)
            {
                Console.WriteLine($"\n{a.Nom} {a.Prenom} à écrit :");
                foreach (Livre l in ListeLivres)
                {
                    if (a.Nom == l.Auteur.Nom)
                    {
                        Console.WriteLine($"-{l.Titre}");
                    }
                }
            }

            System.Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            System.Console.WriteLine("\nla liste des livres triés par ordre alphabétique\n");

            IEnumerable<Livre> listeLivreTrie = ListeLivres.OrderBy(a => a.Titre);

            foreach (Livre l in listeLivreTrie)
            {
                Console.WriteLine($"-{l.Titre}");
            }

            System.Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            System.Console.WriteLine("\nla liste des livres dont le nombre de pages est supérieur à la moyenne\n");

            IEnumerable<Livre> listeLivreSupNbPage = ListeLivres.Where( l => (l.NbPages) > (ListeLivres.Sum(li => li.NbPages)/ ListeLivres.Count()));

            foreach (Livre l in listeLivreSupNbPage)
            {
                Console.WriteLine($"-{l.Titre}");
            }

            //System.Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            //System.Console.WriteLine("\nl'auteur ayant écrit le moins de livres\n");

            //Auteur auteurMoinsLivres = ListeAuteurs.OrderBy(a => ListeLivres.Count(l => l.Auteur == a)).FirstOrDefault();

            //Console.WriteLine($"{auteurMoinsLivres.Nom} {auteurMoinsLivres.Prenom}");

            Console.ReadKey();


        }
    }
}
