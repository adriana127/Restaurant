using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3.Model.Entities
{
    class InformatiiComanda
    {

        string destinatar;
        string adresa;
        string numar;
        string status;
        double pret;
        int numarcomanda;

        public InformatiiComanda(string destinatar, string adresa,string numar, string status, double pret, int numarcomanda)
        {
            this.destinatar = destinatar;
            this.adresa = adresa;
            this.status = status;
            this.pret = pret;
            this.numarcomanda = numarcomanda;
            this.numar = numar;
        }

        public string Destinatar { get => destinatar; set => destinatar = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string Status { get => status; set => status = value; }
        public string Numar { get => numar; set => numar = value; }

        public double Pret { get => pret; set => pret = value; }
        public int Numarcomanda { get => numarcomanda; set => numarcomanda = value; }
    }
}
