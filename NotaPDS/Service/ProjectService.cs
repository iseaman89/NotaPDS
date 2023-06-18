using NotaPDS.Model;
using System.Diagnostics;
using System.Text.Json;
using System.Text;

namespace NotaPDS.Service
{
    public class ProjectService : RestDataService, IRestDataService<Project>
    {
        //Add
        public async Task AddItemAsync(Project item)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access...");
                return;
            }

            try
            {
                string jsonProject = JsonSerializer.Serialize<Project>(item, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonProject, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/project", content);

                if (response.IsSuccessStatusCode) Debug.WriteLine("Successfully created!");
                else Debug.WriteLine("Non Http 2xx response");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;
        }

        //Delete
        public async Task DeleteItemAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access...");
                return;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/project/{id}");

                if (response.IsSuccessStatusCode) Debug.WriteLine("Successfully deleted!");
                else Debug.WriteLine("Non Http 2xx response");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;
        }

        //Get
        public async Task<List<Project>> GetAllItemsAsync()
        {
            List<Project> projects = new List<Project>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access...");
                return projects;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/project");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    projects = JsonSerializer.Deserialize<List<Project>>(content, _jsonSerializerOptions);
                }
                else Debug.WriteLine("Non Http 2xx response");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return projects;
        }

        //Update
        public async Task UpdateItemAsync(Project item)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access...");
                return;
            }

            try
            {
                string jsonProject = JsonSerializer.Serialize<Project>(item, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonProject, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/project/{item.Id}", content);

                if (response.IsSuccessStatusCode) Debug.WriteLine("Successfully created!");
                else Debug.WriteLine("Non Http 2xx response");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;
        }
    }
}