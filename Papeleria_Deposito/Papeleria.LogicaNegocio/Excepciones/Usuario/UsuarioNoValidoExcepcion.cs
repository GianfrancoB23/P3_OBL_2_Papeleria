using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Usuario
{
    public class UsuarioNoValidoExcepcion : Exception
    {
        public UsuarioNoValidoExcepcion()
        {
        }

        public UsuarioNoValidoExcepcion(string? message) : base(message)
        {
        }

        public UsuarioNoValidoExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsuarioNoValidoExcepcion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
