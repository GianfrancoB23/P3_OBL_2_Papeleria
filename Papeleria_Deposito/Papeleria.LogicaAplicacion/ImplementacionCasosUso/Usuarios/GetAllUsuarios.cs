using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class GetAllUsuarios : IGetAllUsuarios
    {
        private IRepositorioUsuario _repositorioUsuarios;
        public GetAllUsuarios(IRepositorioUsuario repo)
        {
            _repositorioUsuarios = repo;
        }
        public IEnumerable<UsuarioDTO> Ejecutar()
        {
            var usuariosOrigen = _repositorioUsuarios.GetAll();
            if (usuariosOrigen == null || usuariosOrigen.Count() == 0)
            {
                throw new UsuarioNuloExcepcion("No hay autores registrados");
            }
            return UsuariosMappers.FromLista(usuariosOrigen);
        }
    }
}
