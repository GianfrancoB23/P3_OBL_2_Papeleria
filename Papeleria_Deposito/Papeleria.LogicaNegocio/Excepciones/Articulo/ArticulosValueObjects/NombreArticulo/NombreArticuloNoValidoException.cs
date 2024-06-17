using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.NombreArticulo
{
    public class NombreArticuloNoValidoException : Exception
    {
        public NombreArticuloNoValidoException()
        {
        }

        public NombreArticuloNoValidoException(string? message) : base(message)
        {
        }

        public NombreArticuloNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NombreArticuloNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
