using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3.Model.Entities
{
    class InformatiiCos
    {
        string denumire;
        int bucati;
        double pret;

        public InformatiiCos(string denumire, int bucati, double pret)
        {
            this.Denumire = denumire;
            this.Bucati = bucati;
            this.Pret = pret;
        }

        public string Denumire { get => denumire; set => denumire = value; }
        public int Bucati { get => bucati; set => bucati = value; }
        public double Pret { get => pret; set => pret = value; }
    }
}
