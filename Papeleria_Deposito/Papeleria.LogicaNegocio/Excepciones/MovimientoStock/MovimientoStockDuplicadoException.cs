using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.MovimientoStock
{
    public class MovimientoStockDuplicadoException : Exception
    {
        public MovimientoStockDuplicadoException()
        {
        }

        public MovimientoStockDuplicadoException(string? message) : base(message)
        {
        }

        public MovimientoStockDuplicadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MovimientoStockDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
