using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Varosok_SchuhS
{
    class Program
    {
        static List<Varosok> VarosokList;
        static Dictionary<string, int> VarosSzokozDict;
        static Dictionary<string, int> Statisztika;
        static List<string> OrszagList;
        static void Main(string[] args)
        {
            Console.WriteLine("\n------------------------------\n");
            Feladat1Beolvasas();
            Console.WriteLine("\n------------------------------\n");
            Feladat2VarosokSzama();
            Console.WriteLine("\n------------------------------\n");
            Feladat3IndiaiVarosokLakossaga();
            Console.WriteLine("\n------------------------------\n");
            Feladat4Maximum();
            Console.WriteLine("\n------------------------------\n");
            Feladat5Magyar();
            Console.WriteLine("\n------------------------------\n");
            Feladat6Ketszokoz();
            Console.WriteLine("\n------------------------------\n");
            Feladat7Statisztika();
            Console.WriteLine("\n------------------------------\n");
            Feladat8Kina();
            Console.WriteLine("\n------------------------------\n");
            Console.ReadKey();
        }

        private static void Feladat8Kina()
        {
            Console.WriteLine("8.Feladat: Kínai városai");
            var sw = new StreamWriter(@"kina.txt",false, Encoding.UTF8);
            Console.WriteLine("Város,Ország,Népesség");
            sw.WriteLine("Város,Ország,Népesség");
            foreach (var v in VarosokList)
            {
                if(v.Orszag.ToLower().Contains("kína"))
                {
                    Console.WriteLine("{0};{1};{2}",v.Varos,v.Orszag,v.Nepesseg);
                    sw.WriteLine("{0};{1};{2}", v.Varos, v.Orszag, v.Nepesseg);
                }
            }
            sw.Close();
        }

        private static void Feladat7Statisztika()
        {
            Console.WriteLine("7.Feladat: Készítsen satisztikát a országok városairól");
            OrszagList = new List<string>();
            Statisztika = new Dictionary<string, int>();
            foreach (var v in VarosokList)
            {
                if(!OrszagList.Contains(v.Orszag))
                {
                    OrszagList.Add(v.Orszag);
                }
            }
           
            foreach (var o in OrszagList)
            {
                int db = 0;
                foreach(var v in VarosokList)
                {
                    if (o==v.Orszag)
                    {
                        db++;
                    }                    
                }
                if (!Statisztika.Keys.Contains(o))
                {
                    Statisztika.Add(o, db);
                }
            }
            foreach (var s in Statisztika)
            {
                Console.WriteLine("{0,-33} := {1} db város", s.Key, s.Value);
            }
        }

        private static void Feladat6Ketszokoz()
        {
            Console.WriteLine("6.Feladat: Határozza meg azokat a várásokat melyek nevében két szóköz van");
            VarosSzokozDict = new Dictionary<string, int>();
            foreach (var v in VarosokList)
            {//Karekterenkénti ellenőrzés minden karaktert egyesével megvizsgálunk a szóban, hogy van-e benne ' ' 
                char Szokoz = ' ';
                int Szokozszam = 0;
                for (int i = 0; i < v.Varos.Length; i++)
                {
                    if (v.Varos[i]==Szokoz)
                    {
                        Szokozszam++;
                    }
                }                
                if(!VarosSzokozDict.Keys.Contains(v.Varos))
                {
                    VarosSzokozDict.Add(v.Varos, Szokozszam);
                }
              /*  if(Szokozszam==1)
                {
                    Console.WriteLine("{0,-20} : {1} szóközök száma", v.Varos, Szokozszam);
                }       */         
            }
            int db = 0;
            foreach (var d in VarosSzokozDict)
           {
                //Console.WriteLine("\t{0,-14} : {1} szóközök száma", d.Key, d.Value);
                if (d.Value==1)
                {
                    db++;
                    Console.WriteLine("\t{0,-20} : {1} szóközök száma", d.Key, d.Value);
                }
            }
            Console.WriteLine("\tEnnyi olyan cáros van aminek a nevében egy szóköz van: {0}", db);
        }

        private static void Feladat5Magyar()
        {
            Console.WriteLine("5.Feladat: Döntse el, hogy az adatok között van-e magyar város");
           /* int db = 0;
            foreach (var v in VarosokList)
            {
                if(v.Orszag=="Magyarország")
                {
                    db++;
                }
            }
            if(db>0)
            {
                Console.WriteLine("\tVan Magyar város a listában");
            }
            else
            {
                Console.WriteLine("\tNincs Magyar város a listában");
            }*/
            int szamlalo =0;
            string Kulcsszo = "magyarország";
            while(szamlalo<VarosokList.Count && !VarosokList[szamlalo].Orszag.ToLower().Contains(Kulcsszo))
            {
                szamlalo++;
            }
            if(szamlalo==VarosokList.Count)
            {
                Console.WriteLine("\tNincs Magyar város a listában");
            }
            else
            {
                Console.WriteLine("\tVan Magyar város a listában");
            }
            
        }
        private static void Feladat4Maximum()
        {
            Console.WriteLine("4.Feladat: A legnagyobb lakosú város");
            string MaxOrszag = "Kutya";
            string MaxVaros = "Cica";
            double MaxLakossag = double.MinValue;
            foreach (var v in VarosokList)
            {
                if(MaxLakossag<v.Nepesseg)
                {
                    MaxLakossag = v.Nepesseg * Math.Pow(10, 6);                   
                    MaxOrszag = v.Orszag;
                    MaxVaros = v.Varos;
                }
            }
            Console.WriteLine("\tA legnagyobb város a listában: {0}\n\tA legnagyobb lakosság: {1} fő\n\tAz ország ahol található: {2}", MaxVaros, MaxLakossag, MaxOrszag);
        }
        private static void Feladat3IndiaiVarosokLakossaga()
        {
            Console.WriteLine("3.Feladat: Határozza ,eg az india városok lakosságának számát");
            double Lakossag = 0;
            foreach (var v in VarosokList)
            {
                if(v.Orszag.Contains("India"))
                {
                    Lakossag += v.Nepesseg*Math.Pow(10,6);
                }
            }
            Console.WriteLine("\tAz indiai városok lakossága: {0} fő",Lakossag );
        }

        private static void Feladat2VarosokSzama()
        {
            Console.WriteLine("2.Feladat: Határozza meg, hány város van a listában");
            Console.WriteLine("\tA városok száma: {0} db", VarosokList.Count);
        }

        private static void Feladat1Beolvasas()
        {
            Console.WriteLine("1.Feladat: Beolvasás");
            VarosokList = new List<Varosok>();
            var sr = new StreamReader(@"varosok.csv", Encoding.UTF8);
            int db = 0;
            while(!sr.EndOfStream)
            {
                db++;
                VarosokList.Add(new Varosok(sr.ReadLine()));
            }
            sr.Close();
            if(db>0)
            {
                Console.WriteLine("\tSikeres beolvasás, beolvasott sorok száma: {0}", db);
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás, beolvasott sorok száma: {0}", db);
            }
        }
    }
}
