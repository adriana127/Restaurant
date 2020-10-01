using Tema3.Command;
using Tema3.Model;
using Tema3.Model.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Tema3.ViewModel
{
    class AdaugareMeniuViewModel : BaseViewModel
    {
        MeniuActions actions;

        public AdaugareMeniuViewModel()
        {
            actions = new MeniuActions();
            ListaPreparateDinMeniu = new ObservableCollection<Preparat>();
            Discount = double.Parse(ConfigurationManager.AppSettings["discountMeniu"].ToString());
        }
        public AdaugareMeniuViewModel(Cont user)
        {
            actions = new MeniuActions();
            ListaPreparateDinMeniu = new ObservableCollection<Preparat>();
            Discount = double.Parse(ConfigurationManager.AppSettings["discountMeniu"].ToString());
            User = user;
        }
        public AdaugareMeniuViewModel(Cont user,Meniu meniu)
        {
            actions = new MeniuActions();
            ListaPreparateDinMeniu = new ObservableCollection<Preparat>();
            Discount = double.Parse(ConfigurationManager.AppSettings["discountMeniu"].ToString());
            NumeMeniu = meniu.denumireMeniu;
            ListaPreparateDinMeniu = actions.PreparateMeniu(meniu);
            PretFinal = double.Parse(meniu.pret.ToString());
            PretInitial = actions.PretMeniu(ListaPreparateDinMeniu);
            ExistingRecord = true;
            MeniuAles = meniu;
            User = user;
            if (user.statut == "Angajat")
                Visibility = "Visible";
            else
                Visibility = "Hidden";

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

        Cont user;
        public Cont User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }
        private bool existingRecord;

        public bool ExistingRecord
        {
            get
            {
                return existingRecord;
            }
            set
            {
                existingRecord = value;
                OnPropertyChanged("ExistingRecord");
            }
        }
        private string numeMeniu;
        public string NumeMeniu
        {
            get { return numeMeniu; }
            set
            {
                numeMeniu = value;
                OnPropertyChanged(numeMeniu);
            }
        }
        private double pretInitial;
        public double PretInitial
        {
            get
            {
                return pretInitial;
            }
            set
            {
                pretInitial = value;
                OnPropertyChanged(nameof(PretInitial));
            }
        }
        private double discount;
        public double Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
                OnPropertyChanged(nameof(Discount));
            }
        }
        private double pretFinal;
        public double PretFinal
        {
            get
            {
                return pretFinal;
            }
            set
            {
                pretFinal = value;
                OnPropertyChanged(nameof(PretFinal));
            }
        }


        private int cantitateSolicitata;
        public int CantitateSolicitata
        {
            get
            {
                return cantitateSolicitata;
            }
            set
            {
                cantitateSolicitata = value;
                OnPropertyChanged(nameof(CantitateSolicitata));
            }
        }

        private ObservableCollection<Preparat> listaPreparateDinMeniu;
        public ObservableCollection<Preparat> ListaPreparateDinMeniu
        {
            get
            {

                //  listaPreparateDinMeniu = actions.AllProducts();

                return listaPreparateDinMeniu;
            }
            set
            {
                listaPreparateDinMeniu = value;
                OnPropertyChanged("ListaPreparateDinMeniu");
            }
        }


        private ObservableCollection<Preparat> preparateList;
        public ObservableCollection<Preparat> PreparateList
        {
            get
            {

                preparateList = actions.AllProducts();

                return preparateList;
            }
            set
            {
                preparateList = value;
                OnPropertyChanged("PreparateList");
            }
        }

        Preparat preparatDeSters;

        public Preparat PreparatDeSters
        {
            get { return preparatDeSters; }
            set { preparatDeSters = value; OnPropertyChanged(nameof(PreparatDeSters)); }
        }



        Preparat preparatDeAdaugat;
        public Preparat PreparatDeAdaugat
        {
            get { return preparatDeAdaugat; }
            set
            {
                preparatDeAdaugat = value;
                OnPropertyChanged(nameof(PreparatDeAdaugat));
                CantitateSolicitata = int.Parse(value.cantitate.ToString());
            }
        }
        public ICommand AdaugaPreparat
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Preparat aux = PreparatDeAdaugat;
                    if (preparatDeAdaugat.cantitate_totala < CantitateSolicitata)
                        MessageBox.Show("Cantitate solicitata prea mare!");
                    else
                    {
                        aux.pret = (PreparatDeAdaugat.pret * CantitateSolicitata / PreparatDeAdaugat.cantitate);
                        aux.pret = double.Parse(string.Format("{0:0.00}", aux.pret));
                        aux.cantitate = CantitateSolicitata;
                        PretInitial = double.Parse(PretInitial.ToString()) + double.Parse(aux.pret.ToString());
                        PretInitial = double.Parse(string.Format("{0:0.00}", PretInitial));
                        PretFinal = PretInitial - PretInitial * (discount / 100);
                        PretFinal = double.Parse(string.Format("{0:0.00}", PretFinal));
                        aux.pret = PretFinal;
                        ListaPreparateDinMeniu.Add(aux);
                    }

                });
            }
        }


        public ICommand StergePreparat
        {
            get
            {
                return new RelayCommand(() =>
                {
                    PretInitial = double.Parse(PretInitial.ToString()) - double.Parse(PreparatDeSters.pret.ToString());
                    PretFinal = PretInitial - PretInitial * (discount / 100);
                    ListaPreparateDinMeniu.Remove(PreparatDeSters);
                });
            }
        }

        Meniu meniuAles;
        public Meniu MeniuAles
        {
            get { return meniuAles; }
            set
            {
                meniuAles = value;
                OnPropertyChanged(nameof(MeniuAles));
            }
        }
        public ICommand SalveazaMeniu
        {
            get
            {
                return new RelayCommand(() =>
                {
                    actions.SalveazaMeniu(User,MeniuAles, ExistingRecord, Discount, NumeMeniu, ListaPreparateDinMeniu, PretFinal);
                });
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
    }
}
