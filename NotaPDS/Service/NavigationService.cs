using System;

namespace BAPDS.Service
{
    public class NavigationService : INavigationService
    {
        public Task NavigateToAsync(string route, IDictionary<string, object> parameters = null)
        {
            if (parameters != null) return Shell.Current.GoToAsync(route, parameters);
            else return Shell.Current.GoToAsync(route);
        }
    }
}

