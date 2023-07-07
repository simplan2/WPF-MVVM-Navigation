using MVVMNavigation.Commands;
using MVVMNavigation.Models;
using MVVMNavigation.Services;
using MVVMNavigation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMNavigation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string? _username;

        public string? Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private string? _password;

        public string? Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(AccountStore accountStore, INavigationService<AccountViewModel> accountNavigationService)
        {
            
            LoginCommand = new LoginCommand(this, accountStore, accountNavigationService);
        }
    }
}
