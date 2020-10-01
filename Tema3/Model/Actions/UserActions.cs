using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3.ViewModel;

namespace Tema3.Model.Actions
{
    public class UserActions
    {
        public UserActions() { }

        public void SignUp(string name, string password, bool statut)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            var conturi = context.Conts.ToList();
            bool contExistent = false;
            foreach (var cont in conturi)
            {
                if (cont.email == name)
                {

                    MessageBox.Show("Cont deja creat!");
                    contExistent = true;
                }
            }
            if (contExistent == false)
            {
                if (statut == true)
                    context.AdaugareCont(name, password, "Angajat");
                else
                    context.AdaugareCont(name, password, "Client");
                context.SaveChanges();
                MessageBox.Show("Cont creat cu succes!");
                MainViewModel.Instance.ActiveScreen = new LoginViewModel();
            }
        }

        public void LogIn(string name, string password)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            var conturi = context.Conts.ToList();
            bool contExistent = false;
            foreach (var cont in conturi)
            {
                if (cont.email == name)
                {
                    if (cont.parola == password)
                    {
                        var comenzi = context.Comandas.ToList();

                        bool comandaNoua = true;
                        foreach (var comanda in comenzi)
                        {
                            if (comanda.Cont.email == cont.email && comanda.id_status == 505)
                            {
                                comandaNoua = false;
                                break;
                            }
                        }
                        if (comandaNoua == true)
                        {
                            context.AdaugareComanda(0, cont.email, DateTime.Now);
                            context.SaveChanges();
                        }
                        MessageBox.Show("Bun venit!");
                        MainViewModel.Instance.ActiveScreen = new PreparateViewModel("Toate categoriile", cont);
                    }
                    else
                    {
                        MessageBox.Show("Parola gresita!");

                    }
                    contExistent = true;
                }
            }
            if (contExistent == false)
            {
                MessageBox.Show("Cont inexistent!");
            }
        }

        internal void AddDetails(Cont user, string nume, string prenume, string numar, string adresa)
        {
            RestaurantEntities1 context = new RestaurantEntities1();
            if (nume == "" || nume == null || prenume == "" || prenume == null || numar == "" || numar == null || adresa == "" || adresa == null)
                MessageBox.Show("Informatii incomplete!");
            else
            {
                context.AdaugareDetaliiCont(nume, prenume, adresa, int.Parse(numar.ToString()), user.email);
                MessageBox.Show("Detalii Salvate!");
                MainViewModel.Instance.ActiveScreen = new CartViewModel(user);
            }
        }
    }
}
