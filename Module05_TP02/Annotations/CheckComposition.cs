using Module05_TP02_BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TPModule5_1.Utils;

namespace Module05_TP02.Annotations
{
    public class CheckComposition : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            List<int> ingredientsChoisi = (List<int>)obj;

            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (int ing in ingredientsChoisi)
            {
                ingredients.Add(FakeDbPizza.Instance.Ingredients.FirstOrDefault(i => i.Id == ing));
            }
            if (FakeDbPizza.Instance.Pizzas
                        .Where(p => p.Ingredients.Count() == ingredients.Count())
                        .Where(p => p.Ingredients.Where(i => ingredients.Contains(i)).Count() == ingredients.Count())
                        .Any())
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Une pizza composé de ces ingrédients existe déjà.";
        }


    }
}