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
    class AlergenPreparatViewModel : BaseViewModel
    {

        AlergenActions pAct;

        public AlergenPreparatViewModel()
        {
            pAct = new AlergenActions(this);
        }
        public AlergenPreparatViewModel(Preparat preparat,Cont user)
        {
            PreparatAles = preparat;
            pAct = new AlergenActions(this);
            User = user;


        }

        Cont user;
        public Cont User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }

        #region Data members
        private int id_alergen;
        private string denumire;


        private ObservableCollection<Alergen> alergeniList;

        public int Id_alergen
        {
            get
            {
                return id_alergen;
            }
            set
            {
                id_alergen = value;
                OnPropertyChanged("Id_alergen");
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

        public ObservableCollection<Alergen> Alergeni
        {
            get
            {
                alergeniList = pAct.AllAlergens();
                return alergeniList;
            }
            set
            {
                alergeniList = value;
                OnPropertyChanged("Alergeni");
            }
        }


        #endregion


        private Preparat preparatAles;

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

        private Alergen alergenAles;
        public Alergen AlergenAles
        {
            get
            {
                return alergenAles;
            }
            set
            {
                alergenAles = value; OnPropertyChanged("AlergenAles");
            }
        }


        public ICommand AdaugaAlergen
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (AlergenAles != null)
                    {
                        pAct.AdaugaAlergenPreparat(PreparatAles, AlergenAles,User);
                        DetaliiPreparatViewModel model = new DetaliiPreparatViewModel(preparatAles,User);
                    }
                });
            }
        }

    }
}
