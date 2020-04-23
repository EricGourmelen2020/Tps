using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class Samourai : AbstractClass
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        [Display(Name = "Arts martiaux maitrisés")]
        public List<ArtMartial> ArtMartials { get; set; }
    }
}
