using System;

namespace TP01
{
    internal class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public override double GetPerimetre()
        {
            return A + B + C;
        }

        public override double GetAire()
        {
            double p = GetPerimetre()/2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public override string ToString()
        {
            return $"Triangle de coté A= {A}, B= {B}, C= {C} \nAire = {GetAire()} \nPérimètre = {GetPerimetre()}";
        }


    }
}