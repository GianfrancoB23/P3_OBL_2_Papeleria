using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using System.Net.Http.Headers;
using Azure;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json.Serialization;
using System.Text.Json;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;

namespace Papeleria.MVC.Controllers
{
    public class ArticulosController : Controller
    {


        private static IRepositorioArticulo _repoArticulos = new RepositorioArticuloEF();
        private static IAltaArticulo _altaArticulo;
        private static IGetAllArticulos _getAllArticulos;
        private static IUpdateArticulo _modificarArticulo;
        private static IGetArticulo _getArticulo;
        private static IBorrarArticulo _borrarArticulo;


        public ArticulosController()
        {
            _altaArticulo = new AltaArticulo(_repoArticulos);
            _getAllArticulos = new GetAllArticulos(_repoArticulos);
            _modificarArticulo = new UpdateArticulo(_repoArticulos);
            _getArticulo = new BuscarArticulo(_repoArticulos);
            _borrarArticulo = new BorrarArticulo(_repoArticulos);
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                var articulo = _getAllArticulos.Ejecutar();
                if (articulo == null || articulo.Count() == 0)
                {
                    ViewBag.Mensaje = "No existen articulo";
                }
                ViewBag.Mensaje = $"Articulos en total: {articulo.Count()}.";
                return View(articulo);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloDTO articulo)
        {
            try
            {
                _altaArticulo.Ejecutar(articulo);
                TempData["MensajeOK"] = "Articulo creado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public ActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                ArticuloDTO dto = _getArticulo.GetByIdDTO(id.GetValueOrDefault());
                ArticuloDTO mod = new ArticuloDTO()
                {
                    Id = dto.Id,
                    CodigoProveedor = dto.CodigoProveedor,
                    Descripcion = dto.Descripcion,
                    NombreArticulo = dto.NombreArticulo,
                    PrecioVP = dto.PrecioVP,
                    Stock = dto.Stock
                };
                if (dto == null)
                    return View();
                return View(mod);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticuloDTO articulo)
        {
            try
            {
                _modificarArticulo.Ejecutar(id, articulo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                ArticuloDTO dto = _getArticulo.GetByIdDTO(id.GetValueOrDefault());
                ArticuloDTO borrar = new ArticuloDTO()
                {
                    Id = dto.Id,
                    CodigoProveedor = dto.CodigoProveedor,
                    NombreArticulo = dto.NombreArticulo,
                    Descripcion = dto.Descripcion,
                    PrecioVP = dto.PrecioVP,
                    Stock = dto.Stock,
                };
                if (dto == null)
                    { return RedirectToAction("Index", "Articulos"); }
                return View(borrar);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ArticuloDTO borrar, bool IsChecked)
        {
            try
            {
                if (IsChecked)
                {
                    _borrarArticulo.Ejecutar(id);
                }
                else
                {
                    ViewBag.msg = "Debe seleccionar el checkbox";
                }
                return RedirectToAction("Index", "Articulos");
            }
            catch
            {
                return View();
            }
        }
    }
}
