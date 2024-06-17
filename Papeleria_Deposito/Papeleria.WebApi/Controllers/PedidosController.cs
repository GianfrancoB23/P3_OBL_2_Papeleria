using Empresa.LogicaDeNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Pedidos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Clientes;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Pedidos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Pedidos;
using Papeleria.LogicaNegocio.Excepciones.Pedido;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private static IRepositorioPedido _repoPedidos = new RepositorioPedidoEF();
        private static IRepositorioCliente _clientesRepo = new RepositorioClienteEF(_repoPedidos);
        private static IRepositorioLineaPedido _lineaPedido = new RepositorioLineaPedidoEF();
        private static IRepositorioArticulo _articulos = new RepositorioArticuloEF();
        private static IBuscarClientes _buscarClientes;
        private static IGetAllArticulos _getAllArticulos;
        private static IGetAllPedidos _getAllPedidos;
        private static IGetPedido _getPedidos;
        private static IAnularPedido _anularPedido;
        public PedidosController()
        {
            _buscarClientes = new BuscarClientes(_clientesRepo);
            _getAllArticulos = new GetAllArticulos(_articulos);
            _getAllPedidos = new GetAllPedidos(_repoPedidos);
            _getPedidos = new GetPedidos(_repoPedidos);
            _anularPedido = new AnularPedido(_repoPedidos);
        }
        // GET: api/<ArticulosController>
        /// <summary>
        /// Listar pedidos anulados
        /// </summary>
        /// <returns>200 - Retorna la lista con los pedidos anulados en orden descendente por Fecha | Status correspondiente al error</returns>
        [HttpGet]
        public ActionResult<IEnumerable<PedidoDTO>> Get()
        {
            try
            {
                _repoPedidos = new RepositorioPedidoEF();
                var clientes = _buscarClientes.GetAll();
                var pedidosDto = _getAllPedidos.Ejecutar();
                var ordenada = pedidosDto.OrderByDescending(pedido => pedido.FechaPedido);
                var pedidosFinal = new List<PedidoDTO>();
                foreach (var pedido in ordenada)
                {
                    if(pedido.anulado)
                    {
                        pedidosFinal.Add(pedido);
                    }
                }
                return Ok(pedidosFinal);
            }
            catch (PedidoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}
