using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea1.Models
{
    /// <summary>
    /// Represents a maintenance record.
    /// </summary>
    public class Maintenance
    {
        /// <summary>
        /// Gets or sets the ClientID of the maintenance.
        /// </summary>
        [Required(ErrorMessage = "El campo ClientID es obligatorio.")]
        [Display(Name = "ClientID de mantenimiento")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaintenanceID { get; set; }

        /// <summary>
        /// Gets or sets the ClientID of the client.
        /// </summary>
        [Required(ErrorMessage = "El campo ClientID del Cliente es obligatorio.")]
        [Display(Name = "Cédula")]
        public int ClientID { get; set; }

        /// <summary>
        /// Gets or sets the date when the maintenance was executed.
        /// </summary>
        [Required(ErrorMessage = "El campo Fecha de Ejecución es obligatorio.")]
        [Display(Name = "Fecha de Ejecución")]
        public DateTime MaintenanceExecutedDate { get; set; }

        /// <summary>
        /// Gets or sets the scheduled date for the maintenance.
        /// </summary>
        [Required(ErrorMessage = "El campo Fecha Programada es obligatorio.")]
        DateTime today = DateTime.Today;
        [Display(Name = "Fecha Programada")]
        public DateTime MaintenanceScheduledDate { get; set; }

        /// <summary>
        /// Gets or sets the date of the next mowing.
        /// </summary>
        [Required(ErrorMessage = "El campo Fecha del Próximo Corte es obligatorio.")]
        [Display(Name = "Fecha del Próximo Corte")]
        public DateTime NextMowingDate { get; set; }

        /// <summary>
        /// Gets or sets the area of the property in square meters.
        /// </summary>
        [Required(ErrorMessage = "El campo Área de la Propiedad es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El área de la propiedad debe ser al menos 1 metro cuadrado.")]
        [Display(Name = "Área de la Propiedad (m2)")]
        public double PropertyAreaSize { get; set; }

        /// <summary>
        /// Gets or sets the area of the hedge in square meters.
        /// </summary>
        [Required(ErrorMessage = "El campo Área de Cerca Viva es obligatorio.")]
        [Display(Name = "Área de Cerca Viva (m2)")]
        public double HedgeArea { get; set; }

        /// <summary>
        /// Gets or sets the number of days without mowing.
        /// </summary>
        [Required(ErrorMessage = "El campo Días sin Cortar es obligatorio.")]
        [Display(Name = "Días sin Cortar")]
        public int DaysWithoutMowing { get; set; }

        /// <summary>
        /// Gets or sets the mowing preference (ID).
        /// </summary>
        [Required(ErrorMessage = "El campo Preferencia de Corte es obligatorio.")]
        [Display(Name = "Preferencia de Corte")]
        public int MowingPreferenceID { get; set; }

        /// <summary>
        /// Gets or sets the mowing preference description.
        /// </summary>
        /// 
        [Required(ErrorMessage = "El campo de Preferencia de Corte es obligatorio.")]
        [Display(Name = "Preferencia de Corte")]
        public string MowingPreferenceDescription => MowingPreferenceID switch
        {
            1 => "Quincenal",
            2 => "Mensual",
            _ => "No especificado"
        };

        /// <summary>
        /// Gets or sets the type of grass.
        /// </summary>
        [Required(ErrorMessage = "El campo Tipo de Césped es obligatorio.")]
        [Display(Name = "Tipo de Césped")]
        public required String GrassType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether products have been applied.
        /// </summary>
        [Required(ErrorMessage = "El campo Productos Aplicados es obligatorio.")]
        [Display(Name = "Productos Aplicados")]
        public bool HasAppliedProducts { get; set; }

        /// <summary>
        /// Gets or sets the applied products.
        /// </summary>
        [Required(ErrorMessage = "El campo Productos Aplicados es obligatorio.")]
        [Display(Name = "Productos Aplicados")]
        public string? AppliedProductName { get; set; }

        /// <summary>
        /// Gets or sets the cost of mowing per square meter.
        /// </summary>
        [Required(ErrorMessage = "El campo Costo de Corte por Metro Cuadrado es obligatorio.")]
        [Display(Name = "Costo de Corte (m2)")]
        public double MowingCostPerSquareMeter { get; set; }

        /// <summary>
        /// Gets or sets the cost of product application per square meter.
        /// </summary>
        [Required(ErrorMessage = "El campo Costo de Aplicación de Productos por Metro Cuadrado es obligatorio.")]
        [Display(Name = "Costo de Aplicación de Productos (m2)")]
        public double ProductApplicationCostPerSquareMeter { get; set; }

        /// <summary>
        /// Gets or sets the total cost of the maintenance.
        /// </summary>
        [Required(ErrorMessage = "El campo Costo Total es obligatorio.")]
        [Display(Name = "Costo Total")]
        public double TotalCost { get; set; }

        /// <summary>
        /// Gets or sets the status of the maintenance.
        /// </summary>
        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        [Display(Name = "Estado")]
        public int MaintenanceStatus { get; set; }
        public string MaintenanceStatusDescription { get; set; }
    }
}
