using Empresa.LogicaDeNegocio.Sistema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using Papeleria.MVC.Models;
using System.Diagnostics;

namespace Papeleria.MVC.Controllers
{
    public class HomeController : Controller
    {
        private static IRepositorioUsuario _repoUsuarios = new RepositorioUsuarioEF();
        private static IRepositorioArticulo _repoArticulo = new RepositorioArticuloEF();


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Comentar si no queres entrar directo 
           /* Usuario usuLogin = _repoUsuarios.Login("prueba@prueba.com", "Prueba123!");
            HttpContext.Session.SetInt32("LogueadoID", usuLogin.Id);*/

            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                return RedirectToAction("Index", "Usuarios");

            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                return RedirectToAction("Index", "Publicacion");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Login(string Email, string Contrasenia)
        {
            Usuario usuLogin = _repoUsuarios.Login(Email, Contrasenia);
            if (usuLogin != null)
            {
                HttpContext.Session.SetInt32("LogueadoID", usuLogin.Id);
                HttpContext.Session.SetString("LogueadoEmail", usuLogin.Email.Direccion);
                return RedirectToAction("Index", "Usuarios");
            }
            else
            {
                TempData["Error"] = "Error en los datos ingresados";
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
