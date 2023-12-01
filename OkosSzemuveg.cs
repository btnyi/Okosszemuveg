using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okosszemuveg
{
    internal class OkosSzemuveg
    {
        public string sorszam { get; set; }
        public double kijelzoMeret { get; set; }
        public double procteljes { get; set; }
        public int kameraTeljes { get; set; }
        public string szenzorok { get; set; }
        public string tarhely { get; set; }
        public int uzemido { get; set; }
        public double atvalt() => kameraTeljes * 2.54;
        public int tarh() => int.Parse(tarhely.Split(" ")[0]);
        public string[] szenz => szenzorok.Split(",");
        public int szenkivalogatas() => int.Parse(szenzorok.Split(",")[0]);

        public OkosSzemuveg(string sor)
        {
            string[] v = sor.Split(";");
            sorszam = v[0];
            kijelzoMeret = double.Parse(v[1]);
            procteljes = double.Parse(v[2]);
            kameraTeljes = int.Parse(v[3]);
            szenzorok = v[4];
            tarhely = v[5];
            uzemido = int.Parse(v[6]);
            
        }

        public override string ToString()
        {
            return $"\n Sorszám: {sorszam}, Kijelző mérete: {kijelzoMeret}, Processzor teljesítménye: {procteljes}, Kamera felbontása: {kameraTeljes}, Szenzorok: {szenzorok}, Tárhely mérete: {tarhely}, Üzemidő egy töltéssel: {uzemido} ";
        }

    }
}
