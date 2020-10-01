using Tema3.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tema3.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public BaseViewModel activeScreen = new LoginViewModel();
        public BaseViewModel ActiveScreen
        {
            get { return activeScreen; }


            set { activeScreen = value; OnPropertyChanged(nameof(ActiveScreen)); }
        }


        public MainViewModel()
        {
            Instance = this;
        }

        public static MainViewModel Instance { get; private set; }

    }
}
