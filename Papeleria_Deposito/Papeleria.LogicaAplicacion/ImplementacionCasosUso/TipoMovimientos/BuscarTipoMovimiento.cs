using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.TipoMovimientos;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
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
    public class BuscarTipoMovimiento : IGetTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repoTipoMovimiento;
        public BuscarTipoMovimiento(IRepositorioTipoMovimiento repo)
        {
            _repoTipoMovimiento = repo;
        }
        public TipoMovimiento GetById(int id)
        {
            try
            {
                return _repoTipoMovimiento.GetById(id);
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNuloException(ex.Message);
            }
        }

        public TipoMovimientoDTO GetByIdDTO(int id)
        {
            try
            {
                var tipMov = _repoTipoMovimiento.GetById(id);
                if (tipMov == null)
                {
                    throw new TipoMovimientoNuloException("No hay tipo movimiento con ese id");
                }
                var tmDTO = TipoMovimientoMappers.ToDto(tipMov);
                return tmDTO;
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNuloException(ex.Message);
            }
            
        }
    }
}
