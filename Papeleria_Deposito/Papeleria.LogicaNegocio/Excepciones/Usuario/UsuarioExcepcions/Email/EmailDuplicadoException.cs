using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Email
{
    public class EmailDuplicadoException : Exception
    {
        public EmailDuplicadoException()
        {
        }

        public EmailDuplicadoException(string? message) : base(message)
        {
        }

        public EmailDuplicadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmailDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
