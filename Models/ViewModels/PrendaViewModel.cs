using System.ComponentModel.DataAnnotations;

namespace YAST_CLENAER_WEB.Models.ViewModels
{
    public class PrendaViewModel
    {
        
        public int IdPrenda { get; set; }
        [Display(Name ="Tipo de Prenda")]
        [MaxLength(50, ErrorMessage ="No superar los 50 caracteres")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ\\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]
        public string TipoPrenda { get; set; }
        [Display(Name = "Descripción")]
        [MaxLength(200, ErrorMessage = "No superar los 100 caracteres")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ\\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]
        public string Descripcion { get; set; }
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estado de la Prenda")]
        public string EstadoPrenda { get; set; }
    }
}
