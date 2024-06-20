using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using Papeleria.MVC.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
        public MovimientoController(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_url);
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public ActionResult Index()
        {            
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
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
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
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
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
            try
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
                ViewBag.usuario = HttpContext.Session.GetInt32("UserId");
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: MovimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovimientosModel movimiento)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
            try
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
                var json = JsonSerializer.Serialize(movimiento);
                var bodyJson = new StringContent(json, Encoding.UTF8, "application/json");
                var respuesta = _httpClient.PostAsync("Movimientos", bodyJson).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var content = respuesta.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    SetError(respuesta);
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: MovimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
            return View();
        }

        // POST: MovimientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
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
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
            return View();
        }

        // POST: MovimientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
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
