using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.Interaces;
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
    public class ModificarUsuario:IModificarUsuario
    {
        private IRepositorioUsuario _repoUsuarios;

        public ModificarUsuario(IRepositorioUsuario repo)
        {
            _repoUsuarios = repo;
        }

        public void Ejecutar(int id, UsuarioDTO usuarioModificado)
        {
            if (usuarioModificado == null)
                throw new UsuarioNuloExcepcion("Usuario no puede ser nulo.");
            try
            {
                var usuario = UsuariosMappers.FromDtoUpdate(usuarioModificado);
                _repoUsuarios.Update(id, usuario);
            }
            catch (Exception ex)
            {
                throw new UsuarioNoValidoExcepcion(ex.Message);
            }

        }
    }
}
