using MVVMNavigation.Commands;
using MVVMNavigation.Models;
using MVVMNavigation.Services;
using MVVMNavigation.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMNavigation.ViewModels
{
    public class PeopleListingViewModel: ViewModelBase
    {
        private readonly ObservableCollection<Person> _people;
        public IEnumerable<Person> People => _people;

        public ICommand AddPersonCommand { get; }

        public PeopleListingViewModel(PeopleStore peopleStore, INavigationService addPersonNavigationService)
        {

            AddPersonCommand = new NavigateCommand(addPersonNavigationService);
                _people = new ObservableCollection<Person>(){ 
                    new Person(){Name="Mario"},
                    new Person(){Name="Juanes"},
                    new Person(){Name="Rosario"}
                };
            peopleStore.PersonAdded += OnPersonAdded;
        }

        private void OnPersonAdded(string name)
        {
            _people.Add(new Person(){ Name= name});
        }
    }
}
