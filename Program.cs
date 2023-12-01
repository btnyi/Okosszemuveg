using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Net.Http.Headers;

namespace Okosszemuveg
{
    internal class Program
    {
        static List<OkosSzemuveg> felbontas(List<OkosSzemuveg> a)
        {
            var f1 = a.Where(x => x.kameraTeljes >= 12 && x.procteljes == 2).ToList();
            return f1;
        }
        static (List<OkosSzemuveg>,double) atlag(List<OkosSzemuveg> b)
        {
            var f2 = b.Average(x => x.uzemido);
            var f2b = b.Where(x => x.uzemido > f2).ToList();
            return (f2b,f2);
        
        }
        static List<OkosSzemuveg> tarhely(List<OkosSzemuveg> c)
        {
            return c.Where(x => x.tarh() > 100).ToList();
            
        }    
        static List<OkosSzemuveg> szenzor(List<OkosSzemuveg> d)
        {
            
            return d.OrderBy(x => x.szenzorok).Distinct().ToList();
        
        }
        static List<OkosSzemuveg> TB(List<OkosSzemuveg> e)
        {
           return e.Where(x => x.tarhely.Contains("TB")).ToList();
        }
        static List<OkosSzemuveg> szen(List<OkosSzemuveg> f)
        { 
        return f.Where(x => x.szenzorok.Count() > 3).ToList();
        }
        static List<string> many(List<OkosSzemuveg> g)
        { 
        
            var f11 = g.SelectMany(x => x.szenz)
                .Select(x => (x == "accelerometer") ? "gyorsulásmérő": x)
                .Select(x => (x == "gyroscope") ? "giroszkóp" : x).OrderBy(x => x).Distinct().ToList();
                

            return f11;
        }

        static List<string> many2(List<OkosSzemuveg> h)
        {
            List<string> szenzorlista = new();
            for (var i = 0; i < h.Count; i++)
            {
                for (int a = 0; a < h[i].szenz.Length; a++)
                {
                    if (h[i].szenz[a] == "accelerometer")
                    {
                        szenzorlista.Add("gyorsulásmérő");
                    }
                    else
                    {
                        if (h[i].szenz[a] == "gyroscope")
                        {
                            szenzorlista.Add("giroszkóp");
                        }
                        else 
                        {
                            szenzorlista.Add(h[i].szenz[a]);
                        
                        }
                    }
                    
                }
               
            }

            szenzorlista.Sort();
            var szenzorlistadist = szenzorlista.Distinct().ToList();


            return szenzorlistadist;
        }
        static void Main(string[] args)
        {
            var szemuveg = new List<OkosSzemuveg>();
            using (var sr = new StreamReader(@"..\..\..\src\okosszemuvegek.txt"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    szemuveg.Add(new OkosSzemuveg(sr.ReadLine()));
                }
            
            }

            foreach (var item in szemuveg)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("7. feladat");
            Console.WriteLine($"ennyi van: {felbontas(szemuveg).Count}");

            Console.WriteLine("8. feladat");
            (List<OkosSzemuveg> azAtlag, double f2) = atlag(szemuveg);
            foreach (var item in azAtlag)
            { Console.WriteLine(item);}
            Console.WriteLine($"{f2}%");
            Console.WriteLine($"{(azAtlag.Count)} db");
            Console.WriteLine("10. feladat");
            foreach (var item in tarhely(szemuveg))
            {
                Console.WriteLine($"Sorszama es meret: {item.sorszam} {item.atvalt()}");            
            }
            Console.WriteLine("11.feladat");
            Console.WriteLine(szenzor(szemuveg));
            Console.WriteLine("12. feladat");
            if (TB(szemuveg).Count == 0)
            {
                Console.WriteLine("Nincs ilyen");

            }
            else
            {
                foreach (var item in TB(szemuveg))
                {
                    Console.WriteLine(item);
                }
            }

            using (var sw = new StreamWriter(@"..\..\..\src\kiiras.txt"))
            {
                foreach (var item in szen(szemuveg))
                {
                    sw.WriteLine(item);
                }

            }
            many(szemuveg).ForEach(c => Console.WriteLine(c));
            Console.WriteLine("2. megoldas");
            many2(szemuveg).ForEach(c => Console.WriteLine(c));


        }


    }
}