using Papeleria.LogicaNegocio.Entidades.ValueObjects.Articulos;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Pedidos;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.CodigoProveedor;
using Papeleria.LogicaNegocio.Excepciones.Articulo.ArticulosValueObjects.DescripcionArticulo;
using Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Nombre;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System.Collections.Generic;
using System.Timers;

namespace Empresa.LogicaDeNegocio.Entidades
{
    public class Articulo : IValidable<Articulo>, IEquatable<Articulo>, IEntity
	{
        public int Id { get; set; }
		public NombreArticulo NombreArticulo{ get; set; }
        public CodigoProveedorArticulos CodigoProveedor{ get; set; }
		public DescripcionArticulo Descripcion{ get; set; }
		public double PrecioVP{ get; set; }
		public StockArticulo Stock{ get; set; }

        public Articulo(long codigoProveedor, string nombre, string descripcion, double precioVP, int stock)
        {
            this.CodigoProveedor = new CodigoProveedorArticulos(codigoProveedor);
            this.NombreArticulo = new NombreArticulo(nombre);
            this.Descripcion = new DescripcionArticulo(descripcion);
            this.PrecioVP = precioVP;
            this.Stock = new StockArticulo(stock);
            esValido();
        }

        public Articulo()
        {
            
        }

        public bool Equals(Articulo? other)
        {
            if (other == null) return false;
            return this.NombreArticulo == other.NombreArticulo;
        }

        public void esValido()
        {
            if (CodigoProveedor==null) {
                throw new CodigoProveedorNuloException("El codigo de proveedor no puede ser nulo.");
            }
            if (NombreArticulo==null) {
                throw new NombreNuloException("El nombre del articulo no puede ser nulo.");
            }
            if (Descripcion==null) { 
                throw new DescripcionArticuloNuloException("La descripcion no puede ser nula.");
            }
        }
        public void CambiarPrecioVP(int nuevoPrecio){
            PrecioVP = nuevoPrecio;
        }

        public void ModificarDatos(Articulo obj)
        {
            this.CodigoProveedor = obj.CodigoProveedor;
            this.NombreArticulo = obj.NombreArticulo;
            this.Descripcion = obj.Descripcion;
            this.PrecioVP = obj.PrecioVP;
            this.Stock = obj.Stock;
        }
    }
}

