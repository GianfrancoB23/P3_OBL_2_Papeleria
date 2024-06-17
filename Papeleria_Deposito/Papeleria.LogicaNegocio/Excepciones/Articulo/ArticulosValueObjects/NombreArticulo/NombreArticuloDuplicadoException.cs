using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.NombreArticulo
{
    public class NombreArticuloDuplicadoException : Exception
    {
        public NombreArticuloDuplicadoException()
        {
        }

        public NombreArticuloDuplicadoException(string? message) : base(message)
        {
        }

        public NombreArticuloDuplicadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NombreArticuloDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
