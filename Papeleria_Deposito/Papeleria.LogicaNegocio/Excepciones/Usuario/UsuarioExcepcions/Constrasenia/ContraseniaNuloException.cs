using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Constrasenia
{
    public class ContraseniaNuloException : Exception
    {
        public ContraseniaNuloException()
        {
        }

        public ContraseniaNuloException(string? message) : base(message)
        {
        }

        public ContraseniaNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ContraseniaNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
