namespace TP01
{
    internal class Carre : Forme
    {
        public int Longueur { get; set; }

        public override double GetAire()
        {
            return Longueur * Longueur;
        }

        public override double GetPerimetre()
        {
            return Longueur * 4;
        }
        public override string ToString()
        {
            return $"Carre de coté {Longueur} \nAire = {GetAire()} \nPérimètre = {GetPerimetre()}";
        }
    }
}