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
	public class AddPersonViewModel : ViewModelBase
	{
		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }

		public AddPersonViewModel(PeopleStore peopleStore, INavigationService closeNavigationService)
		{
            SubmitCommand = new AddPersonCommand(this, peopleStore, closeNavigationService);
			CancelCommand = new NavigateCommand(closeNavigationService);

        }

	}
}
