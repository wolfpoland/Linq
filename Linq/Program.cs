﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        delegate void Delegato(string imcio);
        static void Main(string[] args)
        {
            int[] tabo = new[] { 1,9,3,2,6,4,8,7,10 };
            string[] tekst = new[] { "ala", "ma", "kota", "koto", "mato", "aleo","ziza" };
            var zapytanie = tabo.Select(n => n).ToArray();
            wyswietalnie(zapytanie);
         
            Console.WriteLine("Teraz sortowanie: ");
            var zap = tabo.Select(n => n).OrderBy(b => b).ToArray();
            wyswietalnie(zap);

            Console.WriteLine("Sortowanie malejaco: ");
            var zap2 = tabo.OrderByDescending(b => b).ToArray();
            wyswietalnie(zap2);

            Console.WriteLine("Sobie wybiore i jeszcze wezme z tamtego: ");
            var zap3 = zap2.Where(n => n <= 5).ToArray();
            wyswietalnie(zap3);
           

            Console.WriteLine("Pora na zabwe z tekstem: ");
            var zap4 = tekst.Where(n => n.Length <= 3).OrderByDescending(b=> b).ToArray();
            wyswietalnie(zap4);

            Console.WriteLine("Inna forma zapytania: ");
            var zap5 = from wyraz in tekst
                       where wyraz.Length >= 3
                       orderby wyraz
                       select wyraz;
            wyswietalnie(zap5.ToArray());

            Console.WriteLine("Zlozne zapytanie (sortowanie alfaberyczne po trzeciej cyfrze: ");

            var zap6 = tekst.Where(x=> x.Length >=3).OrderBy(x => x[2]).ToArray();
            wyswietalnie(zap6);

            Console.WriteLine(" Zlozeone z obietami: ");

            List<Car> garaz = new List<Car>
            {
                new Car("Seat",Rodzaj.Osobowy,10000,"Szary"),
                new Car("Renault", Rodzaj.Osobowy,30000,"Czerwony"),
                new Car("Tatra",Rodzaj.Transportowy,15000,"Zielony"),
                new Car("Solar",Rodzaj.Psazerowy,30000,"Zolty"),
                new Car("Skuter",Rodzaj.Osobowy,10000,"Pinkowy"),
                new Car("Renault", Rodzaj.Osobowy,5000,"Zielony"),
                new Car("Toyota",Rodzaj.Osobowy,15000,"Zielen"),
                new Car("Solar",Rodzaj.Psazerowy,35000,"Zolty")

            };

            wyswietalnie(garaz);
            var zap7 = garaz.Where(a => a.Cena < 30000).Where(b => b.Kolor.Equals("Zielony")).Where(c => c.Rodzaj == Rodzaj.Osobowy).ToList();
            Console.WriteLine("Okreslone zapytanie: ");
            wyswietalnie(zap7);

            Console.WriteLine("Testowanie: ");

            Delegato del = (string imie) =>
             {
                 Console.WriteLine("Witaj : " + imie);
             };
            Console.Write("Podaj imie: ");
            string imcio = Console.ReadLine();
            del(imcio);

            var zp8 = (from Car in garaz
                      where Car.Cena > 10000
                      orderby Car.Cena
                      select Car).ToList();
            
            wyswietalnie(zp8);

            Console.WriteLine("Testowanie Kalkulowania: ");
            Console.WriteLine("Srednia cena za samochody: {0}",garaz.Average(p=> p.Cena));
            Console.WriteLine("Minimalna cena za samochod: {0}", garaz.Min(p => p.Cena));
            Console.WriteLine("Maksymalna cena za samochod: {0}", garaz.Max(p => p.Cena));
            Console.WriteLine("Na koniec juz ilosc: {0}", garaz.Count);
            List<Opony> lista = new List<Opony>
            {
                new Opony { nazwa="Chujomatakałaki", producent="Jokohama", rozmiar=20 },
                 new Opony { nazwa="Stoperany", producent="Pierdzielnij", rozmiar=20 },
                  new Opony { nazwa="Kombajnowe", producent="Trakco", rozmiar=20 }
            };
            var fuzja = from Oponka in lista
                        join Samo in garaz
                        on Oponka.Rodzaj equals Samo.Rodzaj
                        select new
                        {
                            Samo.Marka,
                            Samo.Rodzaj,
                            Samo.Kolor,
                            Samo.Cena,
                            Oponka.nazwa,
                            Oponka.producent,
                            Oponka.rozmiar

                        };


            foreach(var item in fuzja)
            {
                Console.WriteLine(item.Marka);
                Console.WriteLine(item.Marka);
            }



            Console.ReadKey();
        }
        public static void wyswietalnie(int[] tab)
        {
            int no = 0;
            foreach (int item in tab)
            {
                Console.WriteLine("[{0}]: {1}", no, item);
                no++;
            }
        }
        public static void wyswietalnie(string[] tab)
        {
            int no = 0;
            foreach (string item in tab)
            {
                Console.WriteLine("[{0}]: {1}", no, item);
                no++;
            }
        }
        public static void wyswietalnie(List<Car> tab)
        {
            int no = 0;
            Domin max = new Domin();
            foreach (Car item in tab)
            {
                if (item.Marka.Length > max.Max)
                {
                    max.Max = item.Marka.Length;
                    max.tmp = item;
                    max.wiadomosc = item.Marka.ToString();
                }
                if(item.Kolor.Length > max.Max)
                {
                    max.Max = item.Kolor.Length;
                    max.tmp = item;
                    max.wiadomosc = item.Kolor.ToString();
                }
                if (item.Rodzaj.ToString().Length > max.Max)
                {
                    max.Max = item.Rodzaj.ToString().Length;
                    max.tmp = item;
                    max.wiadomosc = item.Rodzaj.ToString();
                }
                if (item.Cena.ToString().Length > max.Max)
                {
                    max.Max = item.Cena.ToString().Length;
                    max.tmp = item;
                    max.wiadomosc = item.Cena.ToString();
                }

            }
            
            Console.WriteLine("Wyswietlam maksa: \n Maksymalan przerwa: {0} \n Car ktory mial przerwe: {1} \n Ta wiadomosc {2} \n",max.Max,max.tmp.ToString(),max.wiadomosc);
            int kreski = (5+max.Max * 4) + 12;
            
            //var ilosc = tab.ForEach(a=> a.ToString().Length);
            int roznica=0;
            string tmp = "";
            string tmp2 = "";
            string tmp3 = "";
            string tmp4 = "";
            for (int n = 0; n < kreski; n++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            foreach (Car item in tab)
            {
                if (item.Marka.ToString().Length <= max.Max)
                {
                    tmp4 = item.Marka.ToString();
                    roznica = max.Max - item.Marka.ToString().Length;
                    for(int m = 0; m < roznica; m++)
                    {
                        tmp4 += " ";
                    }
                }
                if (item.Rodzaj.ToString().Length <= max.Max)
                {
                    tmp = item.Rodzaj.ToString();
                    roznica = max.Max - item.Rodzaj.ToString().Length;
                    for (int m = 0; m < roznica; m++)
                    {
                        tmp += " ";
                    }
                }
                if (item.Cena.ToString().Length <= max.Max)
                {
                    tmp2 = item.Cena.ToString();
                    roznica = max.Max - item.Cena.ToString().Length;
                    for (int m = 0; m < roznica; m++)
                    {
                        tmp2 += " ";
                    }
                }
                if (item.Kolor.ToString().Length <= max.Max)
                {
                    tmp3 = item.Kolor.ToString();
                    roznica = max.Max - item.Kolor.ToString().Length;
                    for (int m = 0; m < roznica; m++)
                    {
                        tmp3 += " ";
                    }
                }
                Console.WriteLine("| {0} | {1} | {2} | {3} | {4} |", no,tmp4,tmp,tmp2,tmp3);
                no++;
            }
            for (int n = 0; n < kreski; n++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
     
        }

    }
}
