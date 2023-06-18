using NotaPDS.Model;
using NotaPDS.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NotaPDS.ViewModel
{
    [QueryProperty(nameof(Project), nameof(Project))]
    public partial class CustomerPageViewModel : BaseViewModel
	{
        [ObservableProperty]
        private Project _project;

        public CustomerPageViewModel(INavigationService navigationService) : base(navigationService) {}
	}
}