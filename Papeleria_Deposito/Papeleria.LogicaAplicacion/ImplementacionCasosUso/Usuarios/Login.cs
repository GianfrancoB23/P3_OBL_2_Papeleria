using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class Login : ILogin
    {
        private IRepositorioUsuario _repoUsr;
        public Login(IRepositorioUsuario repoUsr)
        {
            _repoUsr = repoUsr;
        }
        public string Ejecutar(string email, string pwd)
        {
            var usr = _repoUsr.Login(email, pwd);
            if (usr == null)
                return string.Empty;
            return usr.GetType().Name;
        }
    }
}
