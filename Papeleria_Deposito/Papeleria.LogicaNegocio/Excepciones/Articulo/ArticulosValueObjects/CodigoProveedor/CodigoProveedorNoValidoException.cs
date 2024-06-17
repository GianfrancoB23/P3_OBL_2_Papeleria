using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.CodigoProveedor
{
    public class CodigoProveedorNoValidoException : Exception
    {
        public CodigoProveedorNoValidoException()
        {
        }

        public CodigoProveedorNoValidoException(string? message) : base(message)
        {
        }

        public CodigoProveedorNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CodigoProveedorNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
