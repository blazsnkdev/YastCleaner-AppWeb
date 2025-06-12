namespace YAST_CLENAER_WEB.Models.Entity
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        ICollection<Orden> Ordenes { get; set; } = new List<Orden>();

    }
}
