using Tarea1.Models;

namespace Tarea1.Services
{
    public interface IServicesMachinery
    {
        public Task<List<Machinery>> Get();
        public Task<bool> Post(Machinery machinery);
        public Task<Machinery> GetMachineryByID(int id);
        public Task<bool> UpdateMachinery(int id, Machinery machinery);
        public Task<bool> DeleteMachinery(int id);
        public Task<int> GetLastMachineryID();
    }
}
