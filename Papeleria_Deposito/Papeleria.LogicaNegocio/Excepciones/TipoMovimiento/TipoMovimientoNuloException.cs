using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.TipoMovimiento
{
    public class TipoMovimientoNuloException : Exception
    {
        public TipoMovimientoNuloException()
        {
        }

        public TipoMovimientoNuloException(string? message) : base(message)
        {
        }

        public TipoMovimientoNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TipoMovimientoNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
