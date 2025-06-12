using System.ComponentModel.DataAnnotations;
using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Models.ViewModels
{
    public class TipoServicioViewModel
    {
        public int IdTipoServicio { get; set; }
        [Display(Name ="Nombre del Servicio")]
        [Required(ErrorMessage ="El Nombre del Servicio es necesario")]
        public string NombreServicio { get; set; }


        [Display(Name = "Precio base del servicio")]
        [Required(ErrorMessage = "El Precio es necesario")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser mayor a 0.")]
        public decimal PrecioBase { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La Descripción es necesaria")]
        public string Descripcion { get; set; }


        [Display(Name = "Fecha de registro")]
        [Required(ErrorMessage = "La Fecha de Creación es necesaria")]
        public DateTime FechaCreacion { get; set; }


        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Precio es necesario")]
        public string EstadoServicio { get; set; }


        public List<DetalleOrden> DetallesOrden { get; set; } = new List<DetalleOrden>();
    }
}
