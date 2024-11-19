using Newtonsoft.Json;
using Tarea1.Models;
using System.Text;
namespace Tarea1.Services
{
    public class MaintenanceServices : IServicesMaintenance
    {
        private string _baseURL;
        private readonly HttpClient client;
        public MaintenanceServices()
        {
            _baseURL = "http://localhost:5141";
            client = new HttpClient { BaseAddress = new Uri(_baseURL) };
        }
        public async Task<List<Maintenance>> Get()
        {
            List<Maintenance> maintenances = new List<Maintenance>();
            var response = await client.GetAsync("/api/Maintenance");
            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Maintenance>>(JsonResponse);
                if (result != null)
                {

                    maintenances = result;
                }
            }
            return maintenances;
        }
        public async Task<Maintenance> Get(int id)
        {
            Maintenance? maintenance = null;
            var response = await client.GetAsync($"/api/Maintenance/{id}");
            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Maintenance>(JsonResponse);
                if (result != null)
                {
                    maintenance = result;
                }
            }
            return maintenance ?? throw new Exception("Mantenimiento no encontrado");

        }
        public async Task<int> GetID()
        {
            int id = 0;
            var response = await client.GetAsync("/api/Maintenance/GetMaintenanceID");
            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<int>(JsonResponse);
                id = result;
            }
            return id;
        }
        public async Task<bool> Post(Maintenance maintenance)
        {
            if (maintenance.AppliedProductName == null)
            {
                maintenance.AppliedProductName = "";
            }
            
            bool saved = true;
            var content = new StringContent(JsonConvert.SerializeObject(maintenance), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/Maintenance", content);
            if (!response.IsSuccessStatusCode)
            {
                saved = false;
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
            return saved;
        }
        public async Task<bool> Delete(int id)
        {
            bool deleted = false;
            var response = await client.DeleteAsync($"/api/Maintenance/{id}");
            if (response.IsSuccessStatusCode)
            {
                deleted = true;
            }
            return deleted;
        }

        public async Task<bool> Edit(int id, Maintenance maintenance)
        {
            bool edited = true;
            var content = new StringContent(JsonConvert.SerializeObject(maintenance), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/Maintenance/{id}", content);
            if (!response.IsSuccessStatusCode)
            {
                edited = false;
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
            return edited;
        }
    }
}