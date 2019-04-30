using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace McDonald_s
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(
                () => {
                    while (true)
                    {
                        Console.WriteLine(McDonald.Instance.ToString());
                        System.Threading.Thread.Sleep(300);
                        Klient bigmac = null;
                        WykonajZamowienie(bigmac);
                        System.Threading.Thread.Sleep(300);
                        Console.Clear();
                    }
                });
            Thread t2 = new Thread(
                () =>
                {
                    while (Console.ReadKey().Key != ConsoleKey.Q) { Console.Write("\r"); }
                    System.Environment.Exit(1);
                });
            t1.Start();
            t2.Start();
        }

        static void WykonajZamowienie(Klient bigmac)
        {
            Random rand = new Random();
            Random ile = new Random();
            int ile_zamow = ile.Next(5);
            int ile_odbierz = ile_zamow / 2;

            for(int i = 0; i < ile_zamow; i++)
            {
                bool czy_zestaw = rand.Next(2) == 1;
                bigmac = new Zestaw(czy_zestaw);
                bigmac.zamow();
                bigmac.zaplac();
            }

            System.Threading.Thread.Sleep(300); //klient zamawia i czeka na kasjera
            for (int i = 0; i < ile_odbierz; i++)
            {
                bigmac.odbierz();
            }
            System.Threading.Thread.Sleep(300); //Klient odbiera zamowienie
        }
    }
}
