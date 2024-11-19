using Newtonsoft.Json;
using static Tarea1.Models.Report;

namespace Tarea1.Services
{
    public class ReportServices : IServicesReport
    {
        private string _baseURL;
        private readonly HttpClient client;
        public ReportServices()
        {
            _baseURL = "http://localhost:5141";
            client = new HttpClient { BaseAddress = new Uri(_baseURL) };
        }

        public async Task<List<ProximosServiciosReport>> GetProximosServicios()
        {
            List<ProximosServiciosReport> reports = new List<ProximosServiciosReport>();
            var response = await client.GetAsync("api/Report/ProximosServicios");
            if (response.IsSuccessStatusCode)
            {
                var json_Response = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProximosServiciosReport>>(json_Response);
                if (result != null)
                {
                    reports = result;
                }
            }
            return reports;
        }

        public async Task<List<ClientesSinServiciosReport>> GetClientesSinServicios()
        {
            List<ClientesSinServiciosReport> reports = new List<ClientesSinServiciosReport>();
            var response = await client.GetAsync("api/Report/ClientesSinServicios");
            if (response.IsSuccessStatusCode)
            {
                var json_Response = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ClientesSinServiciosReport>>(json_Response);
                if (result != null)
                {
                    reports = result;
                }
            }
            return reports;
        }
    }
}
