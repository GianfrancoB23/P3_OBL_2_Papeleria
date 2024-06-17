using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Interaces
{
    public interface IListar<T>
    {
        public IEnumerable<T> ListarTodo();
        public T ListarUno(int id);
        public IEnumerable<T> ListarPorNombre(string name);
        public T ListarUnoPorNombre(string nombre);
        public List<T> ListarSeleccionPorId(List<int> ids);
    }
}