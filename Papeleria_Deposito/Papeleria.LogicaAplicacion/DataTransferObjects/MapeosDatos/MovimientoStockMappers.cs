using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.TipoMovimientos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.MovimientoStock;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos
{
    public class MovimientoStockMappers
    {
        private static PapeleriaContext _context;
        private static IRepositorioMovimientoStock _repoMovStock = new RepositorioMovimientoStockEF();
        private static IRepositorioArticulo _repoArticulos = new RepositorioArticuloEF(_context);
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
            return new MovimientoStock(dto.FecHorMovRealizado, articulo, tipoMovimiento, usuario, dto.CtdUnidadesXMovimiento);
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
            MovimientoStock mov = new MovimientoStock(dto.FecHorMovRealizado, articulo, tipoMovimiento, usuario, dto.CtdUnidadesXMovimiento);
            mov.ID = dto.ID;
            return mov;
        }
        public static MovimientoStockDTO ToDto(MovimientoStock mov)
        {
            if (mov == null) throw new MovimientoStockNuloException("Movimiento de stock nulo"); ;
            ArticuloDTO articulo = ArticulosMappers.ToDto(mov.Articulo);
            UsuarioDTO usuario = UsuariosMappers.ToDto(mov.UsuarioRealizaMovimiento);
            TipoMovimientoDTO tipMov = TipoMovimientoMappers.ToDto(mov.Movimiento);
            return new MovimientoStockDTO()
            {
                ID = mov.ID,
                FecHorMovRealizado = mov.FecHorMovRealizado,
                ArticuloID = articulo.Id,
                CodigoProveedor = articulo.CodigoProveedor,
                NombreArticulo = articulo.NombreArticulo,
                Descripcion = articulo.Descripcion,
                PrecioVP = articulo.PrecioVP,
                TipoMovimientoID = tipMov.ID,
                TipoMovimientoNombre = tipMov.Nombre,
                UsuarioID = usuario.Id,
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Contrasenia = usuario.Contrasenia,
                CtdUnidadesXMovimiento = mov.CtdUnidadesXMovimiento
            };
        }

        public static IEnumerable<MovimientoStockDTO> FromLista(IEnumerable<MovimientoStock> movimientos)
        {
            if (movimientos == null)
            {
                throw new MovimientoStockNuloException("La lista de articulos no puede ser nula");
            }
            return movimientos.Select(mov => ToDto(mov));
        }
    }
}
