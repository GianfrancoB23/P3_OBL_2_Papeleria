using System.ComponentModel.DataAnnotations;

namespace Papeleria.MVC.Models.PedidosModels
{
    public class PedidoListModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int ClienteId { get; set; }

        public List<LineaPedidoModel> LineasPedido { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaPedido { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }
        public double IVA { get; set; }
        public double PrecioFinal {  get; set; }

    }
}
