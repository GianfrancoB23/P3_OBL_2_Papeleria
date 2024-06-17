using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Administrador
{
    public class AdminstradorNoValidoException : Exception
    {
        public AdminstradorNoValidoException()
        {
        }

        public AdminstradorNoValidoException(string? message) : base(message)
        {
        }

        public AdminstradorNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AdminstradorNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
