using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo
{
    public class ArticuloNuloException : Exception
    {
        public ArticuloNuloException()
        {
        }

        public ArticuloNuloException(string? message) : base(message)
        {
        }

        public ArticuloNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ArticuloNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
