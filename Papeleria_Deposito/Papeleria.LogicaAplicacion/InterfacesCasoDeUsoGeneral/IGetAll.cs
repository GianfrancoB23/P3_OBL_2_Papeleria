using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasoDeUsoGeneral
{
    public interface IGetAll<T>
    {
        public IEnumerable<T> GetAll(IRepositorio<T> repo);
    }
}
