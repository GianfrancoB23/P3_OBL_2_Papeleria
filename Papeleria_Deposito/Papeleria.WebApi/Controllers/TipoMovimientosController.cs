﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.TipoMovimientos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos;
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

        public TipoMovimientosController()
        {
            _repoTipoMov = new RepositorioTipoMovimientoEF();
            _cuAltaTipoMov = new AltaTipoMovimiento(_repoTipoMov);
            _cuBorrarTipoMov = new BorrarTipoMovimiento(_repoTipoMov);
            _cuGetAllTipoMov = new GetAllTiposMovimientos(_repoTipoMov);
            _cuGetTipoMovimiento = new BuscarTipoMovimiento(_repoTipoMov);
            _cuUpdateTipoMovimiento = new ModificarTipoMovimiento(_repoTipoMov);
        }

        // GET: TipoMovimientosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoMovimientosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoMovimientosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoMovimientosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoMovimientosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoMovimientosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoMovimientosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoMovimientosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
