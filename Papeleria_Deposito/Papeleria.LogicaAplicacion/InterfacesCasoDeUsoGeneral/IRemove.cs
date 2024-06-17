using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Interaces
{
    public interface IRemove<T>
    {
        public void Remove(T obj);
    }
}
