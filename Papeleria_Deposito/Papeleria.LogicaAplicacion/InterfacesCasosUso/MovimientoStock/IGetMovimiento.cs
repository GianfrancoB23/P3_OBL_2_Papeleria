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
        public MovimientoStock Get(int id);
        public MovimientoStockDTO GetByDTO(int id);
        public MovimientoStock Get(string id);
        public IEnumerable<MovimientoStockDTO> GetAll();
    }
}
