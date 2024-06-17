using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Articulos;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.Memoria
{
    public class RepositorioArticuloMemoria : IRepositorioArticulo
    {
        public void Add(Articulo obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Articulo> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Articulo> GetAllArticulos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Articulo> GetArticulosOrdenadosAlfabeticamente()
        {
            throw new NotImplementedException();
        }

        public Articulo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Articulo> GetObjectsByID(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Articulo obj)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Articulo obj)
        {
            throw new NotImplementedException();
        }

        public Articulo GetArticuloByCodigo(CodigoProveedorArticulos codigo)
        {
            throw new NotImplementedException();
        }

        public bool ExisteArticuloConNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
