using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.EncargadoDeposito
{
    public class EncargadoNoValidoException : Exception
    {
        public EncargadoNoValidoException()
        {
        }

        public EncargadoNoValidoException(string? message) : base(message)
        {
        }

        public EncargadoNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EncargadoNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
