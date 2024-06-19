using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Movimientos
{
    public interface IBorrarMovimiento
    {
        public void Remove(int id);
        public void Remove(Papeleria.LogicaNegocio.Entidades.MovimientoStock obj);
    }
}
