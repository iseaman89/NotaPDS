using NotaPDS.Model;
using System.Diagnostics;
using System.Text.Json;

namespace NotaPDS.Service
{
    public class UserService : RestDataService, IRestDataService<User>
    {
        //Add
        public Task AddItemAsync(User item)
        {
            throw new NotImplementedException();
        }

        //Delete
        public Task DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Get
        public async Task<List<User>> GetAllItemsAsync()
        {
            List<User> users = new List<User>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access...");
                return users;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/user");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    users = JsonSerializer.Deserialize<List<User>>(content, _jsonSerializerOptions);
                }
                else Debug.WriteLine("Non Http 2xx response");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return users;
        }

        //Update
        public Task UpdateItemAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}

