using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonald_s
{
    class Zestaw : Klient
    {
        protected int numerek;
        protected float cena;
        protected bool czy_zestaw;

        public float Cena { get => cena; set => cena = value; }

        int Klient.Numerek { get => numerek; set => numerek = value; }

        public Zestaw(bool czy_zestaw)
        {
            this.czy_zestaw = czy_zestaw;
            if (this.czy_zestaw)
                cena = 8.99f;
            else cena = 3.99f;
        }


        void Klient.odbierz()
        {
            Console.WriteLine("Klient odebral zamowienie");
            McDonald.Instance.ile_w_realizacji--;
        }
        void Klient.zaplac()
        {
            McDonald.Instance.zarob(cena);
            McDonald.Instance.ile_w_realizacji++;
        }
        void Klient.zamow()
        {
            McDonald.Instance.inkrementuj();
            numerek = McDonald.Instance.Numerek;
            if(czy_zestaw)
            Console.WriteLine("Klient zamowil burgera z zestawem");
            else
            Console.WriteLine("Klient zamowil burgera bez zestawu");
        }

    }
}
