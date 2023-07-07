using MVVMNavigation.ViewModels;

namespace MVVMNavigation.Services
{
    public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        void Navigate();
    }
}