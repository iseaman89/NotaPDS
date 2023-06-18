using System;
using BAPDS.View;
using BAPDS.Service;
using CommunityToolkit.Mvvm.Input;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace BAPDS.ViewModel
{
	public partial class MainPageViewModel : BaseViewModel
	{
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
		{
        }

        [RelayCommand]
        private void Login() => NavigationService.NavigateToAsync(nameof(ProjectChoisePage));
    }
}

