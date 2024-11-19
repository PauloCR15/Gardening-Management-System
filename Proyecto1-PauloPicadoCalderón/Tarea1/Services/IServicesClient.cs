using Tarea1.Models;
namespace Tarea1.Services
{
    public interface IServicesClient
    {
        public Task<List<Client>> Get();
        public Task<Client> GetClientById(int id);
        public Task<bool> Post(Client client);
        public Task<bool> DeleteClient(int id);
        public Task<bool> UpdateClient(int id,Client client);

    }
}
