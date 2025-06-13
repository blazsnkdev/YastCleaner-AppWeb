using System.ComponentModel.DataAnnotations;

namespace YAST_CLENAER_WEB.Models.ViewModels
{
    public class EstadoOrdenViewModel
    {
        public int IdEstadoOrden { get; set; }
        [Display(Name ="Estado")]
        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Estado no puede exceder los 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo Estado solo puede contener letras y espacios.")]
        public string NombreEstado { get; set; }
    }
}
