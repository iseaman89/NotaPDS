using NotaPDS.Model;
using NotaPDS.Service;
using NotaPDS.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NotaPDS.ViewModel
{
    [QueryProperty(nameof(Project), "Project")]
	public partial class ProjectPageViewModel : BaseViewModel
	{
        [ObservableProperty]
        private Project _project;

        public ProjectPageViewModel(INavigationService navigationService) : base(navigationService) {}

        [RelayCommand]
        private void GoToCustomer(Project project)
        {
            if (project is null) return;

            NavigationService.NavigateToAsync(nameof(CustomerPage), new Dictionary<string, object> { { "Project", project } });
        }

        [RelayCommand]
        private void GoToChat() => NavigationService.NavigateToAsync(nameof(ChatPage));
    }
}