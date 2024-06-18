using Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.TipoMovimiento;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.TipoMovimientos
{
    public class BorrarTipoMovimiento : IBorrarTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repoTipoMovimiento;
        public BorrarTipoMovimiento(IRepositorioTipoMovimiento repo)
        {
            _repoTipoMovimiento = repo;
        }
        public void Ejecutar(int id)
        {
            if (id == null)
                throw new TipoMovimientoNuloException("El ID que desea borrar no puede ser nulo.");
            try
            {
                var tipMov = _repoTipoMovimiento.GetById(id);
                if (tipMov == null)
                    throw new TipoMovimientoNuloException("No se encontro tipo de movimiento con ese ID.");
                else
                    _repoTipoMovimiento.Remove(tipMov);
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNoValidoException(ex.Message);
            }
        }

        public void Ejecutar(TipoMovimiento articulo)
        {
            try
            {
                if (articulo == null)
                    throw new TipoMovimientoNuloException("El Tipo Movimiento que desea borrar no puede ser nulo.");
                _repoTipoMovimiento.Remove(articulo);
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNoValidoException(ex.Message);
            }
        }
    }
}
