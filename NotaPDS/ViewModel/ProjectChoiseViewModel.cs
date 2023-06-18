using System.Collections.ObjectModel;
using NotaPDS.Model;
using NotaPDS.View;
using NotaPDS.Service;
using CommunityToolkit.Mvvm.Input;

namespace NotaPDS.ViewModel
{
	public partial class ProjectChoiseViewModel : BaseViewModel
    {
        private IRestDataService<Project> _projectService;

        public ObservableCollection<Project> Projects { get; set; } = new();

        public ProjectChoiseViewModel(IRestDataService<Project> projectService, INavigationService navigationService) : base(navigationService)
		{
            _projectService = projectService;
            _ = GetProjectsAsync();
        }

        private async Task GetProjectsAsync()
        {
            List<Project> projects = await _projectService.GetAllItemsAsync();
            foreach (var project in projects)
            {
                Projects.Add(project);
            }
        }

        [RelayCommand]
        public void GoToProject(Project project)
        {
            if (project is null) return;

            NavigationService.NavigateToAsync(nameof(ProjectPage), new Dictionary<string, object> {{"Project", project }});
        }

        [RelayCommand]
        public void ShowNewProjectPopup() => NavigationService.NavigateToAsync(nameof(NewProjectPage));
    }
}