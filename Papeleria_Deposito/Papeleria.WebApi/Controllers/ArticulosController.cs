using Empresa.LogicaDeNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IRepositorioArticulo _repoArticulos;
        private IGetAllArticulos _cuGetArticulos;
        private IGetArticulo _cuGetArticulo;
        private IAltaArticulo _cuAltaArticulo;
        private IBorrarArticulo _cuBorrarArticulo;
        private IUpdateArticulo _cuModificarArticulo;

        public ArticulosController()
        {
            _repoArticulos = new RepositorioArticuloEF();
            _cuGetArticulos = new GetAllArticulos(_repoArticulos);
            _cuGetArticulo = new BuscarArticulo(_repoArticulos);
            _cuAltaArticulo = new AltaArticulo(_repoArticulos);
            _cuBorrarArticulo = new BorrarArticulo(_repoArticulos);
            _cuModificarArticulo = new UpdateArticulo(_repoArticulos);
        }
        // GET: api/<ArticulosController>
        /// <summary>
        /// Listar todos los articulos
        /// </summary>
        /// <returns>Lista de articulos ordenados alfabeticamente.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ArticuloDTO>> Get()
        {
            try
            {
                var articulosDto = _cuGetArticulos.Ejecutar();
                var ordenada = articulosDto.OrderBy(articulo => articulo.NombreArticulo);
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

        // GET api/<ArticulosController>/5
        /// <summary>
        /// Listar articulo particuloar
        /// </summary>
        /// <param name="id">Número entero con el valor Id del articulo a buscar</param>
        /// <returns>Articulo correspondiente al ID - Code 200 | Error 400 (Bad Request) si parametro/articulo es invalido |  500 - Error con la DB / Excepcion particular</returns>
        [HttpGet("{id}", Name = "GetAutorByID")]
        public ActionResult<ArticuloDTO> Get(int id)
        {
            try
            {
                var articuloDto = _cuGetArticulo.GetById(id);
                return Ok(articuloDto);
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
        // POST api/<ArticulosController>
        /// <summary>
        /// Agregar articulo
        /// </summary>
        /// <param name="articulo">Parametro que toma el articulo armado con sus respectivos atributos y lo pasa a la aplicacion para registrarlo</param>
        /// <returns>201 - Si el Articulo fue creado satisfactoriamente | 400 - Si el Articulo suministrado no es valido | 500 - Error con la DB / Excepcion particular</returns>
        [HttpPost]
        public ActionResult<ArticuloDTO> Post(ArticuloDTO articulo)
        {
            try
            {
                _cuAltaArticulo.Ejecutar(articulo);
                return CreatedAtRoute("GetAutorByID", new { id = articulo.Id }, articulo);
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

        // PUT api/<ArticulosController>/5
        /// <summary>
        /// Modificar articulo
        /// </summary>
        /// <param name="id">Proporciona el ID del objeto a modificar</param>
        /// <param name="articulo">Proporciona el cuerpo del articulo que va a reemplazar al existente</param>
        /// <returns>200 - Articulo modificado correctamente | 400 - ID/Articulo nuevo invalido | 500 - Error en la DB / Excepcion particular</returns>
        [HttpPut("{id}")]
        public ActionResult<ArticuloDTO> Put(int id, ArticuloDTO articulo)
        {
            try
            {
                _cuModificarArticulo.Ejecutar(id, articulo);
                return Ok(articulo);
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

        // DELETE api/<ArticulosController>/5
        /// <summary>
        /// Borrar articulo
        /// </summary>
        /// <param name="id">Proporciona el ID del articulo a borrar</param>
        /// <returns>200 - Articulo borrado correctamente | 400 - ID Invalido o Articulo no valido | 500 - Error de la DB / Excepcion particular</returns>
        [HttpDelete("{id}")]
        public ActionResult<ArticuloDTO> Delete(int id)
        {
            try
            {
                _cuBorrarArticulo.Ejecutar(id);
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
