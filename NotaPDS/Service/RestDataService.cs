using System.Text.Json;

namespace NotaPDS.Service
{
	public class RestDataService
	{
        protected readonly HttpClient _httpClient;
        protected readonly string _baseAdress;
        protected readonly string _url;
        protected readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService()
		{
            _httpClient = new HttpClient();
            _baseAdress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5031" : "https://localhost:7206";
            _url = $"{_baseAdress}/api";
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
		}
    }
}