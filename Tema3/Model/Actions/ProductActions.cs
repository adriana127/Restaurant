using Tema3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.Model.Entities;

namespace Tema3.Model
{
    class ProductActions
    {

        RestaurantEntities1 context = new RestaurantEntities1();


        public ProductActions()
        {
  
        }


        public ObservableCollection<InformatiiPreparat> AllProducts()
        {
            //List<Preparat> preparate = context.Preparats.ToList();
            ObservableCollection<InformatiiPreparat> aux = new ObservableCollection<InformatiiPreparat>();
            foreach (var product in context.Preparats.ToList())
            {
                var poze = context.Fotografies.ToList();
                Fotografie pozaPreparat = new Fotografie();
                foreach (var poza in poze)
                {
                    if (poza.id_preparat == product.id_preparat)
                    {
                        pozaPreparat = poza;
                        break;
                    }
                }
                var categorii = context.Categories.ToList();
                Categorie categoriePreparat = new Categorie();
                foreach (var categorie in categorii)
                {
                    if (categorie.id_categorie == product.id_categorie)
                    {
                        categoriePreparat = categorie;
                        break;
                    }
                }
                aux.Add(new InformatiiPreparat(product, categoriePreparat, pozaPreparat));
            }
            return aux;
        }

        public ObservableCollection<InformatiiPreparat> Cafea(string categorieNume)
        {

            ObservableCollection<InformatiiPreparat> aux = new ObservableCollection<InformatiiPreparat>();
            foreach (var product in context.Preparats.SqlQuery("[AfisarePreparatDupaCategorie] @denumireCategorie",
                new SqlParameter("denumireCategorie", categorieNume)).ToList())
            {
                var poze = context.Fotografies.ToList();
                Fotografie pozaPreparat = new Fotografie();
                foreach (var poza in poze)
                {
                    if (poza.id_preparat == product.id_preparat)
                    {
                        pozaPreparat = poza;
                        break;
                    }
                }
                var categorii = context.Categories.ToList();
                Categorie categoriePreparat = new Categorie();
                foreach (var categorie in categorii)
                {
                    if (categorie.id_categorie == product.id_categorie)
                    {
                        categoriePreparat = categorie;
                        break;
                    }
                }
                aux.Add(new InformatiiPreparat(product, categoriePreparat, pozaPreparat));
            }
            return aux;
        }


        public List<Categorie> Categorii()
        {
            return context.Categories.ToList();
        }

        internal ObservableCollection<InformatiiPreparat> Search(string preparatCautat)
        {
            ObservableCollection<InformatiiPreparat> aux = new ObservableCollection<InformatiiPreparat>();
            foreach (var product in context.Preparats.SqlQuery("[CautaPreparat] @denumire",
                new SqlParameter("denumire", preparatCautat)).ToList())
            {
                var poze = context.Fotografies.ToList();
                Fotografie pozaPreparat = new Fotografie();
                foreach (var poza in poze)
                {
                    if (poza.id_preparat == product.id_preparat)
                    {
                        pozaPreparat = poza;
                        break;
                    }
                }
                var categorii = context.Categories.ToList();
                Categorie categoriePreparat = new Categorie();
                foreach (var categorie in categorii)
                {
                    if (categorie.id_categorie == product.id_categorie)
                    {
                        categoriePreparat = categorie;
                        break;
                    }
                }
                aux.Add(new InformatiiPreparat(product, categoriePreparat, pozaPreparat));

            }
            return aux;
        }
    }
}
