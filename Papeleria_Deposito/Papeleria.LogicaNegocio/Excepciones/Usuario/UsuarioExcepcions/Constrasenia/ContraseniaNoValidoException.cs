using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Constrasenia
{
    public class ContraseniaNoValidoException : Exception
    {
        public ContraseniaNoValidoException()
        {
        }

        public ContraseniaNoValidoException(string? message) : base(message)
        {
        }

        public ContraseniaNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ContraseniaNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
