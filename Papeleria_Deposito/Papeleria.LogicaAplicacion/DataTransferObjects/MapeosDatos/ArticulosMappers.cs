using Empresa.LogicaDeNegocio.Sistema;
using Empresa.LogicaDeNegocio.Entidades; 
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos
{
    public class ArticulosMappers
    {   
        public static Articulo FromDto(ArticuloDTO dto)
        {
            if (dto == null) throw new ArticuloNuloException(nameof(dto));
            return new Articulo(dto.CodigoProveedor, dto.NombreArticulo, dto.Descripcion, dto.PrecioVP, dto.Stock);
        }
        public static Articulo FromDtoUpdate(ArticuloDTO dto)
        {
            if (dto == null) throw new ArticuloNuloException(nameof(dto));
            var articulo = new Articulo(dto.CodigoProveedor, dto.NombreArticulo, dto.Descripcion, dto.PrecioVP, dto.Stock);
            articulo.Id = dto.Id;
            return articulo;
        }
        public static ArticuloDTO ToDto(Articulo articulo)
        {
            if (articulo == null) throw new ArticuloNuloException();
            return new ArticuloDTO()
            {
                Id = articulo.Id,
                CodigoProveedor = articulo.CodigoProveedor.codigo,
                NombreArticulo = articulo.NombreArticulo.Nombre,
                Descripcion = articulo.Descripcion.Descripcion,
                PrecioVP = articulo.PrecioVP,
                Stock = articulo.Stock.StockActual()
            };
        }

        public static IEnumerable<ArticuloDTO> FromLista(IEnumerable<Articulo> articulos)
        {
            if (articulos == null)
            {
                throw new ArticuloNuloException("La lista de articulos no puede ser nula");
            }
            return articulos.Select(articulo => ToDto(articulo));
        }
    }
}
