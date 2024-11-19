using Tarea1.Models;

namespace Tarea1.Services
{
    public interface IServicesMaintenance
    {
        Task<List<Maintenance>> Get();
        Task<bool> Post(Maintenance maintenance);
        Task<bool> Delete(int id);
        Task<bool> Edit(int id, Maintenance maintenance);
        Task<Maintenance> Get(int id);
        Task<int> GetID();
    }
}
