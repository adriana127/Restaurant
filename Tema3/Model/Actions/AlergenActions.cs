using Tema3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tema3.Model.Actions
{
    class AlergenActions
    {
        RestaurantEntities1 context = new RestaurantEntities1();

        private AlergenPreparatViewModel prepContext;
        public AlergenActions(AlergenPreparatViewModel prepContext)
        {
            this.prepContext = prepContext;
        }


        public ObservableCollection<Alergen> AllAlergens()
        {
            List<Alergen> alergeni = context.Alergens.ToList();
            ObservableCollection<Alergen> result = new ObservableCollection<Alergen>();
            foreach (Alergen alergen in alergeni)
            {
                result.Add(alergen);
            }
            return result;
        }


        //public void AddMethod(object obj)
        //{
        //    //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
        //    AlergenPreparatViewModel personVM = obj as AlergenPreparatViewModel;
        //    //DetaliiPreparatViewModel personVMa = obj as DetaliiPreparatViewModel;

        //    if (personVM != null)
        //    {
        //        Preparat preparat = context.Preparats.SqlQuery("[AfisarePreparatDupaID] @id_preparat", new SqlParameter("id_preparat", Properties.Settings.Default.id_preparat)).First();

        //            context.AdaugareAlergenPreparat(personVM.Denumire,preparat.denumire);
        //            //context.persoanes.Add(new persoane() { nume = personVM.Name , adresa = personVM.Address});
        //            context.SaveChanges();
        //            prepContext.Alergeni = AllAlergens();
        //            MainViewModel.Instance.ActiveScreen = new DetaliiPreparatViewModel();

        //    }
        //    }

        internal void AdaugaAlergenPreparat(Preparat preparatAles, Alergen alergenAles,Cont User)
        {
            context.AdaugareAlergenPreparat(alergenAles.denumire, preparatAles.denumire);
            //context.persoanes.Add(new persoane() { nume = personVM.Name , adresa = personVM.Address});
            context.SaveChanges();
            //prepContext.Alergeni = AllAlergens();
            MainViewModel.Instance.ActiveScreen = new DetaliiPreparatViewModel(preparatAles,User);
        }
    }















}




