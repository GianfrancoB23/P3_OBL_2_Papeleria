using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.DescripcionArticulo
{
    public class DescripcionArticuloDuplicadoException : Exception
    {
        public DescripcionArticuloDuplicadoException()
        {
        }

        public DescripcionArticuloDuplicadoException(string? message) : base(message)
        {
        }

        public DescripcionArticuloDuplicadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DescripcionArticuloDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
