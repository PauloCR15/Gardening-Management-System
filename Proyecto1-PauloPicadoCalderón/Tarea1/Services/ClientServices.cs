using Tarea1.Services;
using Tarea1.Models;
using Newtonsoft.Json;
using System.Text;
namespace Tarea1.Services
{
    public class ClientServices : IServicesClient
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        public ClientServices()
        {
            _baseUrl = "http://localhost:5141";
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        }

        public async Task<List<Client>> Get()
        {
            List<Client> clients = new List<Client>();
            var response = await _httpClient.GetAsync("api/Client");
            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Client>>(JsonResponse);
                if (result != null)
                {
                    clients = result;
                }
            }
            return clients;
        }

        public async Task<Client> GetClientById(int id)
        {
            Client? cliente = null;
            var response = await _httpClient.GetAsync($"api/client/GetbyID/{id}");
            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                cliente = JsonConvert.DeserializeObject<Client>(JsonResponse);
            }
            return cliente ?? throw new Exception("Client not found");
        }
        public async Task<bool> Post(Client client)
        {
            if (client.SummerMowingPreferenceName == "Quincenal")
            {
                client.SummerMowingPreferenceID = 1;
            }
            else
            {
                client.SummerMowingPreferenceID = 2;
            }
            if (client.WinterMowingPrecerenceName == "Quincenal")
            {
                client.WinterMowingPreferenceID = 1;
            }
            else
            {
                client.WinterMowingPreferenceID = 2;
            }

            bool saved = true;
            var content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/client", content);
            if (!response.IsSuccessStatusCode)
            {
                saved = false;
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
            return saved;
        }
        public async Task<bool> DeleteClient(int id)
        {
            bool deleted = false;
            var response = await _httpClient.DeleteAsync($"api/client/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                deleted = true;
            }
            return deleted;
        }
        public async Task<bool> UpdateClient(int id, Client client)
        {
            if (client.SummerMowingPreferenceName == "Quincenal")
            {
                client.SummerMowingPreferenceID = 1;
            }
            else
            {
                client.SummerMowingPreferenceID = 2;
            }
            if (client.WinterMowingPrecerenceName == "Quincenal")
            {
                client.WinterMowingPreferenceID = 1;
            }
            else
            {
                client.WinterMowingPreferenceID = 2;
            }
            bool updated = false;
            var content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/client/Edit/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                updated = true;
            }
            return updated;
        }
    }
}
