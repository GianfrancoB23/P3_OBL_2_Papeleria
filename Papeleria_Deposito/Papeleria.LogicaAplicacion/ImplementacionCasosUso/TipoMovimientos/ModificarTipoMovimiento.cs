using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.TipoMovimientos;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos;
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
    public class ModificarTipoMovimiento : IUpdateTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repoTipoMovimiento;
        public ModificarTipoMovimiento(IRepositorioTipoMovimiento repo)
        {
            _repoTipoMovimiento = repo;
        }

        public void Ejecutar(int id, TipoMovimientoDTO tipoMovModificado)
        {
            if (tipoMovModificado == null)
                throw new TipoMovimientoNuloException("Tipo de movimiento no puede ser nulo al modificar.");
            try
            {
                var tp = TipoMovimientoMappers.FromDtoUpdate(tipoMovModificado);
                _repoTipoMovimiento.Update(id, tp);
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNoValidoException(ex.Message);
            }
        }
    }
}
