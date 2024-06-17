using Papeleria.LogicaNegocio.Entidades.ValueObjects.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public long CodigoProveedor { get; set; }
        public string NombreArticulo { get; set; }
        public string Descripcion { get; set; }
        public double PrecioVP { get; set; }
        public int Stock { get; set; }
    }
}
