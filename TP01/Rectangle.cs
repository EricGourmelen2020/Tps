namespace TP01
{
    internal class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }

        public override double GetAire()
        {
            return Largeur*Longueur;
        }

        public override double GetPerimetre()
        {
            return (Largeur+Longueur)*2;
        }

        public override string ToString()
        {
            return $"Rectangle de longueur={Longueur} at largeur={Largeur} \nAire = {GetAire()} \nPérimètre = {GetPerimetre()}";
        }
    }
}