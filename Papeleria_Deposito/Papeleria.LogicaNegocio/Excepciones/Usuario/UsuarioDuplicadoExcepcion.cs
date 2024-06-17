using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Usuario
{
    public class UsuarioDuplicadoExcepcion : Exception
    {
        public UsuarioDuplicadoExcepcion()
        {
        }

        public UsuarioDuplicadoExcepcion(string? message) : base(message)
        {
        }

        public UsuarioDuplicadoExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsuarioDuplicadoExcepcion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
