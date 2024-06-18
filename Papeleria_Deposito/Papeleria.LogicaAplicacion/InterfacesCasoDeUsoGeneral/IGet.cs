using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasoDeUsoGeneral
{
    public interface IGet<T>
    {
        public T Get(int id);
        public T Get(string id);
        public IEnumerable<T> GetMany(string id);
        public IEnumerable<T> GetAll(IRepositorio<T> repo);
    }
}
