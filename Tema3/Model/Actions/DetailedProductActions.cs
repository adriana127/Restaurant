using Tema3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tema3.Model
{
    class DetailedProductActions
    {

        private DetaliiPreparatViewModel prepContext;
        public DetailedProductActions(DetaliiPreparatViewModel prepContext)
        {
            this.prepContext = prepContext;
        }

        public ObservableCollection<Alergen> Alergeni(string denumire)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            var alergeniPreparat = context.AlergenPreparats.SqlQuery("[AfisareListaAlergeniPreparat] @denumirePreparat", new SqlParameter("denumirePreparat", denumire)).ToList();
            ObservableCollection<Alergen> alergeni = new ObservableCollection<Alergen>();
            foreach (var alergenPreparat in alergeniPreparat)
            {
                var alergen = context.Alergens.SqlQuery("AfisareAlergen @id_alergen", new SqlParameter("id_alergen", alergenPreparat.id_alergen)).ToList();
                alergenPreparat.Alergen = alergen.FirstOrDefault();
                alergeni.Add(alergen.FirstOrDefault());
            }
            return alergeni;
        }

        internal void Delete(int id,Cont user)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            context.StergePreparat2(id);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new PreparateViewModel("Toate categoriile", user);
            MessageBox.Show("Preparat Sters!");
        }
        internal void DeletePreparatAlergen(Alergen alergenAles, Preparat preparatAles,Cont user)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            context.StergeAlergenDupaID(alergenAles.id_alergen, preparatAles.id_preparat);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new DetaliiPreparatViewModel(preparatAles,user);
            MessageBox.Show("Alergen Sters!");

        }

        internal void DeleteAlergen(Alergen alergenAles, Preparat preparatAles)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            context.StergeAlergenDupaID(alergenAles.id_alergen, preparatAles.id_preparat);
            context.SaveChanges();

        }
        public Fotografie FotografieCurenta(Preparat preparat)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            Fotografie aux = new Fotografie();
            foreach (var product in context.Preparats.SqlQuery("[CautaPreparat] @denumire",
                new SqlParameter("denumire", preparat.denumire)).ToList())
            {
                var poze = context.Fotografies.ToList();
                foreach (var poza in poze)
                {
                    if (poza.id_preparat == product.id_preparat)
                    {
                        aux = poza;
                        break;
                    }
                }
               
            }
            return aux;
        }

        public void AdaugaInCos(Cont user, Preparat preparatAles,int cantitate)
        {

            RestaurantEntities1 context = new RestaurantEntities1();
            var comenzi = context.Comandas.ToList();

            int idComanda = 0;
            foreach (var comanda in comenzi)
            {
                if (comanda.Cont.email == user.email && comanda.id_status==505)
                {
                    idComanda = comanda.id_comanda;
                    break;
                }
            }
            context.AdaugarePreparatInComanda(idComanda, preparatAles.denumire, cantitate);
            context.SaveChanges();
            MessageBox.Show("Preparat Adaugat!");
        }
    }
}
