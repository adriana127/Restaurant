using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Command;
using Tema3.Model.Actions;

namespace Tema3.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        UserActions actions;
        public LoginViewModel()
        {
            actions =new UserActions();
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string userPassword;
        public string UserPassword
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        public ICommand LogIn
        {
            get
            {
                return new RelayCommand(() =>
                {
                    actions.LogIn(UserName, UserPassword);

                });
            }
        }
        public ICommand SignUp
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new SignUpViewModel();

                });
            }
        }
        public ICommand Continua
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainViewModel.Instance.ActiveScreen = new PreparateViewModel("Toate categoriile", null);

                });
            }
        }
        
    }
}
