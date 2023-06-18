using NotaPDS.Model;
using NotaPDS.Service;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NotaPDS.ViewModel
{
	public partial class NewProjectViewModel : ObservableObject
	{
		[ObservableProperty]
		private string _projectNumberEntry, _customerEntry, _contactPersonEntry, _telEntry, _adressEntry, _importInfoEntry;
        private IRestDataService<Project> _projectService;

		public NewProjectViewModel(IRestDataService<Project> projectService)
		{
			_projectService = projectService;
		}

        [RelayCommand]
		public void SaveButton()
		{
            _projectService.AddItemAsync(new Project()
			{
                FullNumber = ProjectNumberEntry,
                YearNumber = ProjectNumberEntry.Remove(2),
                ProjectManagerNumber = ProjectNumberEntry.Remove(0, 2).Remove(3),
                ProjectNumber = ProjectNumberEntry.Remove(0, 4),
				Customer = new Customer()
				{
                    Name = CustomerEntry,
                    ContactPersonFullName = ContactPersonEntry,
                    ContactPersonTel = TelEntry,
                    Adresse = AdressEntry,
                    ImportantInformation = ImportInfoEntry
                }
            });

            Shell.Current.GoToAsync("..");
        }

		[RelayCommand]
        public async void CancelButton() => await Shell.Current.GoToAsync("..");
	}
}