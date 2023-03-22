using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConsumer.Services
{
    public class VMService
    {
        private static HttpClient _httpClient = new HttpClient();
        private static string _vmServiceUrl = "https://localhost:7035/api/vm/";

        public string Create()
        {
            HttpResponseMessage response = _httpClient.PostAsync(_vmServiceUrl + "create", null).Result;
            if(!response.IsSuccessStatusCode)
            {
                return null;
            }
            string requestId = response.Content.ReadAsStringAsync().Result;
            return requestId;
        }

        public string GetStatus(string requestId)
        {
            HttpResponseMessage response = _httpClient.GetAsync(_vmServiceUrl + "status?requestId=" + requestId).Result;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string status = response.Content.ReadAsStringAsync().Result;
            return status;
        }
    }
}
