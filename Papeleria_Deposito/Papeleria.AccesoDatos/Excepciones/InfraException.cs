using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.Excepciones
{
    public class InfraException : RepositorioException
    {
        public InfraException() { }
        public InfraException(string message) : base(message) { }
    }
}

