using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos
{
    public class BorrarArticulo : IBorrarArticulo
    {
        private IRepositorioArticulo _repoArticulos;

        public BorrarArticulo(IRepositorioArticulo repo)
        {
            _repoArticulos = repo;
        }
        public void Ejecutar(int id) 
        {
            var articulo = _repoArticulos.GetById(id);
            if(articulo == null)
            {
                throw new ArticuloNuloException("Articulo no puede ser nulo");
            }
            try
            {
                _repoArticulos.Remove(articulo);
            } catch (Exception ex)
            {
                throw new ArticuloNoValidoException(ex.Message);
            }
        }
        public void Ejecutar(Articulo articulo)
        {
            if (articulo == null)
            {
                throw new ArticuloNuloException("Articulo no puede ser nulo");
            }
            try
            {
                _repoArticulos.Remove(articulo);
            }
            catch (Exception ex)
            {
                throw new ArticuloNoValidoException(ex.Message);
            }
        }
    }
}
