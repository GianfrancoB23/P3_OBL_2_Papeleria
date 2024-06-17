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
    public class BuscarUsuario : IGetUsuario
    {
        private IRepositorioUsuario _repoUsuarios;

        public BuscarUsuario(IRepositorioUsuario repo)
        {
            _repoUsuarios = repo;
        }
        public UsuarioDTO GetByIdDTO(int id)
        {
            var usu = _repoUsuarios.GetById(id);
            if (usu == null)
            {
                throw new UsuarioNuloExcepcion("No hay usuario con ese id");
            }
            var usuDto = UsuariosMappers.ToDto(usu);
            return usuDto;
        }
        public Usuario GetById(int id)
        {
            return _repoUsuarios.GetById(id);
        }
    }
        

}

