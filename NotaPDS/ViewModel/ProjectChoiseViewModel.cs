using System;
using FireSharp.Config;
using FireSharp.Interfaces;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using BAPDS.Model;
using BAPDS.View;
using BAPDS.Service;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace BAPDS.ViewModel
{
	public partial class ProjectChoiseViewModel : BaseViewModel
    {
        private ProjectService _projectService;

        public ObservableCollection<ProjectDB> Projects { get; set; } = new();

        public ProjectChoiseViewModel(ProjectService projectService, INavigationService navigationService) : base(navigationService)
		{
            _projectService = projectService;
            GetProjectsAsync();
        }

        private async Task GetProjectsAsync()
        {
            try
            {
                var projects = await _projectService.GetProjects();
                if (Projects.Count != 0) Projects.Clear();
                foreach (var project in projects)
                {
                    Projects.Add(project);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Eror", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public void GoToProject(ProjectDB project)
        {
            if (project is null) return;

            NavigationService.NavigateToAsync(nameof(ProjectPage), new Dictionary<string, object> {{"Project", project }});
        }
    }
}

