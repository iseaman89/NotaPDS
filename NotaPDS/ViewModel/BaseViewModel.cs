using System;
using BAPDS.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BAPDS.ViewModel
{
	public partial class BaseViewModel : ObservableObject
	{
		protected INavigationService NavigationService;
		public BaseViewModel(INavigationService navigationService)
		{
			NavigationService = navigationService;
		}
	}
}

