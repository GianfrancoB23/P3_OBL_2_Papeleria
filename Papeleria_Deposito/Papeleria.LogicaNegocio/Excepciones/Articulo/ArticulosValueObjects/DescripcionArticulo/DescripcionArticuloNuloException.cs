using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.DescripcionArticulo
{
    public class DescripcionArticuloNuloException : Exception
    {
        public DescripcionArticuloNuloException()
        {
        }

        public DescripcionArticuloNuloException(string? message) : base(message)
        {
        }

        public DescripcionArticuloNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DescripcionArticuloNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
