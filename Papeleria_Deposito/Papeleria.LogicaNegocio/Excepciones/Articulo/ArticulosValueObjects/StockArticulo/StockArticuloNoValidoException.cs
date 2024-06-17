using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.StockArticulo
{
    public class StockArticuloNoValidoException : Exception
    {
        public StockArticuloNoValidoException()
        {
        }

        public StockArticuloNoValidoException(string? message) : base(message)
        {
        }

        public StockArticuloNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StockArticuloNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
