using Models;
using Prueba1.DAL;

namespace Prueba1.BLL
{
    public class MaintenanceBLL
    {
        private readonly MaintenanceDataAccess _dataAccess;

        // Inyección de dependencias
        public MaintenanceBLL(MaintenanceDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<Maintenance> GetAllMaintenances()
        {

            return _dataAccess.GetAllMaintenances();
        }

        public Maintenance? GetMaintenanceById(int id)
        {
            return _dataAccess.GetMaintenanceById(id);
        }

        public void AddMaintenance(Maintenance maintenance)
        {
            if (maintenance == null)
            {
                throw new ArgumentNullException(nameof(maintenance), "El mantenimiento no puede ser nulo.");
            }
            try
            {
                CalculateCost(maintenance);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar calcular el costo del mantenimiento.", ex);
            }
            var today = DateTime.Now.Date;
            var execeutedDate = maintenance.MaintenanceExecutedDate.Date;
            var scheduledDate = maintenance.MaintenanceScheduledDate.Date;

            if (execeutedDate > today)
            {
                throw new ArgumentException("La fecha de siguiente corte no puede ser mayor a el día de hoy");
            }
            if (scheduledDate < today)
            {
                throw new ArgumentException("La fecha programada no puede ser menor  a el día de hoy");
            }
            if (maintenance.PropertyAreaSize <= 0)
            {
                throw new ArgumentException("El área de la propiedad no puede ser cero.");
            }
            if (maintenance.HedgeArea < 0)
            {
                throw new ArgumentException("El área de la cerca viva no puede ser negativa");
            }

            _dataAccess.AddMaintenance(maintenance);
        }
        public void RemoveMaintenance(int id)
        {
            try
            {
                _dataAccess.DeleteMaintenance(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar eliminar el mantenimiento.", ex);
            }
        }

        public void UpdateMaintenance(int id,Maintenance UpdatedMaintenance)
        {
            var exists = _dataAccess.GetMaintenanceById(id);
            if (exists != null) {
                if (UpdatedMaintenance == null)
                {
                    throw new ArgumentNullException(nameof(UpdatedMaintenance), "El mantenimiento no puede ser nulo.");
                }
                try
                {
                    CalculateCost(UpdatedMaintenance);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocurrió un error al intentar calcular el costo del mantenimiento.", ex);
                }

                var existingMaintenance = _dataAccess.GetMaintenanceById(UpdatedMaintenance.MaintenanceID);
                if (existingMaintenance == null)
                {
                    throw new InvalidOperationException("No existe un mantenimiento registrado con ese identificador.");
                }

                try
                {
                    _dataAccess.UpdateMaintenance( id, UpdatedMaintenance);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocurrió un error al intentar actualizar el mantenimiento.", ex);
                }
            }

        }
        public int GetNextId()
        {
            return _dataAccess.GetNextID();
        }
        private void CalculateCost(Maintenance maintenance)
        {
            double propertyArea = maintenance.PropertyAreaSize;
            double hedgeArea = maintenance.HedgeArea;
            double mowingCostPerSquareMeter = maintenance.MowingCostPerSquareMeter;
            double productApplicationCostPerSquareMeter = maintenance.ProductApplicationCostPerSquareMeter;
            double discount = 0;
            if (propertyArea >= 400 && propertyArea <= 900)
            {
                discount = 0.02;
            }
            else if (propertyArea > 900 && propertyArea <= 1500)
            {
                discount = 0.03;
            }
            else if (propertyArea > 1500 && propertyArea <= 2000)
            {
                discount = 0.04;
            }
            else if (propertyArea > 2000)
            {
                discount = 0.05;
            }
            double totalDiscount = (propertyArea * mowingCostPerSquareMeter) * discount;
            double totalCostWithoutVAT = ((propertyArea + hedgeArea) * mowingCostPerSquareMeter) +
        ((propertyArea + hedgeArea) * productApplicationCostPerSquareMeter) - totalDiscount;
            double VAT_RATE = 0.13; // Tasa de IVA
            double vat = totalCostWithoutVAT * VAT_RATE;
            double totalCostWithVAT = totalCostWithoutVAT + vat;
            if (maintenance.TotalCost != totalCostWithVAT)
            {
                maintenance.TotalCost = totalCostWithVAT;
            }
        }
    }
}
