using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.DescripcionArticulo
{
    public class DescripcionArticuloNoValidoException : Exception
    {
        public DescripcionArticuloNoValidoException()
        {
        }

        public DescripcionArticuloNoValidoException(string? message) : base(message)
        {
        }

        public DescripcionArticuloNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DescripcionArticuloNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
