using Prueba1.DAL;
using Models;

namespace Prueba1.BLL
{
    public class MachineryBLL
    {
        private readonly MachineryDataAccess _dataAccess;
        public MachineryBLL(MachineryDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public List<Machinery> GetAllMachinery()
        {
            return _dataAccess.GetMachinery();
        }
        public Machinery? GetMachineryByID(int id)
        {
            return _dataAccess.GetMachineryByID(id);
        }
        public void AddMachinery(Machinery machinery)
        {
            if (machinery == null)
            {
                throw new ArgumentNullException("La maquinaria no es valida.");
            }
            var existingMachinery = _dataAccess.GetMachineryByID(machinery.MachineryID);

            if (existingMachinery != null)
            {
                throw new InvalidOperationException("Ya existe una maquinaria registrado con esa identificación.");
            }
            try
            {
                _dataAccess.AddMachinery(machinery);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar agregar la maquinaria.", ex);
            }
        }
        public void RemoveMachineryByID(int id)
        {
            try
            {
                _dataAccess.DeleteMachinery(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar eliminar la maquinaria.", ex);
            }
        }
        public void UpdateMachinery(int id, Machinery machinery)
        {
            var exists = _dataAccess.GetMachineryByID(machinery.MachineryID);
            if (exists == null)
            {
                throw new InvalidOperationException("No existe una maquinaria registrado con esa identificación.");
            }
            try
            {
                _dataAccess.UpdatMachinery(id, machinery);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar actualizar la maquinaria", ex);
            }
        }
        public int GetNextID()
        {
            return _dataAccess.GetNextID();
        }
    }
}
