using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Nombre
{
    public class NombreNuloException : Exception
    {
        public NombreNuloException()
        {
        }

        public NombreNuloException(string? message) : base(message)
        {
        }

        public NombreNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NombreNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
