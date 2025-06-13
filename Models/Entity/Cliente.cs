using System.ComponentModel.DataAnnotations;

namespace YAST_CLENAER_WEB.Models.Entity
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoCliente { get; set; }

        public ICollection<Orden> Ordenes { get; set; } = new List<Orden>();

    }
}
