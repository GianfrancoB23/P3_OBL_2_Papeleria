using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.MovimientoStock;
using Papeleria.LogicaNegocio.Excepciones.TipoMovimiento;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos
{
    public class MovimientoStockMappers
    {
        private static IRepositorioArticulo _repoArticulos = new RepositorioArticuloEF();
        private static IGetArticulo _getArticulo;
        private static IRepositorioTipoMovimiento _repoTipoMovimientos = new RepositorioTipoMovimientoEF();
        private static IGetTipoMovimiento _getTipoMovimiento;
        private static IRepositorioUsuario _repoUsuarios = new RepositorioUsuarioEF();
        private static IGetUsuario _getUsuario;
        public static MovimientoStock FromDTO(MovimientoStockDTO dto)
        {
            _getArticulo = new BuscarArticulo(_repoArticulos);
            if (dto == null)
            {
                throw new MovimientoStockNuloException("Movimiento de stock nulo");
            }
            Articulo articulo = _getArticulo.GetById(dto.ArticuloID);
            TipoMovimiento tipoMovimiento = _getTipoMovimiento.GetById(dto.TipoMovimientoID);
            EncargadoDeposito usuario = _getUsuario.GetEncargadoByID(dto.UsuarioID);
            return new MovimientoStock(dto.FecHorMovRealizado,articulo, tipoMovimiento, usuario,dto.CtdUnidadesXMovimiento);
        }
        public static MovimientoStock FromDTOUpdate(MovimientoStockDTO dto)
        {
            _getArticulo = new BuscarArticulo(_repoArticulos);
            _getUsuario = new BuscarUsuario(_repoUsuarios);
            if (dto == null)
            {
                throw new MovimientoStockNuloException("Movimiento de stock nulo");
            }
            Articulo articulo = _getArticulo.GetById(dto.ArticuloID);
            EncargadoDeposito usuario = _getUsuario.GetEncargadoByID(dto.UsuarioID);
            TipoMovimiento tipoMovimiento = _getTipoMovimiento.GetById(dto.TipoMovimientoID);
            MovimientoStock mov = new MovimientoStock(dto.FecHorMovRealizado,articulo, tipoMovimiento, usuario,dto.CtdUnidadesXMovimiento);
            mov.ID = dto.ID;
            return mov;
        }
        public static LineaPedidoDTO ToDto(LineaPedido linea)
        {
            if (linea == null) throw new PedidoNuloException();
            ArticuloDTO articulo = ArticulosMappers.ToDto(linea.Articulo);
            return new LineaPedidoDTO()
            {
                id = linea.Id,
                PedidoID = linea.pedido.Id,
                idArticulo = articulo.Id,
                CodigoProveedor = articulo.CodigoProveedor,
                NombreArticulo = articulo.NombreArticulo,
                Descripcion = articulo.Descripcion,
                PrecioVP = articulo.PrecioVP,
                Stock = articulo.Stock,
                Cantidad = linea.Cantidad,
                PrecioUnitario = articulo.PrecioVP,
                Subtotal = articulo.PrecioVP * linea.Cantidad
            };
        }

        public static IEnumerable<LineaPedidoDTO> FromLista(IEnumerable<LineaPedido> lineas)
        {
            if (lineas == null)
            {
                throw new PedidoNuloException("La lista de articulos no puede ser nula");
            }
            return lineas.Select(linea => ToDto(linea));
        }
    }
}
