using MVVMNavigation.Stores;
using MVVMNavigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMNavigation.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigateStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;
               
        public LayoutNavigationService(NavigationStore navigateStore, Func<TViewModel> createViewModel, Func<NavigationBarViewModel> createNavigationBarViewModel)
        {
            _navigateStore = navigateStore;
            _createViewModel = createViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
        }

        public void Navigate()
        {
            _navigateStore.CurrentViewModel = new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel());
        }
    }
}
