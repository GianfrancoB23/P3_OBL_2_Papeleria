namespace Papeleria.MVC.Models
{
    public class ArticuloModel
    {

        public int Id { get; set; }
        public long CodigoProveedor { get; set; }
        public string NombreArticulo { get; set; }
        public string Descripcion { get; set; }
        public double PrecioVP { get; set; }
        public int Stock { get; set; }
    }
}
