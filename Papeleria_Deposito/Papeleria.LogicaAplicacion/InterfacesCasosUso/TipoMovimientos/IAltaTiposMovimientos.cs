using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.TipoMovimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos
{
    public interface IAltaTiposMovimientos
    {
        void Ejecutar(TipoMovimientoDTO dto);
    }
}
