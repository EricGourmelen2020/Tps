using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Module06_TP01.Models
{
    public class SamouraisVM
    {
        public int? Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        [Display(Name = "Arme")]
        public int? ArmeId { get; set; }
        public virtual Arme Arme { get; set; }
        public bool AddWeapon { get; set; }
        public bool Disarm { get; set; }
        public List<SelectListItem> Armes { get; set; } = new List<SelectListItem>();
    }
}