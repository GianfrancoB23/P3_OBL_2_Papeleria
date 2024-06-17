using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
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
    public class GetAllArticulos : IGetAllArticulos
    {
        private IRepositorioArticulo _repoArticulos;

        public GetAllArticulos(IRepositorioArticulo repo)
        {
            _repoArticulos = repo;
        }

        public IEnumerable<ArticuloDTO> Ejecutar()
        {
            var articulos = _repoArticulos.GetAll();
            if (articulos == null || articulos.Count() == 0)
            {
                throw new ArticuloNuloException("No se encontraron articulos en el sistema");
            }
            return ArticulosMappers.FromLista(articulos);
        }
    }
}
