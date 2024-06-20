namespace Papeleria.MVC.Models
{
    public class MovimientoConsultaModel
    {
        public int anio { get; set; }
        public List<TipoMovConsultaModel> movimientos { get; set; }
        public int totalCantidadMovida { get; set; }
    }
}
