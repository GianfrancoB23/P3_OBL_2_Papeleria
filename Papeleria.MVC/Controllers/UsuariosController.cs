using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private static IRepositorioUsuario _repoUsuarios = new RepositorioUsuarioEF();
        private static IAltaUsuario _altaUsuario;
        private static IGetAllUsuarios _getAllUsuarios;
        private static IModificarUsuario _modificarUsuario;
        private static IGetUsuario _getUsuario;
        private static IBorrarUsuario _borrarUsuario;
        public UsuariosController()
        {
            _altaUsuario = new AltaUsuarios(_repoUsuarios);
            _getAllUsuarios = new GetAllUsuarios(_repoUsuarios);
            _modificarUsuario = new ModificarUsuario(_repoUsuarios);
            _getUsuario = new BuscarUsuario(_repoUsuarios);
            _borrarUsuario = new BorrarUsuario(_repoUsuarios);

        }
        // GET: UsuariosController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                var usuarios = _getAllUsuarios.Ejecutar();
                if (usuarios == null || usuarios.Count() == 0)
                {
                    ViewBag.Mensaje = "No existen usuarios";
                }
                ViewBag.Mensaje = $"Usuarios en total: {usuarios.Count()}.";
                return View(usuarios);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO autorDto)
        {
            try
            {
                _altaUsuario.Ejecutar(autorDto);
                TempData["MensajeOK"] = "Usuario creado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                UsuarioDTO dto = _getUsuario.GetByIdDTO(id.GetValueOrDefault());
                UsuarioDTO mod = new UsuarioDTO()
                {
                    Id = dto.Id,
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    Contrasenia = dto.Contrasenia
                };
                if (dto == null)
                    return View();
                return View(mod);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioDTO usu)
        {
            try
            {
                _modificarUsuario.Ejecutar(id, usu);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                UsuarioDTO dto = _getUsuario.GetByIdDTO(id.GetValueOrDefault());
                UsuarioDTO borrar = new UsuarioDTO() 
                {
                    Id = dto.Id,
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    Contrasenia = dto.Contrasenia
                };
                if (dto == null)
                    return RedirectToAction("Index", "Usuarios");
                if (dto.Id == HttpContext.Session.GetInt32("LogueadoID")) { 
                    TempData["Error"] = "No se puede borrar el usuario loggueado";
                    return RedirectToAction(nameof(Index));
                }
                return View(borrar);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioDTO borrar, bool IsChecked)
        {
            try
            {
                if (IsChecked)
                {
                    _borrarUsuario.Ejecutar(id, borrar);
                }
                else
                {
                    TempData["Error"] = "Debe seleccionar el checkbox";
                }
                return RedirectToAction("Index", "Usuarios");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        //TODO 2:22:26 - https://vimeopro.com/universidadortfi/fi-5212-programacion-3-cabella-69235-p3-m3a-remoto/video/929607409
    }
}
