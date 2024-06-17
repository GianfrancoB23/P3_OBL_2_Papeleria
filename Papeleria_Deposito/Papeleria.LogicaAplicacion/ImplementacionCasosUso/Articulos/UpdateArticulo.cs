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
    public class UpdateArticulo : IUpdateArticulo
    {

        private IRepositorioArticulo _repoArticulos;

        public UpdateArticulo(IRepositorioArticulo repo)
        {
            _repoArticulos = repo;
        }

        public void Ejecutar(int id, ArticuloDTO articuloMod)
        {
            if (articuloMod == null) { throw new ArticuloNuloException("Articulo modificado no puede ser nulo"); }
            try
            {
                var articulo = ArticulosMappers.FromDtoUpdate(articuloMod);
                _repoArticulos.Update(id, articulo);
            }
            catch (Exception ex) { throw new ArticuloNoValidoException(ex.Message); }
        }
    }
}
