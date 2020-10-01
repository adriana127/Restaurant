using Tema3.Command;
using Tema3.Model;
using Tema3.View;
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
    public class DetaliiPreparatViewModel : BaseViewModel
    {
        static DetailedProductActions pAct;

        public DetaliiPreparatViewModel()
        {
            pAct = new DetailedProductActions(this);

        }
        public DetaliiPreparatViewModel(Preparat preparat,Cont user)
        {
            pAct = new DetailedProductActions(this);
            PreparatAles = preparat;
            FotografieCurenta = pAct.FotografieCurenta(preparat);
            if (user != null)
            {
                User = user;
                if (user.statut == "Angajat")
                    Visibility = "Visible";
                else
                    Visibility = "Hidden";
            }
            else
                Visibility = "Hidden";

        }
        Cont user;
        public Cont User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        #region Data members


        private ObservableCollection<Alergen> alergeni;

        private Preparat preparatAles;

        Fotografie fotografieCurenta;
        public Fotografie FotografieCurenta
        {
            get { return fotografieCurenta; }
            set
            {
                fotografieCurenta = value;
                OnPropertyChanged(nameof(FotografieCurenta));
            }
        }



        ObservableCollection<Fotografie> fotografiiPreparat;
        public ObservableCollection<Fotografie> FotografiiPreparat
        {
            get { return fotografiiPreparat; }
            set
            {
                fotografiiPreparat = value;
                OnPropertyChanged(nameof(FotografiiPreparat));
            }
        }

        public ObservableCollection<Alergen> Alergeni
        {
            get
            {
                alergeni = pAct.Alergeni(PreparatAles.denumire);
                return alergeni;
            }
            set
            {
                alergeni = value;
                OnPropertyChanged("Alergeni");
            }
        }

        public Preparat PreparatAles
        {
            get
            {

                return preparatAles;
            }
            set
            {
                preparatAles = value;
                OnPropertyChanged("PreparatAles");
            }
        }


        #endregion
        public double cantitateSlider=1;
        public double CantitateSlider
        {
            set { cantitateSlider = value; OnPropertyChanged(nameof(CantitateSlider)); }
            get
            {
                return cantitateSlider;
            }
        }

        public bool visibleComboBox { get; set; }
        public bool ComboBoxVisibile
        {
            get
            {

                return visibleComboBox;
            }
            set
            {
                visibleComboBox = value;
                OnPropertyChanged("ComboBoxVisibile");
            }
        }
        

        public ICommand AdaugaAlergen
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ComboBoxVisibile = true;
                    
                    OnPropertyChanged("AdaugaAlergen");

                });
            }
        }


        private ICommand openWindowCommand;
        public ICommand OpenWindowCommand
        {
            get
            {
                if (openWindowCommand == null)
                {
                    openWindowCommand = new RelayCommand(() =>
                    {
                        View.AlergenPreparat pers = new View.AlergenPreparat();
                        pers.DataContext = new AlergenPreparatViewModel(PreparatAles,User);
                        pers.ShowDialog();

                    }
                    );
                }
                return openWindowCommand;
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

        public ICommand StergePreparat
        {
            get
            {
                return new RelayCommand(() => {
                    pAct.Delete(PreparatAles.id_preparat,User);
                });
            }
        }
        public Alergen alergenAles;
        public Alergen AlergenAles
        {
            get { return alergenAles; }
            set
            {
                alergenAles = value;
                OnPropertyChanged("AlergenAles");
            }

        }


        public ICommand StergeAlergen
        {
            get
            {
                return new RelayCommand(() => {
                    if (AlergenAles != null)
                        pAct.DeletePreparatAlergen(AlergenAles, preparatAles,User);
                });
            }
        }


        public ICommand ModificaPreparat
        {
            get
            {
                return new RelayCommand(() =>
                {

                    MainViewModel.Instance.ActiveScreen = new AdaugarePreparatViewModel(
                        PreparatAles,
                        true,User

                        );

                }
                    );

            }

        }
        public string cantitateDeComandat { get; set; }
        public string CantitateDeComandat
        {
            get
            {
                return cantitateSlider.ToString();
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
                    if(User!=null)
                    pAct.AdaugaInCos(User, PreparatAles,int.Parse(CantitateSlider.ToString()));
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
