using Microsoft.Extensions.DependencyInjection;
using MVVMNavigation.Services;
using MVVMNavigation.Stores;
using MVVMNavigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MVVMNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<AccountStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();

            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
            services.AddSingleton<CloseModalNavigationService>();

            services.AddTransient<HomeViewModel>(s => new HomeViewModel(CreateLoginNavigationService(s)));

            services.AddTransient<AccountViewModel>(s => new AccountViewModel(
                s.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(s)));

            services.AddTransient<LoginViewModel>(CreateLoginViewModel);
            services.AddSingleton<NavigationBarViewModel>(CreateNavigationBarViewModel);

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
            _serviceProvider = services.BuildServiceProvider();
        }

        private LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new CompositeNavigationService(
               serviceProvider.GetRequiredService<CloseModalNavigationService>(),
               CreateAccountNavigationService(serviceProvider));

            return new LoginViewModel(
                serviceProvider.GetRequiredService<AccountStore>(),
                navigationService);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavegationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavegationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            ModalNavigationStore modalNavigationStore = serviceProvider.GetRequiredService<ModalNavigationStore>();
            return new ModalNavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
             () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        private INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {

            return new LayoutNavigationService<AccountViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                serviceProvider.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(serviceProvider),
                CreateLoginNavigationService(serviceProvider),
                CreateAccountNavigationService(serviceProvider));
        }

    }
}
