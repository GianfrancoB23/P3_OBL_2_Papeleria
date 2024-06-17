using Empresa.LogicaDeNegocio.Entidades;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Pedidos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Clientes;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Pedidos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Pedidos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using Papeleria.MVC.Models.PedidosModels;

namespace Papeleria.MVC.Controllers
{
    public class PedidosController : Controller
    {

        public PedidosController()
        {
        }
        public IActionResult Index()
        {
            ViewBag.Clientes = _buscarClientes.GetAll();
            ViewBag.Articulos = _getAllArticulos.Ejecutar();
            tempPedido = null;
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                var pedidos = _getAllPedidos.Ejecutar();
                if (pedidos == null || pedidos.Count() == 0)
                {
                    ViewBag.Mensaje = "No hay pedidos registrados";
                }
                return View(pedidos);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Index(DateTime date)
        {
            _pedidos = new RepositorioPedidoEF();
            ViewBag.Clientes = _buscarClientes.GetAll();
            ViewBag.Articulos = _getAllArticulos.Ejecutar();
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                if (date != null)
                {
                    var pedidos = _getPedidos.GetPedidosPorFecha(date);
                    if (pedidos == null || pedidos.Count() == 0)
                    {
                        ViewBag.Mensaje = "No existen pedido desde la fecha indicada";
                    }
                    return View(pedidos);
                }
                else
                {
                    RedirectToAction("Index", "Pedidos");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(int id)
        {
            ViewBag.Clientes = _buscarClientes.GetAll();
            ViewBag.Articulos = _getAllArticulos.Ejecutar();
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                PedidoDTO pedido = PedidosMappers.ToDto(_getPedidos.GetById(id));
                if (pedido == null)
                { return RedirectToAction("Index", "Pedidos"); }
                return View(pedido);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Anular(int id)
        {
            ViewBag.Clientes = _buscarClientes.GetAll();
            ViewBag.Articulos = _getAllArticulos.Ejecutar();
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                //PedidoDTO pedido = PedidosMappers.ToDto(_getPedidos.GetById(id));
                PedidoDTO pedido = _getPedidos.GetByIdDTO(id);
                if (pedido == null)
                { return RedirectToAction("Index", "Pedidos"); }
                return View(pedido);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Anular(int id, bool isChecked)
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                ViewBag.Clientes = _buscarClientes.GetAll();
                ViewBag.Articulos = _getAllArticulos.Ejecutar();
                Pedido pedido = _getPedidos.GetById(id);
                if (pedido == null)
                { return RedirectToAction("Index", "Pedidos"); }
                try
                {
                    if (isChecked)
                    {
                        _anularPedido.Ejecutar(id);
                    }
                    else
                    {
                        ViewBag.msg = "Debe aceptar las responsabilidades (checkbox) antes de anular el pedido";
                    }
                    return RedirectToAction("Index", "Pedidos");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                return View(pedido);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Crear()
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                ViewBag.Clientes = _buscarClientes.GetAll();
                ViewBag.Articulos = _getAllArticulos.Ejecutar();
                if (tempPedido != null)
                {
                    ViewBag.LineasPedido = tempPedido.LineasPedido;
                }
                var viewModel = new PedidoAltaModel
                {
                    LineasPedido = new List<LineaPedidoModel> { new LineaPedidoModel() } // Al menos una línea de pedido
                };
                return View(viewModel);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(PedidoDTO pedidoAlta)
        {
            ViewBag.Clientes = _buscarClientes.GetAll();
            ViewBag.Articulos = _getAllArticulos.Ejecutar();
            try
            {
                if (pedidoAlta == null)
                {
                    ViewBag.Error = "El pedido es invalido";
                    return View();
                }
                if (pedidoAlta.FechaEntrega < DateTime.Now)
                {
                    ViewBag.Error = "Fecha de entrega invalida";
                    return View();
                }
                pedidoAlta.FechaPedido = DateTime.Now;
                if (tempPedido != null)
                {
                    ViewBag.LineasPedido = tempPedido.LineasPedido;
                }
                if (ViewBag.LineasPedido.Count() == 0)
                {
                    ViewBag.Error = "Debe agregar al menos un articulo al pedido";
                    return View();
                }
                pedidoAlta.LineasPedido = tempPedido.LineasPedido;
                if ((pedidoAlta.FechaEntrega.Subtract(pedidoAlta.FechaPedido)).Days < 5)
                {
                    _altaPedido.EjecutarExpress(pedidoAlta);
                }
                else
                {
                    _altaPedido.EjecutarComunes(pedidoAlta);
                }
                tempPedido = null;
                return RedirectToAction("Index", "Pedidos");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("Index", "Pedidos");
            }
        }

        [HttpPost]
        public ActionResult AddArticulo(PedidoDTO pedido, int ArticuloId, int Cantidad)
        {
            try
            {
                ArticuloDTO articulo = _getArticulo.GetByIdDTO(ArticuloId);
                LineaPedidoDTO altaLinea = new LineaPedidoDTO { idArticulo = articulo.Id, CodigoProveedor = articulo.CodigoProveedor, NombreArticulo = articulo.NombreArticulo, Descripcion = articulo.Descripcion, PrecioVP = articulo.PrecioVP, Stock = articulo.Stock, PrecioUnitario = articulo.PrecioVP, Cantidad = Cantidad, Subtotal = Cantidad * articulo.PrecioVP };
                if (tempPedido == null)
                {
                    tempPedido = new PedidoDTO { LineasPedido = new List<LineaPedidoDTO>() };
                }
                tempPedido.LineasPedido.Add(altaLinea);
                return RedirectToAction(nameof(Crear));

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

    }
}
