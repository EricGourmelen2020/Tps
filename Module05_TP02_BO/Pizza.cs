using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module05_TP02_BO
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public Pate Pate { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public Pizza()
        {
        }

        public Pizza(string nom, Pate pate, List<Ingredient> ingredients)
        {
            Nom = nom;
            Pate = pate;
            Ingredients = ingredients;
        }

        public Pizza(int id, string nom, Pate pate, List<Ingredient> ingredients)
        {
            Id = id;
            Nom = nom;
            Pate = pate;
            Ingredients = ingredients;
        }
    }
}
