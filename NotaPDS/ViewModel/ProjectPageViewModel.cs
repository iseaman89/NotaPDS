using System;
using BAPDS.Model;
using BAPDS.Service;
using BAPDS.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BAPDS.ViewModel
{
    [QueryProperty(nameof(Project), "Project")]
	public partial class ProjectPageViewModel : BaseViewModel
	{
        [ObservableProperty]
        private ProjectDB _project;

        public ProjectPageViewModel(INavigationService navigationService) : base(navigationService)
		{
        }

        [RelayCommand]
        private void GoToCustomer(ProjectDB project)
        {
            if (project is null) return;

            NavigationService.NavigateToAsync(nameof(CustomerPage), new Dictionary<string, object> { { "Project", project } });
        }

        private void ChatBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new ChatPage(ProjectV));
        }
    }
}