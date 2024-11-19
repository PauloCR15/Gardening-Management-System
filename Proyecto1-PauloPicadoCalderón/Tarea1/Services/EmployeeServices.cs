using Newtonsoft.Json;
using Tarea1.Models;
using System.Text;
namespace Tarea1.Services
{
    public class EmployeeServices : IServicesEmployee
    {
        private string _baseURL;
        private readonly HttpClient client;
        public EmployeeServices()
        {
            _baseURL = "http://localhost:5141";
            client = new HttpClient { BaseAddress = new Uri(_baseURL) };

        }
        public async Task<List<Employee>> Get()
        {
            List<Employee> employees = new List<Employee>();
            var response = await client.GetAsync("api/Employee");
            if (response.IsSuccessStatusCode)
            {
                var json_Response = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Employee>>(json_Response);
                if (result != null)
                {
                    employees = result;
                }
            }
            return employees;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee? employee = null;
            var response = await client.GetAsync($"api/Employee/GetById/{id}");
            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Employee>(JsonResponse);
                if (result != null)
                {
                    employee = result;
                }
            }
            return employee ?? throw new Exception("Employee not found");
        }
        public async Task<bool> Post(Employee employee)
        {
            bool saved = true;
            var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/Employee", content);
            if (!response.IsSuccessStatusCode)
            {
                saved = false;
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage); // Lanza la excepción con el mensaje de error
            }
            return saved;
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            bool deleted = false;
            var response = await client.DeleteAsync($"api/Employee/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                deleted = true;
            }
            return deleted;
        }
        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            bool updated = false;
            var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/Employee/Edit/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                updated = true;
            }
            return updated;
        }
    }
}

