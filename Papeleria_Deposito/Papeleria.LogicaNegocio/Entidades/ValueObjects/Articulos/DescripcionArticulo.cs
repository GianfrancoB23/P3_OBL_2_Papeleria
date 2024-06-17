using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.DescripcionArticulo;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Papeleria.LogicaNegocio.Entidades.ValueObjects.Articulos
{
    [ComplexType]
    public record DescripcionArticulo : IValidable<DescripcionArticulo>
    {
        public string Descripcion { get; init; }
        public DescripcionArticulo()
        {
            
        }

        public DescripcionArticulo(string descripcion)
        {

            Descripcion = descripcion;
            esValido();
        }

        public void esValido()
        {
            if (Descripcion.Length < 5) { 
                throw new DescripcionArticuloNoValidoException("La descripcion no puede ser menor a 5 caracteres.");
            }
        }
    }

}

