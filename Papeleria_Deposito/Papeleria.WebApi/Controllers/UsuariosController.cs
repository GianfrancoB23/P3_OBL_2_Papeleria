using Empresa.LogicaDeNegocio.Sistema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using SistemaDocentes.Api.UtilidadesJwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private ILogin _login;
        private PapeleriaContext _context;
        private IRepositorioUsuario _repo;
        private IAltaUsuario _altaUsuario;
        private IBorrarUsuario _borrarUsuario;
        private IGetAllUsuarios _getAllUsuarios;
        private IGetUsuario _getUsuario;
        private IModificarUsuario _modificarUsuario;
        public UsuariosController(ILogin login, PapeleriaContext context,IRepositorioUsuario repo, IAltaUsuario altaUsuario, IBorrarUsuario borrarUsuario, IGetAllUsuarios getAllUsuarios, IGetUsuario getUsuario, IModificarUsuario modificarUsuario)
        {
            _login = login;
            _context = context;
            _repo = repo;
            _altaUsuario = altaUsuario;
            _borrarUsuario = borrarUsuario;
            _getAllUsuarios = getAllUsuarios;
            _getUsuario = getUsuario;
            _modificarUsuario = modificarUsuario;
        }


        // GET: api/<UsuarioController>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> Get()
        {
            try
            {
                var usuariosDto = _getAllUsuarios.Ejecutar();
                var ordenada = usuariosDto.OrderBy(usuario => usuario.Nombre);
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
        [HttpPost]
        public ActionResult<UsuarioDTO> Post(UsuarioDTO usr)
        {
            try
            {
                _altaUsuario.Ejecutar(usr);
                return CreatedAtRoute("GetById", new { id = usr.Id }, usr);
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
        [HttpGet("{id}", Name = "GetByID")]
        public ActionResult<ArticuloDTO> Get(int id)
        {
            try
            {
                var usr = _getUsuario.GetById(id);
                return Ok(usr);
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

        // POST: api/<UsuarioController>/login
        [AllowAnonymous]
        [HttpPost("login")]
        //xxxxx
        public IActionResult Login(UsuarioDTO usr)
        {
            try
            {
                var rol = _login.Ejecutar(usr.Email, usr.Contrasenia);
                if (string.IsNullOrWhiteSpace(rol))
                {
                    return Unauthorized("Credenciales incorrectas");
                }
                string token = ManejadorJwt.GenerarToken(usr.Email, rol);
                return Ok(new { Token = token, Rol = rol, Email = usr.Email });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { Error = "Credenciales incorrectas" });
            }

        }
    }
}
