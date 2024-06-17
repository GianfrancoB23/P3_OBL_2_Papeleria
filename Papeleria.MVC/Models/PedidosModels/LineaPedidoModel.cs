using System.ComponentModel.DataAnnotations;

namespace Papeleria.MVC.Models.PedidosModels
{
    public class LineaPedidoModel
    {
        [Required(ErrorMessage = "El artículo es obligatorio")]
        public int ArticuloId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero")]
        public int Cantidad { get; set; }
    }
}
