using Tema3.Command;
using Tema3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Model.Entities;

namespace Tema3.ViewModel
{
    public class PreparateViewModel : BaseViewModel
    {


        ProductActions pAct;

        public PreparateViewModel(string categorie,Cont user)
        {
            pAct = new ProductActions();
            categorieDeAfisat = categorie;
            if (user != null)
            {
                if (user.statut == "Angajat")
                    Visibility = "Visible";
                else
                    Visibility = "Hidden";
                User = user;

            }
            else
            {
                Visibility = "Hidden";

            }
            //PreparateList = new ObservableCollection<Preparat>();
        }
        Cont user;
        public Cont User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }
        public PreparateViewModel()
        {
            pAct = new ProductActions();
        }
        #region Data members

        string visibility;
        public string Visibility
        {
            get { return visibility; }
            set { visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        private string categorieDeAfisat;

        public string CategorieDeAfisat
        {
            get
            {
                return categorieDeAfisat;
            }
            set
            {
                categorieDeAfisat = value;
                OnPropertyChanged("CategorieDeAfisat");
            }
        }
        public List<Categorie> listaCategorii;
        public List<Categorie> ListaCategorii
        {
            get
            {
                listaCategorii = pAct.Categorii();
                return listaCategorii;
            }
            set
            {
                listaCategorii = value;
                OnPropertyChanged("ListaCategorii");
            }
        }
        public ObservableCollection<InformatiiPreparat> preparateList;

        public ObservableCollection<InformatiiPreparat> PreparateList
        {
            get
            {
                if (PreparatCautat == "" || PreparatCautat == null)
                {
                    if (CategorieDeAfisat == "Toate categoriile" || CategorieDeAfisat == null)
                        preparateList = pAct.AllProducts();
                    else
                        preparateList = pAct.Cafea(CategorieDeAfisat);
                }
                else
                {
                    preparateList = pAct.Search(PreparatCautat);

                }
                return preparateList;
            }
            set
            {
                preparateList = value;
                OnPropertyChanged("PreparateList");
            }
        }




        private string preparatCautat;

        public string PreparatCautat
        {
            get
            {
                return preparatCautat;
            }
            set
            {
                preparatCautat = value;
                if (PreparatCautat == "" || PreparatCautat == null)
                {
                    if (CategorieDeAfisat == "Toate categoriile" || CategorieDeAfisat == null)
                        PreparateList = pAct.AllProducts();
                    else
                        PreparateList = pAct.Cafea(CategorieDeAfisat);
                }
                else
                {
                    PreparateList = pAct.Search(PreparatCautat);
                }
                OnPropertyChanged("PreparatCautat");
            }
        }




        public ICommand Search
        {
            get
            {
                return new RelayCommand(() =>
                {
                    PreparateList = pAct.Search(PreparatCautat);
                });
            }
        }
        public ICommand goToNewPrep
        {
            get
            {
                return new RelayCommand(() => {
                    MainViewModel.Instance.ActiveScreen = new AdaugarePreparatViewModel(User);
                });
            }
        }


        #endregion

        //public ICommand goHomeCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(() => {
        //            MainViewModel.Instance.ActiveScreen = new DetaliiPreparatViewModel(User);
        //        });
        //    }
        //}



        public Categorie categorieSchimbata { get; set; }
        public Categorie CategorieSchimbata
        {
            get
            {
                return categorieSchimbata;
            }
            set
            {
                categorieSchimbata = value;
                CategorieDeAfisat = value.denumire;
                if (CategorieDeAfisat == "Toate categoriile" || CategorieDeAfisat == null)
                    PreparateList = pAct.AllProducts();
                else
                    PreparateList = pAct.Cafea(categorieSchimbata.denumire);
                OnPropertyChanged("CategorieSchimbata");
            }
        }
        public InformatiiPreparat selectedProduct { get; set; }
        public InformatiiPreparat SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                if(user!=null)
                MainViewModel.Instance.ActiveScreen = new DetaliiPreparatViewModel(selectedProduct.Preparat,User);
                else
                    MainViewModel.Instance.ActiveScreen = new DetaliiPreparatViewModel(selectedProduct.Preparat, null);

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
                    if (User == null)
                        MainViewModel.Instance.ActiveScreen = new MeniuViewModel(null);
                    else
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
                    MainViewModel.Instance.ActiveScreen = new PreparateViewModel("Toate categoriile",User);

                });
            }
        }
        public ICommand goToCart
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new CartViewModel( User);

                });
            }
        }
              public ICommand goToComenzi
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new ComenziViewModel( User);

                });
            }
        }
        
    }
}
