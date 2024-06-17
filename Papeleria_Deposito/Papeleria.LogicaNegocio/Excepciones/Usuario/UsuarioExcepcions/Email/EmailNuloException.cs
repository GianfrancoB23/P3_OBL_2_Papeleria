using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Email
{
    public class EmailNuloException : Exception
    {
        public EmailNuloException()
        {
        }

        public EmailNuloException(string? message) : base(message)
        {
        }

        public EmailNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmailNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
