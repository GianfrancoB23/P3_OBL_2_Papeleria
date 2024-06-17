using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.Entidades;
using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos
{
    public class UsuariosMappers
    {
        public static Usuario FromDto(UsuarioDTO dto)
        {
            if (dto == null) throw new UsuarioNuloExcepcion(nameof(dto));
            if (dto.Admin == 1)
            {
                return new Administrador(dto.Email, dto.Nombre, dto.Apellido, dto.Contrasenia);

            }
            else
            {
                return new EncargadoDeposito(dto.Email, dto.Nombre, dto.Apellido, dto.Contrasenia);
            }
        }
        public static Usuario FromDtoUpdate(UsuarioDTO dto)
        {
            if (dto == null) throw new UsuarioNuloExcepcion(nameof(dto));
            if (dto.Admin == 1)
            {
                var usuario = new Administrador(dto.Email, dto.Nombre, dto.Apellido, dto.Contrasenia);
                usuario.ID = dto.Id;
                return usuario;
            }
            else
            {
                var usuario = new EncargadoDeposito(dto.Email, dto.Nombre, dto.Apellido, dto.Contrasenia);
                usuario.ID = dto.Id;
                return usuario;
            }
        }
        public static UsuarioDTO ToDto(Usuario usuario)
        {
            if (usuario == null) throw new UsuarioNuloExcepcion();
            if(usuario.GetType() == typeof(Administrador))
            {
                return new UsuarioDTO()
                {
                    Id = usuario.ID,
                    Admin = 1,
                    Email = usuario.Email.Direccion,
                    Nombre = usuario.NombreCompleto.Nombre,
                    Apellido = usuario.NombreCompleto.Apellido,
                    Contrasenia = usuario.Contrasenia.Valor
                };
            }
            else 
            {
                return new UsuarioDTO()
                {
                    Id = usuario.ID,
                    Admin = 0,
                    Email = usuario.Email.Direccion,
                    Nombre = usuario.NombreCompleto.Nombre,
                    Apellido = usuario.NombreCompleto.Apellido,
                    Contrasenia = usuario.Contrasenia.Valor
                };
            }
        }

        public static IEnumerable<UsuarioDTO> FromLista(IEnumerable<Usuario> usuarios)
        {
            if (usuarios == null)
            {
                throw new UsuarioNuloExcepcion("La lista de usuarios no puede ser nula");
            }
            return usuarios.Select(usuario => ToDto(usuario));
        }
        //https://vimeopro.com/universidadortfi/fi-5212-programacion-3-cabella-69235-p3-m3a-remoto/video/929607409
        //1:36:07

    }
}
