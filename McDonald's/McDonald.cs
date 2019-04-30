using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonald_s
{
    public static class Boole
    {
        public const bool Z_ZESTAWEM = true;
        public const bool BEZ_ZESTAWU = false;
    }
    //pojedyncza instancja jako mcdonald's przyjmujacy zamowienia
    sealed class McDonald
    {
        private int numerek;
        public int ile_w_realizacji = 0;
        private float zarobek = 0.0f;
        private static McDonald instance = null;
        public List<Klient> zestawy = new List<Klient>();
        public int Numerek { get => numerek; }
        private McDonald()
        {
            numerek = 100;
            Console.WriteLine("Witamy w McDonald's!\nZamowienia:");
        }

        public static McDonald Instance
        {
            get
            {
                if (instance == null) instance = new McDonald();
                return instance;
            }
        }

        public void zarob(float cena)
        {
            zarobek += cena;
        }
        //
        public void inkrementuj()
        {
            numerek = (numerek % 100) + 1;
        }

        override
        public string ToString()
        {
            Console.WriteLine("Zamowienia w realizacji:                     Nacisnij q zeby wyjsc");
            string sklep = "";
            string zera;
            int ile = ile_w_realizacji;
            do
            {
                int actual = numerek - ile;
                if ((actual - 10) < 0) zera = "00";
                else if ((actual - 100) < 0) zera = "0";
                else zera = "";
                sklep += zera + actual + "\n";
            } while (ile-- > 0);


            sklep += "        Zarobek: " + zarobek + "PLN";
            return sklep;
        }
    }
}
