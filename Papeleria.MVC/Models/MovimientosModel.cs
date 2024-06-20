namespace Papeleria.MVC.Models
{
    public class MovimientosModel
    {
        public int Id { get; set; }
        public string FecHorMovRealizado { get; set; } = string.Empty;
        public int ArticuloID { get; set; }
        public string codigoProveedor { get; set; } = string.Empty;
        public string NombreArticulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double PrecioVP { get; set; }
        public int TipoMovimientoID { get; set; }
        public string TipoMovimientoNombre { get; set; } = string.Empty;
        public int UsuarioID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public int CtdUnidadesXMovimiento { get; set; }
    }
}
