
using Module05_TP01.Models;
using System.Collections.Generic;
using System.Linq;

namespace TPModule3
{
    public class Data
    {
        private static Data _instance;
        static readonly object instanceLock = new object();

        private Data()
        {
            InitialiserDatas();
        }

        public static Data Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new Data();
                    }
                }
                return _instance;
            }
        }

        private List<Chat> listeChats = new List<Chat>();

        public List<Chat> ListeChats
        {
            get { return listeChats; }
            set { listeChats = value; }
        }


        private void InitialiserDatas()
        {
            var i = 1;
            ListeChats.Add(new Chat { Id = i++, Nom = "Felix", Age = 3, Couleur = "Roux" });
            ListeChats.Add(new Chat { Id = i++, Nom = "Minette", Age = 1, Couleur = "Noire" });
            ListeChats.Add(new Chat { Id = i++, Nom = "Miss", Age = 10, Couleur = "Blanche" });
            ListeChats.Add(new Chat { Id = i++, Nom = "Garfield", Age = 6, Couleur = "Gris" });
            ListeChats.Add(new Chat { Id = i++, Nom = "Chatran", Age = 4, Couleur = "Fauve" });
            ListeChats.Add(new Chat { Id = i++, Nom = "Minou", Age = 2, Couleur = "Blanc" });
            ListeChats.Add(new Chat { Id = i, Nom = "Bichette", Age = 12, Couleur = "Rousse" });
        }
    }
}
