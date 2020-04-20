using Module05_TP02_BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Module05_TP02.Models
{
    public class CreatePizzaVM
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public int IdPate { get; set; }
        public string Erreur { get; set; }
        [Required]
        public List<int> IngredientsChoisis { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Pate> Pates { get; set; }
    };
}