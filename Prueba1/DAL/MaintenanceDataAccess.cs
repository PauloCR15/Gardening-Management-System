using Models;
namespace Prueba1.DAL
{
    public class MaintenanceDataAccess
    {
        private readonly DBContext _dbContext;
        public MaintenanceDataAccess(DBContext context)
        {
            _dbContext = context;
        }
        public List<Maintenance> GetAllMaintenances()
        {
            return _dbContext.Maintenances.ToList();
        }
        public Maintenance? GetMaintenanceById(int id)
        {
            return _dbContext.Maintenances.FirstOrDefault(m => m.MaintenanceID == id);
        }
        public void AddMaintenance(Maintenance maintenance)
        {
            maintenance.MaintenanceID = 0;
            _dbContext.Maintenances.Add(maintenance);
            _dbContext.SaveChanges();
        }
        public void DeleteMaintenance(int id)
        {
            var maintenance = _dbContext.Maintenances.Find(id);
            if (maintenance != null)
            {
                _dbContext.Maintenances.Remove(maintenance);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("No existe un mantenimiento con id" + id);
            }
        }
        public void UpdateMaintenance(int id, Maintenance maintenanceModified)
        {
            var maintenance = _dbContext.Maintenances.Find(id);
            if (maintenance != null)
            {
                _dbContext.Entry(maintenance).CurrentValues.SetValues(maintenanceModified);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Maintenance not found");
            }
        }
        public int GetNextID()
        {
            int id;
            if (_dbContext.Maintenances.Any())
            {
                id = _dbContext.Maintenances.Max(m => m.MaintenanceID) + 1;

            }
            else
            {
                id = 1;
            }
            return id;
        }
    }
}
