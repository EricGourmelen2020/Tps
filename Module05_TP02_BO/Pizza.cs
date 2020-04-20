using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module05_TP02_BO
{
    public class Pizza
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
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
