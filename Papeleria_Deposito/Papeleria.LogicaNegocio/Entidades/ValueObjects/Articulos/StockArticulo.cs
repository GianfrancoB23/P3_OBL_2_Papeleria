using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.StockArticulo;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papeleria.LogicaNegocio.Entidades.ValueObjects.Articulos
{
    [ComplexType]
    public record StockArticulo:IValidable<StockArticulo>
    {
        public int cantidad { get; set; }

        public StockArticulo(int cantidad)
        {
            this.cantidad = cantidad;
            esValido();
        }

        public StockArticulo()
        {

        }
        public int StockActual()
        {
            return cantidad;
        }

        public void RestarStock(int ctd)
        {
            if (ctd > cantidad)
            {
                throw new StockArticuloNoValidoException("La cantidad a restar no puede ser mayor al stock actual.");
            }
            else if (ctd < 1)
            {
                throw new StockArticuloNoValidoException("La cantidad a restar no puede ser menor a 1.");
            }
            else if (ctd == null)
            {
                throw new StockArticuloNuloException("El stock a restar no puede ser nulo");
            }
            else
            {
                cantidad -= ctd;
            }
        }

        public void SumarStock(int ctd)
        {
            if (ctd < 1)
            {
                throw new StockArticuloNoValidoException("La cantidad a sumar no puede ser menor a 1.");
            }
            else if (ctd == null)
            {
                throw new StockArticuloNuloException("El stock a sumar no puede ser nulo");
            }
            else { 
                cantidad += ctd;
            }
        }

        public void esValido()
        {
            if (cantidad < 0) {
                throw new StockArticuloNoValidoException("El stock no puede ser menor a 0");
            }
        }
    }

}

