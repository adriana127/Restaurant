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
using System.Windows;

namespace Tema3.ViewModel
{
    class DetaliiMeniuViewModel : BaseViewModel
    {
        MeniuActions actions;
        public DetaliiMeniuViewModel()
        {
            actions = new MeniuActions();
        }
        public DetaliiMeniuViewModel(Meniu meniuAles,Cont user)
        {
            actions = new MeniuActions();
            MeniuAles = meniuAles;
            if (user != null)
            { User = user;
                if (user.statut == "Angajat")
                    Visibility = "Visible";
                else
                    Visibility = "Hidden"; }
            else {
                Visibility = "Hidden";
            }

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
        ObservableCollection<Preparat> preparateDinMeniu;
        public ObservableCollection<Preparat> PreparateDinMeniu
        {
            get
            {
                preparateDinMeniu = actions.PreparateMeniu(MeniuAles);
                return preparateDinMeniu;
            }
            set
            {
                preparateDinMeniu = value;
                OnPropertyChanged("PreparateDinMeniu");
            }
        }
        private Meniu meniuAles;
        public Meniu MeniuAles
        {
            get
            {
                return meniuAles;
            }
            set
            {
                meniuAles = value;
                OnPropertyChanged("MeniuAles");
            }
        }
        public ICommand ModificaMeniu
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new AdaugareMeniuViewModel(User,MeniuAles);
                }
                );
            }
        }
        public ICommand StergeMeniu
        {
            get
            {
                return new RelayCommand(() =>
                {
                    actions.StergeMeniu(MeniuAles,User);
                }
                );
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
        public ICommand AdaugaInCos
        {
            get
            {
                
                    return new RelayCommand(() =>
                    {
                        if (User != null)
                            actions.AdaugaInCos(User, MeniuAles, 1);
                        else
                        {
                            MessageBox.Show("Este necesar sa va logati!");
                            MainViewModel.Instance.ActiveScreen = new LoginViewModel();
                        }
                    });  
            }
        }
    }
}
