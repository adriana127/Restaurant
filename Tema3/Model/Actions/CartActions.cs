using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3.Model.Entities;
using Tema3.ViewModel;

namespace Tema3.Model.Actions
{
    class CartActions
    {
        public CartActions() { }

        public int IdComanda(Cont user)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            int id = 0;
            foreach (var comanda in context.Comandas.ToList())
            {
                if (comanda.id_cont == user.id_cont && comanda.id_status == 505)
                {
                    id = comanda.id_comanda;
                }
            }
            return id;
        }
        public ObservableCollection<Preparat> Preparate(Cont user)
        {
            RestaurantEntities1 context = new RestaurantEntities1();
            int idComanda = IdComanda(user);

            ObservableCollection<Preparat> aux = new ObservableCollection<Preparat>();

            foreach (var comanda in context.PreparatComandas.ToList())
            {
                if (idComanda == comanda.id_comanda)
                {
                   foreach(var preparat in context.Preparats.ToList())
                    {
                        if(preparat.id_preparat==comanda.id_preparat)
                            aux.Add(preparat);

                    }

                }
            }
            return aux;

        }
        public string NumeClient(int cont)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            string aux = "";
            foreach(var user in context.DetaliiConts.ToList())
            {
                if(user.id_cont==cont)
                {
                    aux = user.nume+" "+user.prenume;
                }
            }
            return aux;
        }
        public string AdresaClient(int cont)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            string aux = "";
            foreach (var user in context.DetaliiConts.ToList())
            {
                if (user.id_cont == cont)
                {
                    aux = user.adresa;
                }
            }
            return aux;
        }
        public string NumarClient(int cont)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            string aux = "";
            foreach (var user in context.DetaliiConts.ToList())
            {
                if (user.id_cont == cont)
                {
                    aux = user.telefon;
                }
            }
            return aux;
        }
       
        public string Status(int comanda)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            string aux = "";
            foreach (var status in context.StatusComandas.ToList())
            {
                if (status.id_status == comanda)
                {
                    aux = status.denumire;
                }
            }
            return aux;
        }

        internal ObservableCollection<StatusComanda> AllStatus()
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            ObservableCollection<StatusComanda> aux = new ObservableCollection<StatusComanda>();
            foreach(var status in context.StatusComandas.ToList())
            {
                aux.Add(status);
            }
            return aux;
        }

        internal void UpdateStare(StatusComanda statusNou, InformatiiComanda deModificat,Cont user)
        {
            RestaurantEntities1 context = new RestaurantEntities1();
            context.ModificaStare(deModificat.Numarcomanda, statusNou.id_status);
            MessageBox.Show("Stare comanda modificata!");
            MainViewModel.Instance.ActiveScreen = new ComenziViewModel(user);
        }

        internal ObservableCollection<InformatiiComanda> Comenzi(Cont user)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            ObservableCollection<InformatiiComanda> aux = new ObservableCollection<InformatiiComanda>();
            if (user.statut=="Angajat")
            {
                foreach(var comanda in context.Comandas.ToList())
                {
                    aux.Add(new InformatiiComanda(NumeClient(int.Parse(comanda.id_cont.ToString())),
                        AdresaClient(int.Parse(comanda.id_cont.ToString())),
                        NumarClient(int.Parse(comanda.id_cont.ToString())),Status(int.Parse(comanda.id_status.ToString())), double.Parse(comanda.pret.ToString()), comanda.id_comanda));
                }
            }
            else
            {
                foreach (var comanda in context.Comandas.ToList())
                {
                    if(comanda.id_cont==user.id_cont)
                        aux.Add(new InformatiiComanda(NumeClient(int.Parse(comanda.id_cont.ToString())),
                                            AdresaClient(int.Parse(comanda.id_cont.ToString())),
                                            NumarClient(int.Parse(comanda.id_cont.ToString())), Status(int.Parse(comanda.id_status.ToString())), double.Parse(comanda.pret.ToString()), comanda.id_comanda));
                }
            }
            return aux;
        }

        public ObservableCollection<Meniu> Meniuri(Cont user)
        {
            RestaurantEntities1 context = new RestaurantEntities1();
            int idComanda = IdComanda(user);
            ObservableCollection<Meniu> aux = new ObservableCollection<Meniu>();

            
            foreach (var comanda in context.MeniuComandas.ToList())
            {
                if (idComanda == comanda.id_comanda)
                {
                    foreach (var meniu in context.Menius.ToList())
                    {
                        if (meniu.id_meniu == comanda.id_meniu)
                            aux.Add(meniu);

                    }

                }
            }
            return aux;
        }

        public double Pret(List<InformatiiCos> listaCumparaturi)
        {
            double aux = 0;
            foreach(var cumparaturi in listaCumparaturi)
            {
                aux += (cumparaturi.Pret * cumparaturi.Bucati);
            }
            return aux;
        }

        public List<InformatiiCos> Cumparaturi(Cont user)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            List<InformatiiCos> aux = new List<InformatiiCos>();
            foreach (var preparat in Preparate(user))
            {
                string denumire = "";
                foreach (var prep in context.Preparats.ToList())
                {
                    if (prep.id_preparat == preparat.id_preparat)
                        denumire = prep.denumire;
                }
                double pret = 0;
                foreach (var prep in context.Preparats.ToList())
                {
                    if (prep.id_preparat == preparat.id_preparat)
                        pret = double.Parse(prep.pret.ToString());
                }
                int bucati = 0;
                foreach (var prep in context.PreparatComandas.ToList())
                {
                    if (prep.id_preparat == preparat.id_preparat)
                        bucati = int.Parse(prep.nrBucati.ToString());
                }
                aux.Add(new InformatiiCos(denumire, bucati, pret));
            }
            foreach (var meniu in Meniuri(user))
            {
                string denumire = "";
                foreach (var prep in context.Menius.ToList())
                {
                    if (prep.id_meniu == meniu.id_meniu)
                        denumire = prep.denumireMeniu;
                }
                double pret = 0;
                foreach (var prep in context.Menius.ToList())
                {
                    if (prep.id_meniu == meniu.id_meniu)
                        pret = double.Parse(prep.pret.ToString());
                }
                int bucati = 0;
                foreach (var prep in context.MeniuComandas.ToList())
                {
                    if (prep.id_meniu == meniu.id_meniu)
                        bucati = int.Parse(prep.nrBucati.ToString());
                }
                aux.Add(new InformatiiCos(denumire, bucati, pret));
            }
            return aux;
        }

        internal void TrimiteComanda(Cont user)
        {
            bool activeCont = false;
            RestaurantEntities1 context = new RestaurantEntities1();

            foreach (var cont in context.DetaliiConts.ToList())
            {
                if(cont.id_cont==user.id_cont)
                {
                    activeCont = true;
                }
            }
            if (activeCont == true)
            {
                context.TrimiteComanda(user.email);
                var comenzi = context.Comandas.ToList();

                context.AdaugareComanda(0, user.email, DateTime.Now);
                context.SaveChanges();

                MessageBox.Show("Comanda trimisa!");
                MainViewModel.Instance.ActiveScreen = new PreparateViewModel("Toate categoriile", user);
            }
            else
            {
                MessageBox.Show("Sunt necesare mai multe detalii!");
                MainViewModel.Instance.ActiveScreen = new AdaugaDetaliiContViewMode(user);

            }
        }

        internal void StergeDinCos(InformatiiCos deSters,Cont user)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            int tip = 0;
            foreach(var preparat in context.Preparats.ToList())
            {
                if (deSters.Denumire == preparat.denumire)
                    tip = 1;
            }

            foreach (var meniu in context.Menius.ToList())
            {
                if (deSters.Denumire == meniu.denumireMeniu)
                    tip = 2;
            }
            if(tip==1)
            {
                context.stergePreparatDinCos(deSters.Denumire, IdComanda(user));
                MainViewModel.Instance.ActiveScreen = new CartViewModel(user);
            }
            else if(tip==2)
            {
                context.StergeMeniuDinCos(deSters.Denumire, IdComanda(user));
                MainViewModel.Instance.ActiveScreen = new CartViewModel(user);


            }
        }
    }
}
