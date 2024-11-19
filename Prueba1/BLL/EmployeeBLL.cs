using Models;
using Prueba1.DAL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba1.BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDataAccess _dataAccess;
        public EmployeeBLL(EmployeeDataAccess employeeDataAccess)
        {
            _dataAccess = employeeDataAccess;
        }
        public List<Employee> GetAllEmployees()
        {

            return _dataAccess.GetAllClients();
        }
        public Employee? GetEmployeeByID(int id)
        {
            return _dataAccess.GetById(id);
        }
        public void Add(Employee employee)
        {
            if (employee == null)
            {
                throw new Exception("El cliente es nulo");
            }
            var existingEmployee = _dataAccess.GetById(employee.EmployeeID);
            if (existingEmployee != null)
            {
                throw new InvalidOperationException("Ya existe un cliente registrado con esa identificación.");
            }
            try
            {
                _dataAccess.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar agregar el empleado.", ex);
            }
        }
        public void Remove(int id)
        {
            try
            {
                _dataAccess.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar eliminar el empleado.", ex);
            }

        }
        public void UpdateClient(int id, Employee employee)
        {
            var exists = _dataAccess.GetById(id);
            if (exists == null)
            {
                throw new InvalidOperationException("No existe un empleado registrado con esa identificación.");
            }
            try
            {
                _dataAccess.UpdateEmployee(id, employee);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar actualizar el empleado", ex);
            }
        }
    }
}
