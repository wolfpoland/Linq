using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
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

            Console.WriteLine("Zlozne zapytanie: ");

            var zap6 = tekst.Where(x=> x.Length >=3).OrderBy(x => x[2]).ToArray();
            wyswietalnie(zap6);


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
    }
}
