using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Papeleria.MVC.Models;
using System.Net.Http;
using System.Text.Json;

namespace Papeleria.MVC.Controllers
{
    public class MovimientoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://localhost:7148/api/";
        private readonly JsonSerializerOptions _jsonOptions
            = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        // GET: MovimientoStockController
        public MovimientoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_url);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public ActionResult Index()
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync("Movimientos").Result;
                if (response.IsSuccessStatusCode)
                {
                    var body = response.Content.ReadAsStringAsync().Result;
                    var objetos = JsonSerializer.Deserialize<IEnumerable<Models.MovimientosModel>>(body);
                    return View(objetos);
                } else
                {
                    SetError(response);
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();                
            }
        }

        // GET: MovimientoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync("Movimientos/"+id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var body = response.Content.ReadAsStringAsync().Result;
                    var objetos = JsonSerializer.Deserialize<Models.MovimientosModel>(body);
                    return View(objetos);
                }
                else
                {
                    SetError(response);
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: MovimientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovimientosModel movimiento)
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

        // GET: MovimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovimientoController/Edit/5
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

        // GET: MovimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovimientoController/Delete/5
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

        private void SetError(HttpResponseMessage respuesta)
        {
            var contenidoError = respuesta.Content.ReadAsStringAsync().Result;
            dynamic mensajeJson = JObject.Parse(@"{'Message':'" + contenidoError + "'}");
            ViewBag.Error = $"Hubo un error. {respuesta.ReasonPhrase} " + mensajeJson.Message;
        }
    }
}
