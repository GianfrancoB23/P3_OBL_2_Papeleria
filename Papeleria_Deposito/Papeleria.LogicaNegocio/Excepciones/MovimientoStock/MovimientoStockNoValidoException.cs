using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.MovimientoStock
{
    public class MovimientoStockNoValidoException : Exception
    {
        public MovimientoStockNoValidoException()
        {
        }

        public MovimientoStockNoValidoException(string? message) : base(message)
        {
        }

        public MovimientoStockNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MovimientoStockNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
