using MVVMNavigation.Models;
using MVVMNavigation.Services;
using MVVMNavigation.Stores;
using MVVMNavigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMNavigation.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly INavigationService _navigationService;
   

        public LoginCommand(LoginViewModel viewModel,AccountStore accountStore, INavigationService NavigationService)
        {
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigationService = NavigationService;
 
        }

        public override void Execute(object? parameter)
        {
            //MessageBox.Show($"Logging in {_viewModel.Username}...");
            Account account = new Account()
            {
                Email = $"{_viewModel.Username}@test.com",
                Username = _viewModel.Username,
            };

            _accountStore.CurrentAccount = account;
            _navigationService.Navigate();
        }
    }
}
