using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using SistemaDocentes.Api.UtilidadesJwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private ILogin _login;
        public UsuariosController(ILogin login)
        {
            _login = login;
        }
        // GET: api/<UsuarioController>
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
