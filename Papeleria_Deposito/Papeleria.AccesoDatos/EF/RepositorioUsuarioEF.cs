using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Clientes;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Usuario;
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
        public RepositorioUsuarioEF()
        {
            _db = new PapeleriaContext();
        }

        public Usuario GetUsuarioPorEmail(string email)
        {
            return _db.Usuarios.FirstOrDefault(u => u.Email.Direccion == email);
        }

        public void ModificarContrasenia(int id, ContraseniaUsuario contraseniaNueva)
        {
            var usuario = _db.Usuarios.FirstOrDefault(u => u.Id == id);

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
            Usuario? usuario = _db.Usuarios.FirstOrDefault(usr => usr.Id == id);
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
            var usuario = _db.Usuarios.FirstOrDefault(u => u.Id == id);

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
            var usuario = _db.Usuarios.FirstOrDefault(u => u.Id == id);
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
                Usuario usu = GetUsuarioPorEmail(email);
                if (usu != null)
                {
                    if (usu.Email.Direccion == email && usu.Contrasenia.Valor == contrasenia)
                    {
                        return usu;
                    }
                }
                return null;

            }
            catch (UsuarioNoValidoExcepcion ex)
            {
                throw new UsuarioNoValidoExcepcion("");
            }
        }

        public bool ExisteUsuarioConEmail(string email)
        {
            Usuario usuario = GetUsuarioPorEmail(email);
            return usuario != null;
        }
    }
}
