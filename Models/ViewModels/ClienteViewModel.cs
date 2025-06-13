using System.ComponentModel.DataAnnotations;
using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ\\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ\\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [Phone(ErrorMessage = "Formato de teléfono no válido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [EmailAddress(ErrorMessage = "Formato de email no válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        public string Direccion { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string EstadoCliente { get; set; }

        public List<Orden> Ordenes { get; set; } = new List<Orden>();
    }
}
