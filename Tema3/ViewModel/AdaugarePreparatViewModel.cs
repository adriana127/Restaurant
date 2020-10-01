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
    class AdaugarePreparatViewModel : BaseViewModel
    {


        static AdaugarePreparatActions pAct;

        #region Constructors
        public AdaugarePreparatViewModel()
        {
            pAct = new AdaugarePreparatActions(this);
            ExistingRecord = false;
        }

        public AdaugarePreparatViewModel(Cont user)
        {
            pAct = new AdaugarePreparatActions(this);
            ExistingRecord = false;
            User = user;
        }

        public AdaugarePreparatViewModel(Preparat preparat, bool existingRecord,Cont user)
        {

            this.id_preparat = preparat.id_preparat;
            this.id_categorie = int.Parse(preparat.id_categorie.ToString());
            this.denumire = preparat.denumire;
            this.pret = double.Parse(preparat.pret.ToString());
            this.cantitate = double.Parse(preparat.cantitate.ToString());
            this.cantitate_totala = double.Parse(preparat.cantitate_totala.ToString());
            this.categorii = new ObservableCollection<Categorie>();
            this.existingRecord = existingRecord;
            pAct = new AdaugarePreparatActions(this);
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
        #endregion

        #region Data members
        private int id_preparat;
        private int id_categorie;

        private string denumire;
        private double pret;
        private double cantitate;
        private double cantitate_totala;
        public ObservableCollection<Categorie> categorii;

        Cont user;
        public Cont User
        {
            get { return user; }
            set { user = value;OnPropertyChanged("User"); }
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

        public int IdPreparat
        {
            get
            {
                return id_preparat;
            }
            set
            {
                id_preparat = value;
                OnPropertyChanged("IdPreparat");
            }
        }

        public ObservableCollection<Categorie> Categorii
        {
            get
            {
                categorii = pAct.ListaCategorii();
                return categorii;
            }
            set
            {
                categorii = value;
                OnPropertyChanged("Categorii");
            }
        }
        public Categorie categorieAleasa;

        public Categorie CategorieAleasa
        {
            get
            {
                return categorieAleasa;
            }
            set
            {
                categorieAleasa = value;
                OnPropertyChanged("CategorieAleasa");
            }
        }

        public string Denumire
        {
            get
            {
                return denumire;
            }
            set
            {
                denumire = value;
                OnPropertyChanged("Denumire");
            }
        }

        public double Pret
        {
            get
            {
                return pret;
            }
            set
            {
                pret = value;
                OnPropertyChanged("Pret");
            }
        }

        public double Cantitate
        {
            get
            {
                return cantitate;
            }
            set
            {
                cantitate = value;
                OnPropertyChanged("Cantitate");
            }
        }

        public double Cantitate_Totala
        {
            get
            {
                return cantitate_totala;
            }
            set
            {
                cantitate_totala = value;
                OnPropertyChanged("Cantitate_Totala");
            }
        }

        ObservableCollection<Fotografie> fotografii;

        public ObservableCollection<Fotografie> Fotografii
        {
            get
            {
                fotografii = pAct.AfisarePoze(IdPreparat);
                return fotografii;
            }
            set
            {
                fotografii = value;
                OnPropertyChanged(nameof(Fotografii));
            }

        }


        #endregion

        #region Binding function

        public ICommand AdaugaPrep
        {
            get
            {
                return new RelayCommand(() =>
                {
                    pAct.Adauga(User,IdPreparat, Denumire, Pret, Cantitate, Cantitate_Totala, CategorieAleasa);
                });
            }
        }

        public ICommand AdaugaPoza
        {
            get
            {
                return new RelayCommand(() =>
                {
                    pAct.AdaugaPoza(IdPreparat);
                    Fotografii = pAct.AfisarePoze(IdPreparat);
                });
            }
        }
        Fotografie pozaDeSters;
        public Fotografie PozaDeSters
        {
            get { return pozaDeSters; }
            set { pozaDeSters = value;
                OnPropertyChanged(nameof(PozaDeSters));

            }
        }
        public ICommand StergePoza
        {
            get
            {
                return new RelayCommand(() =>
                {
                    pAct.StergePoza(IdPreparat,PozaDeSters);
                    Fotografii = pAct.AfisarePoze(IdPreparat);
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
        #endregion
    }

}
