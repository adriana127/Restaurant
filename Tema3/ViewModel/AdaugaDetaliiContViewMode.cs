using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Command;
using Tema3.Model;
using Tema3.Model.Actions;

namespace Tema3.ViewModel
{
    class AdaugaDetaliiContViewMode:BaseViewModel
    {
        UserActions actions;
        public AdaugaDetaliiContViewMode() { }
        public AdaugaDetaliiContViewMode(Cont cont)
        {
            actions = new UserActions();
            User = cont;
            if (cont.statut == "Angajat")
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

        string nume;
        public string Nume
        {
            get { return nume; }
            set
            {
                nume = value;
                OnPropertyChanged("Nume");
            }
        }
        string prenume;
        public string Prenume
        {
            get { return prenume; }
            set
            {
                prenume = value;
                OnPropertyChanged("Prenume");
            }
        }
        string adresa;
        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }
        string numar;
        public string Numar
        {
            get { return numar; }
            set
            {
                numar = value;
                OnPropertyChanged("Numar");
            }
        }

        public ICommand AdaugaDetalii
        {
            get
            {
                return new RelayCommand(() =>
                {
                    actions.AddDetails(User,Nume, Prenume, Numar, Adresa);
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
