using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class ComenziViewModel:BaseViewModel
    {
        public ComenziViewModel() 
        { 
            actions = new CartActions();
        }
        CartActions actions;
        public ComenziViewModel(Cont user)
        {
            if (user.statut == "Angajat")
                Visibility = "Visible";
            else
                Visibility = "Hidden";
            User = user;
            actions = new CartActions();

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

        ObservableCollection<InformatiiComanda> comenzi;
        public ObservableCollection<InformatiiComanda> Comenzi
        {
            get {
                comenzi = actions.Comenzi(User);
                return comenzi; }
            set { comenzi = value;
                OnPropertyChanged(nameof(Comenzi));
            }
        }
        InformatiiComanda deModificat;
        public InformatiiComanda PtUpdate
        {
            get { return deModificat; }
            set
            {
                deModificat = value;
                OnPropertyChanged(nameof(PtUpdate));
            }
        }

        ObservableCollection<StatusComanda> listaStatus;
        public ObservableCollection<StatusComanda> ListaStatus
        {
            get
            {
                listaStatus = actions.AllStatus();
                return listaStatus;
            }
            set
            {
                listaStatus = value;
                OnPropertyChanged(nameof(ListaStatus));
            }
        }
        StatusComanda statusNou;
        public StatusComanda StatusNou
        {
            get { return statusNou; }
            set
            {
                statusNou = value;
                OnPropertyChanged(nameof(StatusNou));
            }
        }
        public ICommand ModificaStare
        {
            get
            {
                return new RelayCommand(() =>
                {
                    actions.UpdateStare(StatusNou, PtUpdate, User);
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
