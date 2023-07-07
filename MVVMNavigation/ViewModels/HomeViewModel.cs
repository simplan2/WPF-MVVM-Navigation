using MVVMNavigation.Commands;
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
    public class HomeViewModel: ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application.";

        public ICommand NavigateloginCommand { get;}

        public HomeViewModel(INavigationService<LoginViewModel> loginNavigationService)
        {

            NavigateloginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
