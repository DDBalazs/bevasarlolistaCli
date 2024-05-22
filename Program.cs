using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bevasarlolistaCli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Bevasarlolista> lista = new List<Bevasarlolista>();
            FileStream fs = new FileStream("bevasarlolista.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while(!sr.EndOfStream)
            {
                Bevasarlolista b=new Bevasarlolista(sr.ReadLine());
                lista.Add(b);
            }

            sr.Close();
            fs.Close();
            Console.WriteLine("6. feldat: A bevásárlólistán {0} féle termék van.",lista.Count);
            double osszeg = 0;
            for(int i = 0; i < lista.Count; i++)
            {
                osszeg += lista[i].fizetendodarab();
            }
            Console.WriteLine("Végösszeg: {0} Ft",osszeg);

            int db = 0;
            for(int i = 0;i < lista.Count; i++)
            {
                db += lista[i].Mennyiseg;
            }
            Console.WriteLine("9. Feladat: Összesen {0} db termék van",db);

            int max = 0;
            for (int i = 1; i < lista.Count; i++)
            {
                if (lista[i].Egysegar > lista[max].Egysegar)
                {
                    max = i;
                }
            }            
            Console.WriteLine("10. Feladat: A legdrágább termék: {0}, ára {1} Ft.", lista[max].Nev, lista[max].Egysegar);

            fs = new FileStream("fizetendo.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            for(int i=0; i < lista.Count; i++)
            {
                sw.WriteLine(lista[i].Nev + ";" + lista[i].fizetendodarab());
            }
            sw.WriteLine("Végösszeg: "+osszeg);
            sw.Close();
            fs.Close();

            List<Bevasarlolista> olcsolistza = new List<Bevasarlolista>();
            for(int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Egysegar < 500)
                {
                    olcsolistza.Add(lista[i]);
                }
            }
            Console.WriteLine("12. Feladat: {0} db 500Ft-nál olcsóbb termék van",olcsolistza.Count);

            int min = 0;
            for (int i = 1; i < lista.Count; i++)
            {
                if (lista[i].Egysegar < lista[max].Egysegar)
                {
                    max = i;
                }
            }
            Console.WriteLine("13. Feladat: A legolcsóbb termék: {0}, ára {1} Ft.", lista[min].Nev, lista[min].Egysegar);
            int j = 0;
            while(j<lista.Count && lista[j].Mennyiseg < 10)
            {
                j += 1;
            }
            if (j < lista.Count)
            {
                Console.WriteLine("14.Feladat: 10-nél több a {0} termékből van.", lista[j].Nev);
            }
            else
            {
                Console.WriteLine("Nincs ilyen termék.");
            }
            Console.ReadKey();
        }
    }
}
