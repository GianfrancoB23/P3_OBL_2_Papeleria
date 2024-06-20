using Empresa.LogicaDeNegocio.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios
{
    public interface ILogin
    {
        public Usuario Ejecutar(string email, string pwd);
    }
}
