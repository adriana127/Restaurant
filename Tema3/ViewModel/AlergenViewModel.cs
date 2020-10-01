using Tema3.Command;
using Tema3.Model;
using Tema3.Model.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tema3.ViewModel
{
    class AlergenViewModel : BaseViewModel
    {
        AlergenViewActions pAct;
        public AlergenViewModel()
        {
            pAct = new AlergenViewActions(this);
        }
        public AlergenViewModel(Cont user)
        {
            pAct = new AlergenViewActions(this);
            User = user;
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
        #region Data members



        private ObservableCollection<Alergen> alergeni;

        public ObservableCollection<Alergen> Alergeni
        {
            get
            {

                alergeni = pAct.AllAlergens();


                return alergeni;
            }
            set
            {
                alergeni = value;
                OnPropertyChanged("Alergeni");
            }
        }



        #endregion
        #region Binding functions


        string alergenNou;
        public string AlergenNou
        {
            get { return alergenNou; }
            set
            {
                alergenNou = value;
                OnPropertyChanged("AlergenNou");
            }
        }



        string alergenModificat;
        public string AlergenModificat
        {
            get { return alergenModificat; }
            set
            {
                alergenModificat = value;
                OnPropertyChanged("AlergenModificat");
            }
        }


        public ICommand StergeAlergen
        {
            get
            {
                return new RelayCommand(() => {
                    if (SelectedAlergen != null)
                        pAct.DeleteAlergen(SelectedAlergen, User);
                });
            }
        }

        public ICommand AdaugaAlergen
        {
            get
            {
                return new RelayCommand(() => {
                    if (AlergenNou != null || AlergenNou != "")
                        pAct.AdaugaAlergen(AlergenNou, User);
                });
            }
        }
        public ICommand ModificaAlergen
        {
            get
            {
                return new RelayCommand(() => {
                    if (AlergenNou != null || AlergenNou != "")
                        pAct.ModificaAlergen(SelectedAlergen, AlergenModificat,User);
                });
            }
        }

        public Alergen selectedAlergen { get; set; }
        public Alergen SelectedAlergen
        {
            get
            {
                return selectedAlergen;
            }
            set
            {

                selectedAlergen = value;
                AlergenModificat = value.denumire;
                OnPropertyChanged("SelectedAlergen");
                //MainViewModel.Instance.ActiveScreen = new PreparateViewModel(value.denumire);
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
