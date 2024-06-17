using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.MovimientoStock
{
    public class MovimientoStockNuloException : Exception
    {
        public MovimientoStockNuloException()
        {
        }

        public MovimientoStockNuloException(string? message) : base(message)
        {
        }

        public MovimientoStockNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MovimientoStockNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
