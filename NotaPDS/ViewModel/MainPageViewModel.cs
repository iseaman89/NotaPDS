using NotaPDS.View;
using NotaPDS.Service;
using NotaPDS.Model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace NotaPDS.ViewModel
{
	public partial class MainPageViewModel : BaseViewModel
	{
        IRestDataService<User> _userService;
        public ObservableCollection<User> Users { get; set; } = new();
        [ObservableProperty]
        private string _email, _password;

        public MainPageViewModel(INavigationService navigationService, IRestDataService<User> userService) : base(navigationService)
        {
            _userService = userService;
        }

        private async Task GetProjectsAsync()
        {
            List<User> users = await _userService.GetAllItemsAsync();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        [RelayCommand]
        private void Login()
        {
            _ = GetProjectsAsync();

            foreach (var user in Users)
            {
                if (user.Email == Email && user.Password == Password)
                {
                    NavigationService.NavigateToAsync(nameof(ProjectChoisePage));
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Warning!", "Email or Password is't correct!", "Ok");
                }
            }
        }
    }
}