using System;
using BAPDS.Model;
using FireSharp.Config;
using FireSharp.Interfaces;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace BAPDS.Service
{
	public class ProjectService
	{
        private IFirebaseConfig _config = new FirebaseConfig
        {
            AuthSecret = "1sbCn04JQ7vckC9lg8caux4dI8xFUyiAGIAPmhSz",
            BasePath = "https://bapds-48d75-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        private IFirebaseClient _client;

        private HttpClient _httpClient;

		private List<ProjectDB> _projects = new ();

		public ProjectService()
		{
			_httpClient = new HttpClient();
            _client = new FireSharp.FirebaseClient(_config);
        }

		public async Task<List<ProjectDB>> GetProjects()
		{
			if (_projects.Count > 0) return _projects;
            var response = await _client.GetAsync(@"ProjectDB");

            Dictionary<string, ProjectDB> projectDictionary = JsonConvert.DeserializeObject<Dictionary<string, ProjectDB>>(response.Body.ToString());

            foreach (var project in projectDictionary)
            {
                project.Value.FullNumber = project.Key;
                _projects.Add(project.Value);
            }

            return _projects;
        }
	}
}

