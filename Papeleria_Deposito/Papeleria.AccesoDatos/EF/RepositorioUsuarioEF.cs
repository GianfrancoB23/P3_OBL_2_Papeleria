using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Usuario;
using Papeleria.LogicaNegocio.Excepciones.EncargadoDeposito;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Constrasenia;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EF
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        private PapeleriaContext _db;
        public RepositorioUsuarioEF(PapeleriaContext context) { _db = context; }

        public Usuario GetUsuarioPorEmail(string email)
        {
            return _db.Usuarios.FirstOrDefault(u => u.Email.Direccion == email);
        }

        public void ModificarContrasenia(int id, ContraseniaUsuario contraseniaNueva)
        {
            var usuario = _db.Usuarios.FirstOrDefault(u => u.ID == id);

            if (usuario != null)
            {
                try
                {
                    usuario.Contrasenia = new ContraseniaUsuario(contraseniaNueva.Valor);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ContraseniaNoValidoException(ex.Message);
                }
            }
            else
            {
                throw new UsuarioNuloExcepcion("El usuario no existe");
            }
        }

        public Usuario GetById(int id)
        {
            if (id == null)
            { 
                throw new UsuarioNuloExcepcion("La ID a buscar no puede ser nula.");
            }
            Usuario? usuario = _db.Usuarios.FirstOrDefault(usr => usr.ID == id);
            return usuario;
        }

        public void Add(Usuario obj)
        {
            if (obj == null) throw new UsuarioNuloExcepcion("El usuario es nulo");
            try
            {
                _db.Usuarios.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UsuarioNoValidoExcepcion(ex.Message);
            }
        }

        public void Update(int id, Usuario obj)
        {
            var usuario = _db.Usuarios.FirstOrDefault(u => u.ID == id);

            if (usuario != null)
            {
                try
                {
                    usuario.ModificarDatos(obj);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw new UsuarioNoValidoExcepcion(ex.Message);
                }
            }
            else
            {
                throw new UsuarioNuloExcepcion("El usuario no existe");
            }
        }

        public void Remove(int id)
        {
            var usuario = _db.Usuarios.FirstOrDefault(u => u.ID == id);
            if (usuario != null)
            {
                _db.Usuarios.Remove(usuario);
                _db.SaveChanges();
            }
        }

        public void Remove(Usuario obj)
        {
            _db.Usuarios.Remove(obj);
            _db.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _db.Usuarios.ToList();
        }

        public IEnumerable<Usuario> GetObjectsByID(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string contrasenia)
        {
            try
            {
                var usuarios = _db.Usuarios.ToList();
                var usr = _db.Usuarios.AsEnumerable()
                    .Where(u => u.Email.Direccion.Equals(email) && u.Contrasenia.Valor.Equals(contrasenia))
                    .SingleOrDefault();
                if (usr == null)
                {
                    throw new UsuarioNoValidoExcepcion("Usuario o contraseña incorrectos");
                }
                return usr;
            }
            catch (UsuarioNoValidoExcepcion ex)
            {
                throw new UsuarioNoValidoExcepcion(ex.Message);
            }
        }

        public bool ExisteUsuarioConEmail(string email)
        {
            Usuario usuario = GetUsuarioPorEmail(email);
            return usuario != null;
        }

        public EncargadoDeposito GetEncargadoByID(int id)
        {
            if (id == null)
            {
                throw new EncargadoNoValidoException("La ID a buscar no puede ser nula.");
            }
            EncargadoDeposito? usuario = (EncargadoDeposito?)_db.Usuarios.FirstOrDefault(usr => usr.ID == id);
            return usuario;
        }
    }
}
