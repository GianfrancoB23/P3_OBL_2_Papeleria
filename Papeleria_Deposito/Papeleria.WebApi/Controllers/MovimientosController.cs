using Empresa.LogicaDeNegocio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Movimiento;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Movimientos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.MovimientoStock;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private PapeleriaContext _context;
        private IRepositorioArticulo _repoArt;
        private IRepositorioUsuario _repoUsr;
        private IRepositorioMovimientoStock _repo;
        private IGetAllArticulos _cuGetArticulos;
        private IGetArticulo _cuGetArticulo;
        private IAltaArticulo _cuAltaArticulo;
        private IBorrarArticulo _cuBorrarArticulo;
        private IUpdateArticulo _cuModificarArticulo;
        private IGetMovimiento _cuGetMovimiento;
        private IAltaMovimiento _cuAltaMovimiento;

        public MovimientosController(IRepositorioArticulo repoArt,IRepositorioUsuario repoUsr, IRepositorioMovimientoStock repo, IAltaArticulo cuAltaArticulo, IGetAllArticulos cuGetArticulos,
            IGetArticulo cuGetArticulo, IBorrarArticulo cuBorrarArticulo, IUpdateArticulo cuModificarArticulo, IAltaMovimiento altaMovimiento, IGetMovimiento getMovimiento)
        {
            _repoArt = repoArt;
            _repoUsr = repoUsr;
            _repo = repo;
            _cuGetArticulos = cuGetArticulos;
            _cuGetArticulo = cuGetArticulo;
            _cuAltaArticulo = cuAltaArticulo;
            _cuBorrarArticulo = cuBorrarArticulo;
            _cuModificarArticulo = cuModificarArticulo; 
            _cuAltaMovimiento = altaMovimiento;
            _cuGetMovimiento = getMovimiento;
        }
        // GET: api/<Movimientos>
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<MovimientoStockDTO>> Get()
        {
            try
            {
                var movimientosDto = _cuGetMovimiento.GetAll();
                var ordenada = movimientosDto.OrderByDescending(movimientos => movimientos.ID);
                return Ok(ordenada);
            }
            catch (ArticuloNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<Movimientos>/5
        [Authorize]
        [HttpGet("{id}", Name = "GetMov ByID")]
        public ActionResult<MovimientoStockDTO> Get(int id)
        {
            try
            {
                var movimientosDto = _cuGetMovimiento.GetByDTO(id);
                return Ok(movimientosDto);
            }
            catch (ArticuloNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<Movimientos>
        [Authorize]
        [HttpPost]
        public ActionResult<MovimientoStockDTO> Post([FromBody] MovimientoStockDTO mov)
        {
            try
            {
                _cuAltaMovimiento.Crear(mov);
                //return CreatedAtRoute("GetMovByID", new { id = mov.ID }, mov);
                return Ok(mov);
            }

            catch (ArticuloNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

       /* // PUT api/<Movimientos>/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<MovimientoStockDTO> Put(int id, [FromBody] MovimientoStockDTO mov)
        {
            try
            {
                _cuUpdateMovimiento.Update(id, mov);
                return Ok(mov);
            }
            catch (ArticuloNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<Movimientos>/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<MovimientoStockDTO> Delete(int id)
        {
            try
            {
                _cuBorrarMovimiento.Remove(id);
                return Ok();
            }
            catch (ArticuloNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/

        //TODO Verificar autorizacion en API
        // GET api/<Movimientos>/5/entradas
        [Authorize]
        [HttpGet("{id}/{mov}")]
        public ActionResult<MovimientoStockDTO> GetByIdYTipoMov(int id, string mov)
        {
            if (id == null)
                return BadRequest("Debe indicar el ID del Aritculo a buscar en MovimientoStock.");
            if (mov == null)
                return BadRequest("Debe indicar el Tipo Movimiento a buscar en MovimientoStock.");
            try
            {
                var movimientosDto = _cuGetMovimiento.GetMovimientosByIDArticuloYTipoMov(id, mov);
                if (movimientosDto.Count() == 0)
                    return NotFound("No se encontro movimiento con esa ID de Articulo y Tipo Movimiento.");
                return Ok(movimientosDto);
            }
            catch (ArticuloNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<Movimientos>/articulos-por-fechas
        [Authorize]
        [HttpGet("articulos-por-fechas")]
        public ActionResult<ArticuloDTO> GetArticuloByRangoFechas(DateTime fechaIni, DateTime fechaFin)
        {
            if (fechaIni == null)
                return BadRequest("Debe indicar la fecha de inicio para buscar en MovimientoStock.");
            if (fechaFin == null)
                return BadRequest("Debe indicar la fecha de fin para buscar en MovimientoStock.");
            if (fechaIni > fechaFin)
                return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin.");
            try
            {
                var articulosDTO = _cuGetMovimiento.GetArticulosByRangoFecha(fechaIni,fechaFin);
                if (articulosDTO.Count() == 0)
                    return NotFound("No se encontraron articulos en ese periodo de fechas.");
                return Ok(articulosDTO);
            }
            catch (ArticuloNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<Movimientos>/resumen
        //[Authorize]
        [HttpGet("resumen")]
        public ActionResult<object> ObtenerResumenMovimientosPorAnioYTipoMovimiento()
        {
            try
            {
                var resumen = _cuGetMovimiento.ObtenerResumenMovimientosPorAnioYTipoMovimiento();
                if (resumen.Count() == 0)
                    return NotFound("No se articulo en ese periodo de fechas.");
                return Ok(resumen);
            }
            catch (ArticuloNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
