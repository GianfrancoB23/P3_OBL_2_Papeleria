using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.StockArticulo
{
    public class StockArticuloNuloException : Exception
    {
        public StockArticuloNuloException()
        {
        }

        public StockArticuloNuloException(string? message) : base(message)
        {
        }

        public StockArticuloNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StockArticuloNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
