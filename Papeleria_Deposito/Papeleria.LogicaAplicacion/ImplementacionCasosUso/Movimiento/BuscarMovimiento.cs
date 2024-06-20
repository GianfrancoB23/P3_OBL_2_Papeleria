using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.InterfacesCasoDeUsoGeneral;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Movimientos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.MovimientoStock;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Movimiento
{
    public class BuscarMovimiento : IGetMovimiento
    {

        private IRepositorioMovimientoStock _repoMov;
        private IRepositorioArticulo _repoArt;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioTipoMovimiento _repoTipoMovimiento;
        public BuscarMovimiento(IRepositorioMovimientoStock repo, IRepositorioArticulo repoArt, IRepositorioUsuario repoUsuario, IRepositorioTipoMovimiento repoTipoMovimiento)
        {
            _repoMov = repo; _repoArt = repoArt;
            _repoUsuario = repoUsuario;
            _repoTipoMovimiento = repoTipoMovimiento;
        }
        public MovimientoStock Get(int id)
        {
            return _repoMov.GetById(id);
        }

        public IEnumerable<MovimientoStockDTO> GetAll()
        {
            var movimientos = _repoMov.GetAll();
            if (movimientos == null || movimientos.Count() == 0)
            {
                throw new MovimientoStockNuloException("No hay movimientos registrados");
            }
            return MovimientoStockMappers.FromLista(movimientos);
        }

        public IEnumerable<ArticuloDTO> GetArticulosByRangoFecha(DateTime fechaIni, DateTime fechaFin)
        {
            IEnumerable<Articulo> articulos = _repoMov.GetByRangoFechas(fechaIni,fechaFin);
            if (articulos.Count()==0)
            {
                throw new ArticuloNuloException("No se ha encontrado articulos que hayan tenido movimiento en ese rango de fechas."); // Handler de exception
            }
            var ret = ArticulosMappers.FromLista(articulos);
            return ret;
        }

        public MovimientoStockDTO GetByDTO(int id)
        {
            var movimiento = _repoMov.GetById(id);
            if (movimiento == null)
            {
                throw new MovimientoStockNuloException("Movimiento no encontrado con el ID especificado"); // Handler de exception
            }
            var ret = MovimientoStockMappers.ToDto(movimiento);
            return ret;
        }

        public IEnumerable<MovimientoStockDTO> GetMovimientosByIDArticuloYTipoMov(int idArticulo, string tipoMovimiento)
        {
            var movimientos = _repoMov.GetAllByIDArticulo_y_TipoMovimiento(idArticulo, tipoMovimiento);
            if (movimientos == null)
            {
                throw new MovimientoStockNuloException("No se ha encontrado movimientos con el ID de articulo y tipo de movimiento ingresado."); // Handler de exception
            }
            var ret = MovimientoStockMappers.FromLista(movimientos);
            return ret;
        }
    }
}
