using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Command;
using Tema3.Model;
using Tema3.Model.Actions;
using Tema3.Model.Entities;

namespace Tema3.ViewModel
{
    class CartViewModel:BaseViewModel
    {
        // meniuri comandate
        // preparate comandate
        // pret transport
        // discount
        // pret initial
        // pret final
        public CartActions actions;
        public CartViewModel() { 
            actions = new CartActions();
        }
        public CartViewModel(Cont user)
        {
            User = user;
            actions = new CartActions();
            ListaCumparaturi = new List<InformatiiCos>();
            PretMinim = double.Parse(ConfigurationManager.AppSettings["comandaMinima"].ToString());
            if (Pret < PretMinim)
                Transport = double.Parse(ConfigurationManager.AppSettings["transport"].ToString());
            else
                Transport = 0;
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
        List<InformatiiCos> cumparaturi;
        public List<InformatiiCos> ListaCumparaturi
        {
            get {
                cumparaturi = actions.Cumparaturi(User);
                return cumparaturi; }
            set { cumparaturi = value; OnPropertyChanged(nameof(ListaCumparaturi)); }
        }

        Cont user;
        public Cont User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }

        double pretMinim;
        public double PretMinim
        {
            get { return pretMinim; }
            set { pretMinim = value; OnPropertyChanged("PretMinim"); }
        }

        double pret;
        public double Pret
        {
            get {
                pret = actions.Pret(ListaCumparaturi);
                return pret; }
            set { pret = value;
                OnPropertyChanged(("Pret"));
            }
        }
        double transport;
        public double Transport
        {
            get {return transport; }
            set
            {
                transport = value;
                OnPropertyChanged(nameof(Transport));
            }
        }
        InformatiiCos deSters;
        public InformatiiCos DeSters
        {
            get { return deSters; }

            set { deSters = value;
                OnPropertyChanged("DeSters");
            }
        }

        public ICommand StergeDinCos
        {
            get
            {
                return new RelayCommand(() =>
                {
                    actions.StergeDinCos(DeSters,User);
                });
            }
        }
        public ICommand TrimiteComanda
        {
            get
            {
                return new RelayCommand(() =>
                {
                    actions.TrimiteComanda(User);
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
