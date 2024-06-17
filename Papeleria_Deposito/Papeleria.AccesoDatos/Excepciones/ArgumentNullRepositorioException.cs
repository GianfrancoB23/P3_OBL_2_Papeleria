using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.Excepciones
{
    public class ArgumentNullRepositorioException : RepositorioException
    {
        public ArgumentNullRepositorioException() { }
        public ArgumentNullRepositorioException(string message) : base(message) { }
    }
}
