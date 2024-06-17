using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Clientes;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Usuario;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.Memoria
{
    public class RepositorioUsuarioMemoria : IRepositorioUsuario
    {
        private List<Usuario> _usuarios=new List<Usuario>();
        public void Add(Usuario obj)
        {
            if (obj == null) {
                throw new UsuarioNuloExcepcion("El usuario no puede ser nulo.");
            }
            _usuarios.Add(obj);
        }

        public bool ExisteUsuarioConEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetObjectsByID(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioPorEmail(EmailUsuario email)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string contrasenia)
        {
            throw new NotImplementedException();
        }

        public void ModificarContrasenia(int id, ContraseniaUsuario contraseniaNueva)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
