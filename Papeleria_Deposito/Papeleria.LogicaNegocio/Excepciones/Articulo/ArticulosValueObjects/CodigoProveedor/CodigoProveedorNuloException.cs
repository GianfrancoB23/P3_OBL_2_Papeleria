using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.CodigoProveedor
{
    public class CodigoProveedorNuloException : Exception
    {
        public CodigoProveedorNuloException()
        {
        }

        public CodigoProveedorNuloException(string? message) : base(message)
        {
        }

        public CodigoProveedorNuloException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CodigoProveedorNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
