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

        public NavigationBarViewModel NavigationBarViewModel { get; }
        public ICommand NavigateloginCommand { get;}

        public HomeViewModel(NavigationBarViewModel navigationBarViewModel, NavigationService<LoginViewModel> loginNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;

            NavigateloginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
