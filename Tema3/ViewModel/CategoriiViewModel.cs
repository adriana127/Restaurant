using Tema3.Command;
using Tema3.Model;
using Tema3.Model.Actions;
using Tema3.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tema3.ViewModel
{
    class CategoriiViewModel : BaseViewModel
    {
        CategoriesActions pAct;
        public CategoriiViewModel()
        {
            pAct = new CategoriesActions(this);
        }
        public CategoriiViewModel(Cont user)
        {
            User = user;
            pAct = new CategoriesActions(this);
            if (user.statut == "Angajat")
                Visibility = "Visible";
            else
                Visibility = "Hidden";

        }
        Cont user;
        public Cont User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }
        #region Data members
        private int id_categorie;
        private string denumire;
        string visibility;
        public string Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        private ObservableCollection<Categorie> categorii;

        int option;
        public int Option
        {
            get { return option; }
            set
            {
                option = value;
                OnPropertyChanged("Option");
            }
        }

        public ObservableCollection<Categorie> Categorii
        {
            get
            {

                categorii = pAct.AllCategories();


                return categorii;
            }
            set
            {
                categorii = value;
                OnPropertyChanged("Categorii");
            }
        }


        #endregion
        #region Binding functions



        string categorieNoua;
        public string CategorieNoua
        {
            get { return categorieNoua; }
            set
            {
                categorieNoua = value;
                OnPropertyChanged("CategorieNoua");
            }
        }



        string categorieModificata;
        public string CategorieModificata
        {
            get { return categorieModificata; }
            set
            {
                categorieModificata = value;
                OnPropertyChanged("CategorieModificata");
            }
        }


        public ICommand StergeCategorie
        {
            get
            {
                return new RelayCommand(() => {
                    if (SelectedCategory != null)
                        pAct.DeleteCategorie(User,SelectedCategory);
                });
            }
        }

        public ICommand AdaugaCategorie
        {
            get
            {
                return new RelayCommand(() => {
                    if (CategorieNoua != null || CategorieNoua != "")
                        pAct.AdaugaCategorie(User,CategorieNoua);
                });
            }
        }
        public ICommand ModificaCategorie
        {
            get
            {
                return new RelayCommand(() => {
                    if (CategorieNoua != null || CategorieNoua != "")
                        pAct.ModificaCategorie(User,SelectedCategory, CategorieModificata);
                });
            }
        }


        public Categorie selectedCategory { get; set; }
        public Categorie SelectedCategory
        {
            get
            {
                return selectedCategory;
            }
            set
            {

                selectedCategory = value;
                CategorieModificata = value.denumire;

                OnPropertyChanged("SelectedCategory");
            }
        }
        public ICommand goToCategorii
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new CategoriiViewModel(User);

                });
            }
        }
        public ICommand goToAlergeni
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new AlergenViewModel(User);

                });
            }
        }
        public ICommand goToMeniuri
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new MeniuViewModel(User);

                });
            }
        }
        public ICommand goToPreparate
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new PreparateViewModel("Toate categoriile", User);

                });
            }
        }
        public ICommand goToCart
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new CartViewModel(User);

                });
            }
        }

        public ICommand goToComenzi
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new ComenziViewModel(User);

                });
            }
        }
        #endregion
    }
}
