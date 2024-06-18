using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipMovController : ControllerBase
    {
        private IRepositorioTipoMovimiento _repoTipoMov;
        private IAltaTiposMovimientos _cuAltaTipoMov;
        private IBorrarTipoMovimiento _cuBorrarTipoMov;
        private IGetAllTipoMovimiento _cuGetAllTipoMov;
        private IGetTipoMovimiento _cuGetTipoMovimiento;
        private IUpdateTipoMovimiento _cuUpdateTipoMovimiento;

        public TipMovController(IRepositorioTipoMovimiento repoTipoMov, IAltaTiposMovimientos cuAltaTipoMov, IBorrarTipoMovimiento cuBorrarTipoMov,
            IGetAllTipoMovimiento cuGetAllTipoMov, IGetTipoMovimiento cuGetTipoMovimiento, IUpdateTipoMovimiento cuUpdateTipoMovimiento)
        {
            _repoTipoMov = repoTipoMov;
            _cuAltaTipoMov = cuAltaTipoMov;
            _cuBorrarTipoMov = cuBorrarTipoMov;
            _cuGetAllTipoMov = cuGetAllTipoMov;
            _cuGetTipoMovimiento = cuGetTipoMovimiento;
            _cuUpdateTipoMovimiento = cuUpdateTipoMovimiento;
        }
        // GET: api/<TipMovController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TipMovController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TipMovController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TipMovController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TipMovController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
