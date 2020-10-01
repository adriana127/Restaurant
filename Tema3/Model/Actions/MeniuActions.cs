using Tema3.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3.Model;

namespace Tema3.Model.Actions
{
    class MeniuActions
    {

        public MeniuActions()
        {
        }


        public ObservableCollection<Meniu> AllMenius()
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            //List<Preparat> preparate = context.Preparats.ToList();
            ObservableCollection<Meniu> aux = new ObservableCollection<Meniu>();
            foreach (var product in context.Menius.ToList())
            {
                aux.Add(product);
            }
            return aux;
        }

        internal ObservableCollection<Meniu> Search(string meniuCautat)
        {
            RestaurantEntities1 context = new RestaurantEntities1();


            ObservableCollection<Meniu> aux = new ObservableCollection<Meniu>();
            foreach (var product in context.Menius.SqlQuery("[CautaMeniu] @denumire",
                new SqlParameter("denumire", meniuCautat)).ToList())
            {
                aux.Add(product);
            }
            return aux;
        }

        public ObservableCollection<Preparat> PreparateMeniu(Meniu meniuAles)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            var preparate = context.AfisarePreparateMeniu(meniuAles.denumireMeniu).ToList();
            ObservableCollection<Preparat> result = new ObservableCollection<Preparat>();
            foreach (var preparat in preparate)
            {
                Preparat aux = new Preparat();
                aux.id_categorie = preparat.id_categorie;
                aux.id_preparat = preparat.id_preparat;
                aux.pret = preparat.pret;
                aux.cantitate = preparat.cantitate;
                aux.cantitate_totala = preparat.cantitate_totala;
                aux.denumire = preparat.denumire;
                result.Add(aux);
            }
            return result;
        }

        public void StergeMeniu(Meniu meniuAles,Cont user)
        {
            RestaurantEntities1 context = new RestaurantEntities1();
            context.StergeMeniu(meniuAles.denumireMeniu);
            context.SaveChanges();
            MessageBox.Show("Meniu Sters!");
            MainViewModel.Instance.ActiveScreen = new MeniuViewModel(user);

        }

        public double PretMeniu(ObservableCollection<Preparat> preparate)
        {
            RestaurantEntities1 context = new RestaurantEntities1();
            double aux = 0;
            foreach (var preparat in preparate)
            {
                aux += double.Parse(preparat.pret.ToString());
            }
            return aux;
        }

        public ObservableCollection<Preparat> AllProducts()
        {
            RestaurantEntities1 context = new RestaurantEntities1();
            ObservableCollection<Preparat> aux = new ObservableCollection<Preparat>();
            foreach (var product in context.Preparats.ToList())
            {
                aux.Add(product);
            }
            return aux;
        }

        public void SalveazaMeniu(Cont user,Meniu meniuAles, bool existingRecord, double discount, string numeMeniu, ObservableCollection<Preparat> listaPreparateDinMeniu, double pretFinal)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            bool exista = false;

            foreach (var meniu in context.Menius.ToList())
            {
                if (meniu.denumireMeniu == numeMeniu && existingRecord == false)
                {
                    MessageBox.Show("Exista deja un meniu cu acest nume!");
                    exista = true;
                }

            }
            if (listaPreparateDinMeniu.Count() == 0)
            {
                MessageBox.Show("Lista de preparate goala!");
                exista = true;
            }
            if (numeMeniu == null || numeMeniu == "")
            {
                MessageBox.Show("Nume necompletat!");
                exista = true;
            }
            if (exista == false)
            {
                if (existingRecord == false)
                {
                    context.AdaugareMeniu(numeMeniu, 0, discount);
                    foreach (var preparat in listaPreparateDinMeniu)
                    {
                        context.AdaugarePreparatInMeniu(numeMeniu, preparat.denumire, preparat.cantitate);
                        MainViewModel.Instance.ActiveScreen = new MeniuViewModel(user);

                    }
                    context.AplicaReducereMeniu(numeMeniu, discount);
                    MessageBox.Show("Meniu Adaugat!");
                    context.SaveChanges();

                }
                else
                {

                    var preparate = context.AfisarePreparateDinMeniu(numeMeniu).ToList();
                    List<string> aux = new List<string>();
                    foreach (var preparat in preparate)
                    {
                        aux.Add(preparat.denumire);
                    }
                    foreach (var preparateExistente in aux)
                    {
                        context.StergePreparatInMeniu(meniuAles.denumireMeniu, preparateExistente);
                        context.SaveChanges();
                    }
                    foreach (var preparat in listaPreparateDinMeniu)
                    {
                        context.AdaugarePreparatInMeniu(meniuAles.denumireMeniu, preparat.denumire, preparat.cantitate);

                    }
                    context.ModificaNumeMeniu(meniuAles.denumireMeniu, numeMeniu);
                    context.SaveChanges();
                    context.AplicaReducereMeniu(numeMeniu, discount);

                    MessageBox.Show("Meniu Modificat!");
                    MainViewModel.Instance.ActiveScreen = new MeniuViewModel(user);



                }

            }

        }
        public void AdaugaInCos(Cont user, Meniu preparatAles, int cantitate)
        {

            RestaurantEntities1 context = new RestaurantEntities1();
            var comenzi = context.Comandas.ToList();

            int idComanda = 0;
            foreach (var comanda in comenzi)
            {
                if (comanda.Cont.email == user.email && comanda.id_status == 505)
                {
                    idComanda = comanda.id_comanda;
                    break;
                }
            }
            context.AdaugareMeniuInComanda(idComanda, preparatAles.denumireMeniu, cantitate);
            context.SaveChanges();
            MessageBox.Show("Meniu Adaugat!");
        }
    }
}
