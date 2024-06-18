using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.MovimientoStock;
using Papeleria.LogicaNegocio.Excepciones.TipoMovimiento;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Movimientos
{
    public class FiltrarMovimiento : IFiltrarMovimiento
    {
        private IRepositorioMovimientoStock _repoMovimiento;

        public FiltrarMovimiento(IRepositorioMovimientoStock repo)
        {
            _repoMovimiento = repo;
        }
        public bool ExisteTipoMovimientoEnMovimientoByID(int id)
        {
            if (id == null)
            {
                throw new TipoMovimientoNuloException("Debe ingresar un ID para buscar el tipo movimiento");
            }
            try
            {
                var mov = _repoMovimiento.EstaEnUsoTipoMovimientoByID(id);
                return mov;
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNuloException(ex.Message);
            }
        }

        public bool ExisteTipoMovimientoEnMovimientoByNombre(string nombre)
        {
            if (nombre == null)
            {
                throw new TipoMovimientoNuloException("Debe ingresar un ID para buscar el tipo movimiento");
            }
            try
            {
                var mov = _repoMovimiento.EstaEnUsoTipoMovimientoByNombre(nombre);
                return mov;
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNuloException(ex.Message);
            }
        }
    }
}
