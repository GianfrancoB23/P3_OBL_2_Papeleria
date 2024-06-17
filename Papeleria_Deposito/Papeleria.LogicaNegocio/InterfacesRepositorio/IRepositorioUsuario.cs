using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Clientes;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {
        public Usuario GetUsuarioPorEmail(string email);
        public void ModificarContrasenia(int id, ContraseniaUsuario contraseniaNueva);
        public Usuario Login(string email, string contrasenia);
        bool ExisteUsuarioConEmail(string email);
    }
}
