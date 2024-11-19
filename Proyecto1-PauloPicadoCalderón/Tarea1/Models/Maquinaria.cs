using System.ComponentModel.DataAnnotations;

namespace Tarea1.Models
{
    /// <summary>
    /// Represents a piece of machinery.
    /// </summary>
    public class Machinery
    {
        /// <summary>
        /// Gets or sets the unique identifier of the machinery.
        /// </summary>
        [Display(Name = "Identificador")]
        public required int MachineryID { get; set; }

        /// <summary>
        /// Gets or sets the description of the machinery.
        /// </summary>
        [Required(ErrorMessage = "La descripción es requerida.")]
        [Display(Name = "Descripción")]
        public required string MachineryDescription { get; set; }

        /// <summary>
        /// Gets or sets the type of machinery.
        /// </summary>
        [Required(ErrorMessage = "El tipo es requerido.")]
        [Display(Name = "Tipo")]
        public required string MachineryType { get; set; }

        /// <summary>
        /// Gets or sets the number of hours the machinery has been used.
        /// </summary>
        [Display(Name = "Horas de uso actual")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a 0.")]
        [Required(ErrorMessage = "Las horas de uso actual son requeridas.")]
        public required float MachineryActualUseTime { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of hours the machinery can be used per day.
        /// </summary>
        [Display(Name = "Horas máximas por día")]
        [Range(1, double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a 0.")]
        [Required(ErrorMessage = "Las horas máximas por día son requeridas.")]
        public required float MachineryMaxHoursPerDay { get; set; }

        /// <summary>
        /// Gets or sets the number of hours after which the machinery requires maintenance.
        /// </summary>
        [Display(Name = "Horas de mantenimiento")]
        [Range(1, double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a 0.")]
        [Required(ErrorMessage = "Las horas de mantenimiento son requeridas.")]
        public required float MaintenanceHours { get; set; }
    }
}
