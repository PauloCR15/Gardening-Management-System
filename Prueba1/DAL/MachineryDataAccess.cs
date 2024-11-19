using Microsoft.EntityFrameworkCore;
using Models;
using System.Reflection.Metadata;
namespace Prueba1.DAL
{
    public class MachineryDataAccess
    {
        private readonly DBContext _dbContext;
        public MachineryDataAccess(DBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public List<Machinery> GetMachinery()
        {
            return _dbContext.Machinery.ToList();
        }
        public Machinery? GetMachineryByID(int id)
        {
            return _dbContext.Machinery.FirstOrDefault(m => m.MachineryID == id);
        }
        public void AddMachinery(Machinery m)
        {
            _dbContext.Machinery.Add(m);
            _dbContext.SaveChanges();
        }
        public void DeleteMachinery(int id)
        {
            var machinery = _dbContext.Machinery.Find(id);
            if (machinery == null)
            {
                throw new Exception("No existe la maquinaria con ID" + id);
            }
            _dbContext.Machinery.Remove(machinery);
            _dbContext.SaveChanges();
        }
        public void UpdatMachinery(int id, Machinery Updatedmachinery)
        {
            var machinery = _dbContext.Machinery.Find(Updatedmachinery.MachineryID);
            if (machinery != null)
            {
                machinery.MachineryID = Updatedmachinery.MachineryID;
                machinery.MachineryDescription = Updatedmachinery.MachineryDescription;
                machinery.MachineryType = Updatedmachinery.MachineryType;
                machinery.MachineryMaxHoursPerDay = Updatedmachinery.MachineryMaxHoursPerDay;
                machinery.MachineryActualUseTime = Updatedmachinery.MachineryActualUseTime;
                machinery.MaintenanceHours = Updatedmachinery.MaintenanceHours;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Machinery Not Found");
            }
        }
        public int GetNextID()
        {
            var lastID = _dbContext.Machinery.OrderByDescending(m => m.MachineryID).FirstOrDefault();
            if (lastID == null)
            {
                return 1;
            }
            return lastID.MachineryID + 1;
        }
    }
}
