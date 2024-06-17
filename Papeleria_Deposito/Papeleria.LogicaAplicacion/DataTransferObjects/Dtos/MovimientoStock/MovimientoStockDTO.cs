using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock
{
    public class MovimientoStockDTO
    {
        public int ID { get; set; }
        public DateTime FecHorMovRealizado { get; set; }
        public int ArticuloID { get; set; }
        public long CodigoProveedor { get; set; }
        public string NombreArticulo { get; set; }
        public string Descripcion { get; set; }
        public double PrecioVP { get; set; }
        public int TipoMovimientoID { get; set; }
        public string TipoMovimientoNombre { get; set; }
        public int UsuarioID { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasenia { get; set; }
        public int CtdUnidadesXMovimiento { get; set; }
    }
}
