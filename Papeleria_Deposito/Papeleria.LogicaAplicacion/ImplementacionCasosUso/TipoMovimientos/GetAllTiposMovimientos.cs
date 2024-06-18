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
    public class GetAllTiposMovimientos : IGetAllTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repoTipoMovimiento;
        public GetAllTiposMovimientos(IRepositorioTipoMovimiento repo)
        {
            _repoTipoMovimiento = repo;
        }
        public IEnumerable<TipoMovimientoDTO> Ejecutar()
        {
            try
            {
                var tmOrigen = _repoTipoMovimiento.GetAll();
                if (tmOrigen == null || tmOrigen.Count() == 0)
                {
                    throw new TipoMovimientoNuloException("No hay autores registrados");
                }
                return TipoMovimientoMappers.FromLista(tmOrigen);
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNoValidoException(ex.Message);
            }
            
        }
    }
}
