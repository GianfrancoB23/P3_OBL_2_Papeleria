using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorio<T>
    {
        public T GetById(int id);
        public void Add(T obj);
        public void Update(int id, T obj);
        public void Remove(int id);
        public void Remove(T obj);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetObjectsByID(List<int> ids);
    }
}
