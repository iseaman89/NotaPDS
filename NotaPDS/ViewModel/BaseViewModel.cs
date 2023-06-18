using NotaPDS.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NotaPDS.ViewModel
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