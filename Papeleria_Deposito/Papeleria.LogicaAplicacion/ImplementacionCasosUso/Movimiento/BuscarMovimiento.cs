using Papeleria.LogicaAplicacion.InterfacesCasoDeUsoGeneral;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Movimiento
{
    public class BuscarMovimiento : IGet<MovimientoStock>
    {
        public MovimientoStock Get(int id)
        {
            throw new NotImplementedException();
        }

        public MovimientoStock Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovimientoStock> GetAll(IRepositorio<MovimientoStock> repo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovimientoStock> GetMany(string id)
        {
            throw new NotImplementedException();
        }
    }
}
