using Models;

namespace Prueba1.DAL
{
    public class EmployeeDataAccess
    {
        private readonly DBContext _dbContext;
        public EmployeeDataAccess(DBContext context)
        {
            _dbContext = context;
        }
        public List<Employee> GetAllClients()
        {
            return _dbContext.Employees.ToList();
        }
        public Employee? GetById(int id)
        {
            return _dbContext.Employees.FirstOrDefault(c => c.EmployeeID == id);

        }
        public void AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
        }
        public void UpdateEmployee(int id, Employee UpdatedEmployee)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee != null)
            {
                employee.EmployeeID = UpdatedEmployee.EmployeeID;
                employee.EmployeeBirthdate = UpdatedEmployee.EmployeeBirthdate;
                employee.EmployeeLaterality = UpdatedEmployee.EmployeeLaterality;
                employee.EmployeeSalaryxHour = UpdatedEmployee.EmployeeSalaryxHour;
                employee.EmployeeStartDate = UpdatedEmployee.EmployeeStartDate;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }

    }
}
