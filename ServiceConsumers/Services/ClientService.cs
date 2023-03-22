namespace ServiceConsumers.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;
        public static string _vmServiceUrl = "https://localhost:7035/api/vm/";

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Create()
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsync(_vmServiceUrl + "create", null);
            responseMessage.EnsureSuccessStatusCode();
            string requestId = await responseMessage.Content.ReadAsStringAsync();
            return requestId;
        }

        public async Task<string> GetStatus(string requestId)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(_vmServiceUrl + $"status?requestId={requestId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                string status = await responseMessage.Content.ReadAsStringAsync();
                return status;
            }
            return null;

        }
    }
}
