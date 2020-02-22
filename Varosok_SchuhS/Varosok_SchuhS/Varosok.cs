using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varosok_SchuhS
{
    class Varosok
    {
        //Város;Ország;Népesség
        public string Varos;
        public string Orszag;
        public double Nepesseg;

        public Varosok(string sor)
        {
            var dbok = sor.Split(';');
            this.Varos = dbok[0];
            this.Orszag = dbok[1];
            this.Nepesseg = double.Parse(dbok[2]);

        }
    }
}
