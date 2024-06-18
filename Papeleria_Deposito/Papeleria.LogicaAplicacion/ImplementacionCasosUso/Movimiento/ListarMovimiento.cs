using Papeleria.LogicaAplicacion.Interaces;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Movimiento
{
    public class ListarMovimiento : IListar<MovimientoStock>
    {
        public IEnumerable<MovimientoStock> ListarPorNombre(string name)
        {
            throw new NotImplementedException();
        }

        public List<MovimientoStock> ListarSeleccionPorId(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovimientoStock> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public MovimientoStock ListarUno(int id)
        {
            throw new NotImplementedException();
        }

        public MovimientoStock ListarUnoPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
