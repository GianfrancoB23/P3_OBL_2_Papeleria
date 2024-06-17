using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.Linea
{
    public class LineaNuloException : Exception
    {
        public LineaNuloException()
        {
        }

        public LineaNuloException(string? message) : base(message)
        {
        }

        public LineaNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LineaNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
