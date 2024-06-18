using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.MovimientoStock
{
    public interface IAltaMovimiento
    {
        public void Crear(MovimientoStockDTO obj);
    }
}
