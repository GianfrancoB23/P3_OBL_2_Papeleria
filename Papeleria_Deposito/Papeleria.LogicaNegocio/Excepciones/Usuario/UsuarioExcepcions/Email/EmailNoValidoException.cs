using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Email
{
    public class EmailNoValidoException : Exception
    {
        public EmailNoValidoException()
        {
        }

        public EmailNoValidoException(string? message) : base(message)
        {
        }

        public EmailNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmailNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
