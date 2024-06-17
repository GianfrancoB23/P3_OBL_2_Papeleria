using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.NombreArticulo
{
    public class NombreArticuloNuloException : Exception
    {
        public NombreArticuloNuloException()
        {
        }

        public NombreArticuloNuloException(string? message) : base(message)
        {
        }

        public NombreArticuloNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NombreArticuloNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
