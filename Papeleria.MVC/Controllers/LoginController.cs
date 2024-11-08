﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Papeleria.MVC.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
///xxxxx
namespace Papeleria.MVC.Controllers
{
    public class LoginController : Controller
    {
        private HttpClient _httpClient;
        private readonly string _url = "https://localhost:7148/api/";
        //Configuracion para deserializar el json y evitar errores por mayusculas y minusculas
        private JsonSerializerOptions _jsonOptions
            = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_url);
        }

        // GET: LoginController/Create
        public ActionResult Autorizar()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autorizar(LoginModel loginModel)
        {
            try
            {
                //loginModel.Nombre = "";
                //loginModel.Apellido = "";
                var json = JsonSerializer.Serialize(loginModel);
                var body = new StringContent(json, Encoding.UTF8, "application/json");
                var respuesta = _httpClient.PostAsync("Usuarios/login", body).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var content = respuesta.Content.ReadAsStringAsync().Result;

                    var token = JsonSerializer.Deserialize<LoginToken>(content, _jsonOptions);
                    if (token == null)
                    {
                        ViewBag.Error = "No se ha podido deserializar el token";
                        return View(loginModel);
                    }
                    HttpContext.Session.SetString("Token", token.Token);
                    HttpContext.Session.SetString("Rol", token.Rol);
                    HttpContext.Session.SetInt32("UserId", token.UserId);
                    //HttpContext.Session.SetString("Email", token.Email);
                    //Agregar el token a las cabeceras de las peticiones, para que el servidor lo pueda validar
                    //No olvidar que el token debe ser enviado en todas las peticiones
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.Token}");
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    SetError(respuesta);
                    return View(loginModel);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(loginModel);
            }
        }

        public ActionResult CerrarSesion()
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return RedirectToAction("Login");
            }
           
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("Rol");
           // HttpContext.Session.Remove("Email");
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            return RedirectToAction("Autorizar","Login");
        }
        private void SetError(HttpResponseMessage respuesta)
        {
            var contenidoError = respuesta.Content.ReadAsStringAsync().Result;
            dynamic mensajeJson = JObject.Parse(@"{'Message':'" + contenidoError + "'}");
            ViewBag.Error = $"Hubo un error. {respuesta.ReasonPhrase} " + mensajeJson.Message;
        }
    }
}
