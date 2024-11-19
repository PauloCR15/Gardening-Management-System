using Tarea1.Models;

namespace Tarea1.Services
{
    public interface IServicesEmployee
    {
        public Task<List<Employee>> Get();
        public Task<bool> Post(Employee employee);
        public Task<Employee> GetEmployeeById(int id);
        public Task<bool> UpdateEmployee(int id, Employee employee);
        public Task<bool> DeleteEmployee(int id);
    }
}
