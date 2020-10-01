using Tema3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3.Model;

namespace Tema3.Model.Actions
{
    class CategoriesActions
    {
        RestaurantEntities1 context = new RestaurantEntities1();

        private CategoriiViewModel prepContext;
        public CategoriesActions(CategoriiViewModel prepContext)
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

        public ObservableCollection<Categorie> AllCategories()
        {
            List<Categorie> categorii = context.Categories.ToList();
            ObservableCollection<Categorie> result = new ObservableCollection<Categorie>();
            foreach (var categorie in categorii)
            {
                result.Add(categorie);
            }
            return result;
        }

        internal void DeleteCategorie(Cont user,Categorie categorie)
        {
            context.StergeCategorie(categorie.denumire);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new CategoriiViewModel(user);
            MessageBox.Show("Categorie Stearsa!");
        }


        internal void AdaugaCategorie(Cont user, string denumire)
        {
            context.AdaugareCategorie(denumire);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new CategoriiViewModel(user);
            MessageBox.Show("Categorie Adaugata!");
        }

        internal void ModificaCategorie(Cont user, Categorie categorie, string denumireNoua)
        {
            context.ModificaCategorie(categorie.denumire, denumireNoua);
            context.SaveChanges();
            MainViewModel.Instance.ActiveScreen = new CategoriiViewModel(user);
            MessageBox.Show("Categorie Modificata!");
        }
    }
}
