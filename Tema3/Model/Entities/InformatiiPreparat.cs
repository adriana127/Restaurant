using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3.Model.Entities
{
    public class InformatiiPreparat
    {
        Preparat preparat;
        Categorie categorie;
        Fotografie fotografie;

        public InformatiiPreparat(Preparat preparat, Categorie categorie, Fotografie fotografie)
        {
            this.Preparat = preparat;
            this.Categorie = categorie;
            this.Fotografie = fotografie;
        }

        public Preparat Preparat { get => preparat; set => preparat = value; }
        public Categorie Categorie { get => categorie; set => categorie = value; }
        public Fotografie Fotografie { get => fotografie; set => fotografie = value; }
    }
}
