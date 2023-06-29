using System.Net.Http.Headers;
using System.Text.Json;

namespace MTASA.Http.Sdk
{
    public class Client
    {
        private readonly HttpClient _httpClient;
        private readonly string _serverUri;
        private readonly AuthenticationHeaderValue? _authHeaderValue;

        public Client(string host = "127.0.0.1", int port = 22005, string? user = null, string? password = null, string protocol = "http")
        {
            _httpClient = new HttpClient();
            _serverUri = $"{protocol}://{host}:{port}";

            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
            {
                var credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{user}:{password}"));
                _authHeaderValue = new AuthenticationHeaderValue("Basic", credentials);
            }
        }

        public async Task<T?> Call<T>(string resourceName, string procedureName, params object[] args)
        {
            var uri = $"{_serverUri}/{resourceName}/call/{procedureName}";
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"dotnet-mtasa-http-sdk/{Environment.Version}");
            _httpClient.DefaultRequestHeaders.Authorization = _authHeaderValue;

            var content = new StringContent(JsonSerializer.Serialize(args));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var deserializedInstance = JsonSerializer.Deserialize<List<T>>(responseContent);
            if (deserializedInstance != null)
                return deserializedInstance[0];

            return default(T);
        }
    }
}