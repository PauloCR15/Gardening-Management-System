using System.ComponentModel.DataAnnotations;

namespace Tarea1.Models
{
    /// <summary>
    /// Represents a client with personal and maintenance preference information.
    /// </summary>
    public class Client
    {

        /// <summary>
        /// Gets or sets the unique identifier for the client.
        /// </summary>
        /// 
        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La cédula es un espacio obligatorio.")]
        public int ClientID { get; set; }

        /// <summary>
        /// Gets or sets the full name of the client.
        /// </summary>
        /// 
        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El nombre completo es requerido")]
        public required string ClientFullName { get; set; }

        /// <summary>
        /// Gets or sets the province where the client resides.
        /// </summary>
        /// 
        [Required(ErrorMessage = "La provincia es requerida")]
        [Display(Name = "Provincia")]
        public required string Province { get; set; }

        /// <summary>
        /// Gets or sets the canton where the client resides.
        /// </summary>
        /// 
        [Required(ErrorMessage = "El cantón es requerido")]
        [Display(Name = "Cantón")]
        public required string Canton { get; set; }

        /// <summary>
        /// Gets or sets the district where the client resides.
        /// </summary>
        /// 
        [Required(ErrorMessage = "El distrito es requerido")]
        [Display(Name = "Distrito")]
        public required string District { get; set; }

        /// <summary>
        /// Gets or sets the address of the client.
        /// </summary>
        /// 
        [Required(ErrorMessage = "La dirección exacta es requerida")]
        [Display(Name = "Dirección exacta")]
        public required string ClientFullDirection { get; set; }

        /// <summary>
        /// Gets or sets the maintenance preference of the client for summer.
        /// </summary>
        /// 
        [Required(ErrorMessage = "La preferencia de mantenimiento es requerida")]
        [Display(Name = "Preferencia de Mantenimiento Verano")]
        public required string SummerMowingPreferenceName { get; set; }
        public int SummerMowingPreferenceID { get; set; }
        public int WinterMowingPreferenceID { get; set; }
        /// <summary>
        /// Gets or sets the maintenance preference of the client for winter.
        /// </summary>
        /// 
        [Required(ErrorMessage = "La preferencia de mantenimiento es requerida")]
        [Display(Name = "Preferencia de Mantenimiento Invierno")]
        public required string WinterMowingPrecerenceName { get; set; }


    }
}
