using System;

namespace TP01
{
    internal class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override double GetAire()
        {
            return Rayon * Rayon * Math.PI;
        }

        public override double GetPerimetre()
        {
            return 2 * Rayon * Math.PI;
        }

        public override string ToString()
        {
            return $"Cercle de rayon {Rayon} \nAire = {GetAire()} \nPérimètre = {GetPerimetre()}";
        }
    }
}