using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using Empresa.LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Email;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos
{
    public class AltaArticulo : IAltaArticulo
    {
        private IRepositorioArticulo _repoArticulos;

        public AltaArticulo(IRepositorioArticulo repo)
        {
            _repoArticulos = repo;
        }

        public void Ejecutar(ArticuloDTO dto)
        {
            if (dto == null)
                throw new ArticuloNuloException("Nulo");

            bool nombreExiste = _repoArticulos.ExisteArticuloConNombre(dto.NombreArticulo);
            if (nombreExiste)
            {
                throw new ArticuloNoValidoException("El nombre del articulo ya está en uso.");
            }
            else
            {
                Articulo articulo = ArticulosMappers.FromDto(dto);
                _repoArticulos.Add(articulo);
            }
        }
    }
}
