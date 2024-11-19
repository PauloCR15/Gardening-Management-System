using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {
        public  int EmployeeID { get; set; }
        public required DateTime EmployeeBirthdate { get; set; }
        public required string EmployeeLaterality { get; set; }
        public required DateTime EmployeeStartDate { get; set; }
        public decimal EmployeeSalaryxHour { get; set; }
    }
}
