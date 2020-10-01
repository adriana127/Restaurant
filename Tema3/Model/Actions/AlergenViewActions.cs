using Tema3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3.ViewModel;

namespace Tema3.Model.Actions
{
    class AlergenViewActions
    {

        RestaurantEntities1 context = new RestaurantEntities1();

        private AlergenViewModel prepContext;
        public AlergenViewActions(AlergenViewModel prepContext)
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

        internal void DeleteAlergen(Alergen selectedAlergen,Cont user)
        {
            context.StergeAlergen(selectedAlergen.denumire);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new AlergenViewModel(user);
            MessageBox.Show("Alergen Sters!");
        }


        internal void AdaugaAlergen(string denumire,Cont user)
        {
            context.AdaugareAlergen(denumire);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new AlergenViewModel(user);
            MessageBox.Show("Alergen Adaugat!");
        }

        internal void ModificaAlergen(Alergen alergen, string alergenModificat,Cont user)
        {
            context.ModificaAlergen(alergen.denumire, alergenModificat);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new AlergenViewModel(user);
            MessageBox.Show("Alergen Modificat!");
        }
    }
}
