using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.Interaces;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Email;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class AltaUsuarios : IAltaUsuario
    {
        private IRepositorioUsuario _repoUsuarios;

        public AltaUsuarios(IRepositorioUsuario repo)
        {
            _repoUsuarios = repo;
        }

        public void Ejecutar(UsuarioDTO dto)
        {
            if (dto == null)
                throw new UsuarioNuloExcepcion("No han llegado datos.");

            bool emailExistente = _repoUsuarios.ExisteUsuarioConEmail(dto.Email);
            if (emailExistente)
            {
                throw new EmailNoValidoException("El email ya está en uso.");
            }
            else
            {
                Usuario usuario = UsuariosMappers.FromDto(dto);
                _repoUsuarios.Add(usuario);
            }
        }
    }
}
