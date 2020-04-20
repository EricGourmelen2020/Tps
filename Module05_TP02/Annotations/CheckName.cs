using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TPModule5_1.Utils;

namespace Module05_TP02.Annotations
{
    public class CheckName : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            string name = (string)obj;
            if (FakeDbPizza.Instance.Pizzas.Any(p => p.Nom.ToLower() == name))
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Il existe déjà une pizza de ce nom là.";
        }
    }
}