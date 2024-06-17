using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.TipoMovimiento
{
    public class TipoMovimientoDuplicadoException : Exception
    {
        public TipoMovimientoDuplicadoException()
        {
        }

        public TipoMovimientoDuplicadoException(string? message) : base(message)
        {
        }

        public TipoMovimientoDuplicadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TipoMovimientoDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
