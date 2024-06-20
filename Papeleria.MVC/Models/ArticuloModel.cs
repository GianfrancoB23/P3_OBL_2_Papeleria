namespace Papeleria.MVC.Models
{
    public class ArticuloModel
    {

        public int id { get; set; }
        public long codigoProveedor { get; set; }
        public string nombreArticulo { get; set; }
        public string descripcion { get; set; }
        public double precioVP { get; set; }
    }
}
