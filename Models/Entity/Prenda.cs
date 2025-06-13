using System.ComponentModel.DataAnnotations;

namespace YAST_CLENAER_WEB.Models.Entity
{
    public class Prenda
    {
        [Key]
        public int IdPrenda { get; set; }
        public string TipoPrenda { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoPrenda { get; set; }

        public ICollection<DetalleOrden> DetallesOrden { get; set; } = new List<DetalleOrden>();

    }
}

