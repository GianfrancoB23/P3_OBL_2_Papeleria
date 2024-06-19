using Empresa.LogicaDeNegocio.Entidades;
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
        private IBorrarMovimiento _cuBorrarMovimiento;
        private IUpdateMovimiento _cuUpdateMovimiento;

        public MovimientosController(IRepositorioArticulo repoArt,IRepositorioUsuario repoUsr, IRepositorioMovimientoStock repo, IAltaArticulo cuAltaArticulo, IGetAllArticulos cuGetArticulos,
            IGetArticulo cuGetArticulo, IBorrarArticulo cuBorrarArticulo, IUpdateArticulo cuModificarArticulo, IAltaMovimiento altaMovimiento, IBorrarMovimiento borrarMovimiento, IUpdateMovimiento updateMovimiento, IGetMovimiento getMovimiento)
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
            _cuBorrarMovimiento = borrarMovimiento;
            _cuUpdateMovimiento = updateMovimiento;
            _cuGetMovimiento = getMovimiento;
        }
        // GET: api/<Movimientos>
        [HttpGet]
        public ActionResult<IEnumerable<MovimientoStockDTO>> Get()
        {
            try
            {
                var movimientosDto = _cuGetMovimiento.GetAll();
                var ordenada = movimientosDto.OrderBy(movimientos => movimientos.NombreArticulo);
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
        [HttpGet("{id}")]
        public ActionResult<MovimientoStockDTO> Get(int id)
        {
            try
            {
                var movimientosDto = _cuGetMovimiento.Get(id);
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
        [HttpPost]
        public ActionResult<MovimientoStockDTO> Post([FromBody] MovimientoStockDTO mov)
        {
            try
            {
                _cuAltaMovimiento.Crear(mov);
                return CreatedAtRoute("Get", new { id = mov.ID }, mov);
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

        // PUT api/<Movimientos>/5
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
        }
    }
}
