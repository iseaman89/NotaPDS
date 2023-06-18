using System;
using BAPDS.Model;
using BAPDS.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BAPDS.ViewModel
{
    [QueryProperty(nameof(Project), "Project")]
    public partial class CustomerPageViewModel : BaseViewModel
	{
        [ObservableProperty]
        private ProjectDB _project;

        public CustomerPageViewModel(INavigationService navigationService) : base(navigationService)
		{
		}
	}
}

