using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Module05_TP02_BO;

namespace Module05_TP02.Annotations
{
    public class CheckIngredients : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            List<int> ingredients = (List<int>)obj;
            if (ingredients.Count() < 2 || ingredients.Count() > 5)
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Votre pizza doit avoir entre 2 et 5 ingrédients.";
        }
    }
}