using Tema3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tema3.Model.Actions
{
    class AdaugarePreparatActions
    {
        private AdaugarePreparatViewModel prepContext;
        public AdaugarePreparatActions(AdaugarePreparatViewModel prepContext)
        {
            this.prepContext = prepContext;
        }
        public ObservableCollection<Categorie> ListaCategorii()
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            var a = context.Categories.SqlQuery("[AfisareCategorii]").ToList();

            ObservableCollection<Categorie> result = new ObservableCollection<Categorie>();
            foreach (var categorie in a)
            {
                result.Add(categorie);
            }
            return result;
        }

        public void AdaugaPoza(int id)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();


            string iName = dlg.FileName;
            string folder = @"\Image\";
            var path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName,Path.GetFileName(iName));
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            context.AdaugarePoza(path, id);

            string currentFolder = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName;
            File.Copy(iName, path);
        }

        public void Adauga(Cont user,int id, string denumire, double pret, double cantitate, double cantitate_Totala, Categorie categorie)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            if (prepContext.ExistingRecord == false)

            {
                var preparate = context.Preparats.ToList();
                List<string> listaPreparate = new List<string>();
                foreach (var preparatNou in preparate)
                {
                    listaPreparate.Add(preparatNou.denumire);
                }
                if (listaPreparate.Contains(denumire) == false)
                {
                    context.AdaugarePreparatCategorie(categorie.denumire, denumire, pret, cantitate, cantitate_Totala);
                    context.SaveChanges();

                    MainViewModel.Instance.ActiveScreen = new PreparateViewModel("Toate categoriile",user);
                    System.Windows.MessageBox.Show("Preparat Adaugat!");
                }
                else
                {
                    MessageBox.Show("Preparatul deja exista!");
                }
            }
            else
            {
                var preparate = context.Preparats.ToList();
                Preparat preparat1 = new Preparat();
                foreach (var preparat in preparate)
                {
                    if (preparat.id_preparat == id)
                    {
                        preparat1 = preparat;
                    }
                }
                if (categorie == null)
                {
                    MessageBox.Show("Selectati o categorie!");

                }
                else
                {
                    context.ModificaPreparat(id, denumire, pret, cantitate, cantitate_Totala, categorie.id_categorie);
                    context.SaveChanges();

                    MessageBox.Show("Preparat Modificat!");
                    MainViewModel.Instance.ActiveScreen = new PreparateViewModel("Toate categoriile",user);

                }
            }

        }

        public ObservableCollection<Fotografie> AfisarePoze(int idPreparat)
        {
            RestaurantEntities1 context = new RestaurantEntities1();

            var poze = context.Fotografies.ToList();
            ObservableCollection<Fotografie> pozePreparat = new ObservableCollection<Fotografie>();

            foreach (var poza in poze)
            {
                if(poza.id_preparat==idPreparat)
                pozePreparat.Add(poza);
            }

            return pozePreparat;
        }

        internal void StergePoza(int idPreparat, Fotografie pozaDeSters)
        {
            RestaurantEntities1 context = new RestaurantEntities1();
            context.StergePoza(pozaDeSters.id_foto, idPreparat);
            context.SaveChanges();
        }
    }
}
