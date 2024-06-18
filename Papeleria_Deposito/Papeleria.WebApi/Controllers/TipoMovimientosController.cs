using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.TipoMovimientos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.TipoMovimientos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.TipoMovimiento;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.WebApi.Controllers
{
    public class TipoMovimientosController : Controller
    {
        private IRepositorioTipoMovimiento _repoTipoMov;
        private IAltaTiposMovimientos _cuAltaTipoMov;
        private IBorrarTipoMovimiento _cuBorrarTipoMov;
        private IGetAllTipoMovimiento _cuGetAllTipoMov;
        private IGetTipoMovimiento _cuGetTipoMovimiento;
        private IUpdateTipoMovimiento _cuUpdateTipoMovimiento;

        public TipoMovimientosController(IRepositorioTipoMovimiento repoTipoMov, IAltaTiposMovimientos cuAltaTipoMov, IBorrarTipoMovimiento cuBorrarTipoMov,
            IGetAllTipoMovimiento cuGetAllTipoMov, IGetTipoMovimiento cuGetTipoMovimiento, IUpdateTipoMovimiento cuUpdateTipoMovimiento)
        {
            _repoTipoMov = repoTipoMov;
            _cuAltaTipoMov = cuAltaTipoMov;
            _cuBorrarTipoMov = cuBorrarTipoMov;
            _cuGetAllTipoMov = cuGetAllTipoMov;
            _cuGetTipoMovimiento = cuGetTipoMovimiento;
            _cuUpdateTipoMovimiento = cuUpdateTipoMovimiento;
        }

        // GET: api/<TipoMovimientosController>
        /// <summary>
        /// Listar todos los Tipos Movimientos
        /// </summary>
        /// <returns>Tipos Movimientos ordenados por ID.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<TipoMovimientoDTO>> Get()
        {
            try
            {
                var tipMovDTO = _cuGetAllTipoMov.Ejecutar();
                var ordenada = tipMovDTO.OrderBy(mov => mov.ID);
                return Ok(ordenada);
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // GET api/<TipoMovimientosController>/5
        /// <summary>
        /// Listar TipoMovimiento particular
        /// </summary>
        /// <param name="id">Número entero con el valor ID del tipo movimiento a buscar.</param>
        /// <returns>Tipo movimiento correspondiente al ID - Code 200 | Error 400 (Bad Request) si parametro/articulo es invalido |  500 - Error con la DB / Excepcion particular</returns>
        [HttpGet("{ID}", Name = "GetTipoMovimientoByID")]
        public ActionResult<ArticuloDTO> Get(int id)
        {
            try
            {
                var tipMovDTO = _cuGetTipoMovimiento.GetById(id);
                return Ok(tipMovDTO);
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<TipoMovimientosController>
        /// <summary>
        /// Agregar Tipo Movimiento
        /// </summary>
        /// <param name="tipMov">Parametro que toma el "TipoMovimiento" armado con sus respectivos atributos y lo pasa a la aplicacion para registrarlo</param>
        /// <returns>201 - Si el Articulo fue creado satisfactoriamente | 400 - Si el Articulo suministrado no es valido | 500 - Error con la DB / Excepcion particular</returns>
        [HttpPost]
        public ActionResult<TipoMovimientoDTO> Post(TipoMovimientoDTO tipMov)
        {
            try
            {
                _cuAltaTipoMov.Ejecutar(tipMov);
                return CreatedAtRoute("GetTipoMovimientoByID", new { id = tipMov.ID }, tipMov);
            }

            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<TipoMovimientosController>/5
        /// <summary>
        /// Modificar TipoMovimiento
        /// </summary>
        /// <param name="id">Proporciona el ID del objeto a modificar</param>
        /// <param name="tipMov">Proporciona el cuerpo del articulo que va a reemplazar al existente</param>
        /// <returns>200 - Articulo modificado correctamente | 400 - ID/Articulo nuevo invalido | 500 - Error en la DB / Excepcion particular</returns>
        [HttpPut("{id}")]
        public ActionResult<TipoMovimientoDTO> Put(int id, TipoMovimientoDTO tipMov)
        {
            try
            {
                _cuUpdateTipoMovimiento.Ejecutar(id, tipMov);
                return Ok(tipMov);
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<TipoMovimientosController>/5
        /// <summary>
        /// Borrar Tipo Movimiento.
        /// </summary>
        /// <param name="id">Proporciona el ID del "Tipo Movimiento" a borrar</param>
        /// <returns>200 - Articulo borrado correctamente | 400 - ID Invalido o Articulo no valido | 500 - Error de la DB / Excepcion particular</returns>
        [HttpDelete("{id}")]
        public ActionResult<TipoMovimientoDTO> Delete(int id)
        {
            try
            {
                _cuBorrarTipoMov.Ejecutar(id);
                return Ok();
            }
            catch (TipoMovimientoNoValidoException ex)
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
