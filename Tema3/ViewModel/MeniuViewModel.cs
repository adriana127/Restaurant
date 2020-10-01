using Tema3.Command;
using Tema3.Model.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Model;
using Tema3.ViewModel;

namespace Tema3.ViewModel
{
    class MeniuViewModel : BaseViewModel
    {
        MeniuActions pAct;


        public MeniuViewModel()
        {
            pAct = new MeniuActions();
        }
        public MeniuViewModel(Cont user)
        {
            pAct = new MeniuActions();
            if (user != null)
            {
                if (user.statut == "Angajat")
                    Visibility = "Visible";
                else
                    Visibility = "Hidden";
                User = user;
            }
            else
                Visibility = "Hidden";


        }
        #region Data members

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


        private ObservableCollection<Meniu> meniuList;
        public ObservableCollection<Meniu> MeniuList
        {
            get
            {

                if (MeniuCautat == "" || MeniuCautat == null)
                {
                    meniuList = pAct.AllMenius();
                }
                else
                {
                    meniuList = pAct.Search(MeniuCautat);

                }
                return meniuList;
            }
            set
            {
                meniuList = value;
                OnPropertyChanged("MeniuList");
            }
        }


        private string meniuCautat;
        public string MeniuCautat
        {
            get
            {
                return meniuCautat;
            }
            set
            {
                meniuCautat = value;
                if (MeniuCautat == "" || MeniuCautat == null)
                {
                    MeniuList = pAct.AllMenius();
                }
                else
                {
                    MeniuList = pAct.Search(MeniuCautat);

                }
                OnPropertyChanged("MeniuCautat");
            }
        }




        public ICommand Search
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MeniuList = pAct.Search(MeniuCautat);
                });
            }
        }

        public ICommand goToNewMeniu
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new AdaugareMeniuViewModel(User);
                }
                );
            }
        }



        public Meniu meniuAles { get; set; }
        public Meniu MeniuAles
        {
            get
            {
                return meniuAles;
            }
            set
            {
                meniuAles = value;
                OnPropertyChanged(nameof(MeniuAles));
                if(User==null)
                    MainViewModel.Instance.ActiveScreen = new DetaliiMeniuViewModel(meniuAles, null);
                else
                MainViewModel.Instance.ActiveScreen = new DetaliiMeniuViewModel(meniuAles,User);
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
