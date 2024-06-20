namespace Papeleria.MVC.Models
{
    public class MovimientosModel
    {
        public int id { get; set; }
        public DateTime fecHorMovRealizado { get; set; } = DateTime.Now;
        public int articuloID { get; set; }
        public long codigoProveedor { get; set; }
        public string nombreArticulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public double precioVP { get; set; }
        public int tipoMovimientoID { get; set; }
        public string tipoMovimientoNombre { get; set; } = string.Empty;
        public int usuarioID { get; set; }
        public string email { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public string contrasenia { get; set; } = string.Empty;
        public int ctdUnidadesXMovimiento { get; set; }
    }
}
