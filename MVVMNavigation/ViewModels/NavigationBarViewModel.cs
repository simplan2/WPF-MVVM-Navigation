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
    public class NavigationBarViewModel: ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand LogoutCommand { get; }

        public bool IsLoggedIn => _accountStore.IsLoggedIn;
           
        public NavigationBarViewModel(AccountStore accountStore,
            INavigationService homeNavigationService,
            INavigationService loginNavigationService,
            INavigationService accountNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            _accountStore = accountStore;
            LogoutCommand = new LogoutCommand(_accountStore);
            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
            base.Dispose();
        }
    }
}
