using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades.ValueObjects;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Clientes;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Usuario;

namespace Papeleria.LogicaNegocio.InterfacesEntidades
{
    public interface IValidable<T> where T : class
    {
        void esValido();

    }

}

