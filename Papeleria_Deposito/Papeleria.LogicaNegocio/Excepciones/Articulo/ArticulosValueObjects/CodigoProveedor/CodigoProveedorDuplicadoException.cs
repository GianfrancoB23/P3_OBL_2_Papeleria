using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.CodigoProveedor
{
    public class CodigoProveedorDuplicadoException : Exception
    {
        public CodigoProveedorDuplicadoException()
        {
        }

        public CodigoProveedorDuplicadoException(string? message) : base(message)
        {
        }

        public CodigoProveedorDuplicadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CodigoProveedorDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
