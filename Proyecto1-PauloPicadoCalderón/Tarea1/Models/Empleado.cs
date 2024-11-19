using System.ComponentModel.DataAnnotations;

namespace Tarea1.Models
{
    /// <summary>
    /// Represents an employee with ClientID, birthdate, handedness, start date, and salary.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the employee ClientID.
        /// </summary>
        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La cédula es un espacio obligatorio.")]
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the birthdate of the employee.
        /// </summary>
        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "La Fecha de Nacimiento es un espacio obligatorio.")]

        public DateTime EmployeeBirthdate { get; set; }

        /// <summary>
        /// Gets or sets the handedness of the employee.
        /// </summary>
        [Display(Name = "Lateralidad")]
        [Required(ErrorMessage = "La Lateralidad es un espacio obligatorio.")]
        public string EmployeeLaterality { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the start date of the employee.
        /// </summary>
        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "La Fecha de Inicio es un espacio obligatorio.")]
        public DateTime EmployeeStartDate { get; set; }

        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        [Display(Name = "Salario")]
        [Range(1, int.MaxValue, ErrorMessage = "El salario debe ser mayor que 0.")]
        [Required(ErrorMessage = "El salario es un espacio obligatorio.")]
        public double EmployeeSalaryxHour { get; set; }
    }
}
