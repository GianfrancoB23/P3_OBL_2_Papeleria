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
    public class BorrarUsuario : IBorrarUsuario
    {
        private IRepositorioUsuario _repoUsuarios;

        public BorrarUsuario(IRepositorioUsuario repo)
        {
            _repoUsuarios = repo;
        }

        public void Ejecutar(int id, UsuarioDTO usuarioBorrar)
        {
            if (usuarioBorrar == null)
                throw new UsuarioNuloExcepcion("Usuario no puede ser nulo.");
            try
            {
                var usuario = _repoUsuarios.GetById(usuarioBorrar.Id);
                _repoUsuarios.Remove(usuario);
            }
            catch (Exception ex)
            {
                throw new UsuarioNoValidoExcepcion(ex.Message);
            }
        }
    }
}
