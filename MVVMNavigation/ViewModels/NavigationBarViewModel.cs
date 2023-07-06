﻿using MVVMNavigation.Commands;
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

        public bool IsLoggedIn => _accountStore.IsLoggedIn;

   

        public NavigationBarViewModel(AccountStore accountStore,
            NavigationService<HomeViewModel> homeNavigationService,
            NavigationService<LoginViewModel> loginNavigationService,
            NavigationService<AccountViewModel> accountNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
            _accountStore = accountStore;
        }
    }
}
