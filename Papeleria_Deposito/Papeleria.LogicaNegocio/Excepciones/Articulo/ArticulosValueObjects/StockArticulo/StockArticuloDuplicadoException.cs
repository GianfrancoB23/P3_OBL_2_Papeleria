using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.StockArticulo
{
    public class StockArticuloDuplicadoException : Exception
    {
        public StockArticuloDuplicadoException()
        {
        }

        public StockArticuloDuplicadoException(string? message) : base(message)
        {
        }

        public StockArticuloDuplicadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StockArticuloDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
