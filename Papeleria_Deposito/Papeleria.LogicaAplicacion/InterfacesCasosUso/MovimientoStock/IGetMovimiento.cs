using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Movimientos
{
    public interface IGetMovimiento
    {
        public Papeleria.LogicaNegocio.Entidades.MovimientoStock Get(int id);
        public MovimientoStockDTO GetByDTO(int id);
        public IEnumerable<MovimientoStockDTO> GetAll();
        public IEnumerable<MovimientoStockDTO> GetMovimientosByIDArticuloYTipoMov(int idArticulo, string tipoMovimiento);
        public IEnumerable<ArticuloDTO> GetArticulosByRangoFecha(DateTime fechaIni, DateTime fechaFin);
        public IEnumerable<object> ObtenerResumenMovimientosPorAnioYTipoMovimiento();
    }
}
