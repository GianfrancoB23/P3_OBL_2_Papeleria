﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.MVC.Models;
using System.Text.Json;

namespace Papeleria.MVC.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://localhost:7148/api/";
        private readonly JsonSerializerOptions _jsonOptions
            = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        // GET: MovimientoStockController
        public ConsultasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_url);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: ConsultasController
        public ActionResult Index()
        {
            HttpResponseMessage articulosRequest = _httpClient.GetAsync("Articulos").Result;
            HttpResponseMessage tipoMovRequest = _httpClient.GetAsync("TipoMovimientos").Result;
            IEnumerable<ArticuloModel> articulos = null;
            IEnumerable<TipoMovimientoModel> tiposMovimientos = null;
            if (articulosRequest.IsSuccessStatusCode)
            {
                var body = articulosRequest.Content.ReadAsStringAsync().Result;
                var objetos = JsonSerializer.Deserialize<IEnumerable<Models.ArticuloModel>>(body);
                articulos = objetos;
            }
            if (tipoMovRequest.IsSuccessStatusCode)
            {
                var body = tipoMovRequest.Content.ReadAsStringAsync().Result;
                var objetos = JsonSerializer.Deserialize<IEnumerable<Models.TipoMovimientoModel>>(body);
                tiposMovimientos = objetos;
            }
            ViewBag.articulos = articulos;
            ViewBag.tiposMovimientos = tiposMovimientos;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int ArticuloID, string tipoMovimientoNombre, DateTime fechaIni, DateTime fechaFin)
        {
            TempData["ResultadoBuscarMovimientos"] = "";
            try
            {
                if (!string.IsNullOrEmpty(tipoMovimientoNombre) && ArticuloID != null)
                {
                    HttpResponseMessage movimientossRequest = _httpClient.GetAsync($"Movimientos/{ArticuloID}/{tipoMovimientoNombre}").Result;
                    IEnumerable<MovimientosModel> movimientos = null;

                    var body = movimientossRequest.Content.ReadAsStringAsync().Result;
                    var objetos = JsonSerializer.Deserialize<IEnumerable<Models.MovimientosModel>>(body);
                    movimientos = objetos;

                    if (movimientos.Count() == 0)
                    {
                        TempData["ResultadoBuscarMovimientos"] = "No se ha encontrado ninguna coincidencia para ese movimiento.";
                        return RedirectToAction("Index", "Consultas");
                    }
                    return View("Consulta1", movimientos);
                }
                //else
                //{
                //    TempData["ResultadoBuscarMovimientos"] = "Parametros invalidos.";
                //    return RedirectToAction("Index", "Consultas");
                //}
                TempData["ResultadoBuscarMovimientos"] = "No se ha encontrado ninguna coincidencia. Verifique los parametros ingresados.";
                return RedirectToAction("Index", "Consultas");
            }
            catch (Exception e)
            {
                TempData["ResultadoBuscarMovimientos"] = e.Message;
                return RedirectToAction("Index", "Consultas");
            }
        }

        // GET: ConsultasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConsultasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsultasController/Create
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

        // GET: ConsultasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConsultasController/Edit/5
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

        // GET: ConsultasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConsultasController/Delete/5
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
