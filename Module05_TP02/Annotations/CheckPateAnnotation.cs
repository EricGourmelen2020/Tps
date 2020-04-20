using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Module05_TP02.Annotations
{
    public class CheckPateAnnotation : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            int pateId = (int)obj;
            if(pateId == 0)
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Vous devez choisir une pâte pour votre pizza.";
        }
    }
}