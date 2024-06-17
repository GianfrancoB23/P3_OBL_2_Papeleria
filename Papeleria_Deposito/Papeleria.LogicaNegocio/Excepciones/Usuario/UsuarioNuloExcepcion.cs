using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Usuario
{
    public class UsuarioNuloExcepcion : Exception
    {
        public UsuarioNuloExcepcion()
        {
        }

        public UsuarioNuloExcepcion(string? message) : base(message)
        {
        }

        public UsuarioNuloExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsuarioNuloExcepcion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
