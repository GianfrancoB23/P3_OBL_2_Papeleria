using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.CodigoProveedor;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papeleria.LogicaNegocio.Entidades.ValueObjects.Articulos
{
    [ComplexType]
    public record CodigoProveedorArticulos : IValidable<CodigoProveedorArticulos>
    {
        public long codigo { get; init; }
        public CodigoProveedorArticulos()
        {
            
        }

        public CodigoProveedorArticulos(long codigo)
        {
            if (codigo == null) {
                throw new CodigoProveedorNuloException("El codigo no puede ser nulo");
            }
            this.codigo = codigo;
            esValido();
        }

        public void esValido()
        {
            if (codigo.ToString().Length != 13) {
                throw new CodigoProveedorNoValidoException("No puede tener un largo distinto de 13 digitos.");
            }
        }
    }

}

