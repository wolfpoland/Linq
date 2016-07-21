using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Car
    {
        public string Marka { get; set; }
        public Rodzaj  Rodzaj { get; set; }
        public double Cena { get; set; }
        public string Kolor  { get; set; }
        public Car(string Marka, Rodzaj Rodzaj, double Cena, string Kolor)
        {
            this.Marka = Marka;
            this.Rodzaj = Rodzaj;
            this.Cena = Cena;
            this.Kolor = Kolor;
        }
        public Car()
        {

        }
        public override string ToString()
        {
            return string.Format("| Marka: {0} | Rodzaj: {1} | Cena: {2} | Kolor: {3} |",Marka,Rodzaj,Cena,Kolor);
        }
    }

    public enum Rodzaj
    {
        Osobowy,
        Transportowy,
        Psazerowy
    }
}
