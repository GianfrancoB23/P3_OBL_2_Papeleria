using Empresa.LogicaDeNegocio.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class EncargadoDeposito : Usuario
    {
        public EncargadoDeposito()
        {
        }

        public EncargadoDeposito(string email, string nombre, string apellido, string contrasenia) : base(email, nombre, apellido, contrasenia)
        {
        }
        public override void ModificarContraseña(string contrasenia)
        {
            base.ModificarContraseña(contrasenia);
        }
        public override void ModificarDatos(Usuario usu)
        {
            base.ModificarDatos(usu);
        }
    }
}
