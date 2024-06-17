using Empresa.LogicaDeNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Clientes;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Clientes;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private static IRepositorioPedido _pedidos = new RepositorioPedidoEF();
        private static IRepositorioCliente _clientesRepo = new RepositorioClienteEF(_pedidos);
        private static IBuscarClientes _buscarClientes;
        private static IAltaCliente _altaCliente;
        private static IModificarCliente _modificarCliente;
        private static IBorrarCliente _borrarCliente;
        public ClientesController()
        {
            _buscarClientes = new BuscarClientes(_clientesRepo);
            _altaCliente = new AltaClientes(_clientesRepo);
            _modificarCliente = new ModificarCliente(_clientesRepo);
            _borrarCliente = new BorrarCliente(_clientesRepo);
        }
        // GET: ClientesController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                var clientes = _buscarClientes.GetAll();
                if (clientes == null || clientes.Count() == 0)
                {
                    ViewBag.Mensaje = "No existen clientes";
                }
                ViewBag.Mensaje = $"Clientes en total: {clientes.Count()}.";
                return View(clientes);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Index(string razonSocial, double? monto, string submitButton)
        {
            TempData["ResultadoBuscarCliente"] = "";
            try
            {
                if (!string.IsNullOrEmpty(submitButton))
                {
                    if (submitButton == "Filtrar X Razon")
                    {
                        if (!string.IsNullOrEmpty(razonSocial))
                        {
                            var clienteRazonSocial = _buscarClientes.GetXRazonSocial(razonSocial);
                            if (clienteRazonSocial == null)
                            {
                                TempData["ResultadoBuscarClientes"] = "No se ha encontrado ninguna coincidencia para esa razon social.";
                                return RedirectToAction("Index", "Clientes");
                            }
                            return View("Details",clienteRazonSocial);
                        }
                        else
                        {
                            TempData["ResultadoBuscarClientes"] = "No se encontraron coincidencias de búsqueda.";
                            return RedirectToAction("Index", "Clientes");
                        }
                    }
                    else if (submitButton == "Filtrar X Monto")
                    {
                        if (monto != null)
                        {
                            ViewBag.Monto = monto;
                            var clientesSuperaronMonto = _buscarClientes.GetXMontoSuperado(monto.Value);
                            if (!clientesSuperaronMonto.Any())
                            {
                                TempData["ResultadoBuscarClientes"] = "No se ha encontrado ninguna coincidencia para ese monto.";
                                return View();
                            }
                            return View("ListaSuperaronMonto", clientesSuperaronMonto);
                        }
                        else
                        {
                            TempData["ResultadoBuscarClientes"] = "Ocurrió un error en la búsqueda";
                            return RedirectToAction("Index", "Clientes");
                        }
                    }
                }
                TempData["ResultadoBuscarClientes"] = "No se ha encontrado ninguna coincidencia.";
                return RedirectToAction("Index", "Clientes");
            }
            catch (Exception e)
            {
                TempData["ResultadoBuscarClientes"] = e.Message;
                return RedirectToAction("Index", "Clientes");
            }
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteDTO cliente)
        {
            try
            {
                _altaCliente.Ejecutar(cliente);
                TempData["MensajeOK"] = "Cliente creado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                ClienteDTO dto = _buscarClientes.GetByIdDTO(id);
                ClienteDTO mod = new ClienteDTO()
                {
                    Id = dto.Id,
                    rut = dto.rut,
                    razonSocial = dto.razonSocial,
                    Calle = dto.Calle,
                    Numero = dto.Numero,
                    Ciudad = dto.Ciudad,
                    Distancia = dto.Distancia
                };
                if (dto == null)
                    return View();
                return View(mod);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteDTO mod)
        {
            try
            {
                _modificarCliente.Ejecutar(id, mod);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                ClienteDTO dto = _buscarClientes.GetByIdDTO(id);
                ClienteDTO borrar = new ClienteDTO()
                {
                    Id = dto.Id,
                    rut = dto.rut,
                    razonSocial = dto.razonSocial,
                    Calle = dto.Calle,
                    Numero = dto.Numero,
                    Ciudad = dto.Ciudad,
                    Distancia = dto.Distancia
                };
                if (dto == null)
                    return RedirectToAction("Index", "Cliente");
                return View(borrar);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ClienteDTO borrar, bool IsChecked)
        {
            try
            {
                if (IsChecked)
                {
                    _borrarCliente.Ejecutar(id, borrar);
                }
                else
                {
                    TempData["Error"] = "Debe seleccionar el checkbox";
                }
                return RedirectToAction("Index", "Clientes");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
