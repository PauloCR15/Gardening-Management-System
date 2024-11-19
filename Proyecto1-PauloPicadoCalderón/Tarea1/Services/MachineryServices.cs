using Newtonsoft.Json;
using Tarea1.Models;
using System.Text;
namespace Tarea1.Services
{
    public class MachineryServices : IServicesMachinery
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        public MachineryServices()
        {
            _baseUrl = "http://localhost:5141";
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        }
        public async Task<List<Machinery>> Get()
        {
            List<Machinery> machineries = new List<Machinery>();
            var response = await _httpClient.GetAsync("api/Machinery");
            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Machinery>>(JsonResponse);
                if (result != null)
                {
                    machineries = result;
                }
            }
            return machineries;
        }
        public async Task<Machinery> GetMachineryByID(int id)
        {
            Machinery? machinery = null;
            var response = await _httpClient.GetAsync($"api/Machinery/GetbyID/{id}");
            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                machinery = JsonConvert.DeserializeObject<Machinery>(JsonResponse);
            }
            return machinery ?? throw new Exception("Machinery not found");
        }
        public async Task<bool> Post(Machinery machinery)
        {
            bool saved = true;
            var content = new StringContent(JsonConvert.SerializeObject(machinery), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Machinery", content);
            if (!response.IsSuccessStatusCode)
            {
                saved = false;
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
            return saved;
        }
        public async Task<bool> UpdateMachinery(int id, Machinery machinery)
        {
            bool updated = false;
            var content = new StringContent(JsonConvert.SerializeObject(machinery), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/Machinery/Edit/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                updated = true;
            }
            return updated;
        }
        public async Task<bool> DeleteMachinery(int id)
        {
            bool deleted = false;
            var response = await _httpClient.DeleteAsync($"api/Machinery/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                deleted = true;
            }
            return deleted;
        }
        public async Task<int> GetLastMachineryID()
        {
            int id = 0;
            var response = await _httpClient.GetAsync("api/Machinery/GetLastMachineryID");
            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                id = JsonConvert.DeserializeObject<int>(JsonResponse);
            }
            return id;
        }
    }
}

