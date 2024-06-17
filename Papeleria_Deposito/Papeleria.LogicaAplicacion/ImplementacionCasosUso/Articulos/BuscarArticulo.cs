using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Articulos;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos
{
    public class BuscarArticulo : IGetArticulo
    {

        private IRepositorioArticulo _repoArticulos;

        public BuscarArticulo(IRepositorioArticulo repo)
        {
            _repoArticulos = repo;
        }

        public ArticuloDTO GetByIdDTO(int id)
        {
            var articulo = _repoArticulos.GetById(id);
            if (articulo == null) 
            {
                throw new ArticuloNuloException("Articulo no encontrado con el ID especificado");
            }
            var articuloReturn = ArticulosMappers.ToDto(articulo);
            return articuloReturn;
        }
        public Articulo GetById(int id)
        {
            return _repoArticulos.GetById(id);
        }

        public ArticuloDTO GetArticuloPorCodigo(CodigoProveedorArticulos codigoProveedor)
        {
            var articulo = _repoArticulos.GetArticuloByCodigo(codigoProveedor);
            if(articulo == null)
            {
                throw new ArticuloNuloException("Articulo no encontrado con el codigo especificado");
            }
            var articuloReturn = ArticulosMappers.ToDto(articulo);
            return articuloReturn;
        }

        public IEnumerable<ArticuloDTO> GetArticulosPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
