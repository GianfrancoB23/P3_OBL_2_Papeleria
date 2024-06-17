using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Administrador : Usuario
    {
        public Administrador()
        {
        }

        public Administrador(string email, string nombre, string apellido, string contrasenia) : base(email, nombre, apellido, contrasenia)
        {
            this.Email = new EmailUsuario(email);
            this.NombreCompleto = new NombreCompleto(nombre, apellido);
            this.Contrasenia = new ContraseniaUsuario(contrasenia);
            esValido();
        }

    }
}
