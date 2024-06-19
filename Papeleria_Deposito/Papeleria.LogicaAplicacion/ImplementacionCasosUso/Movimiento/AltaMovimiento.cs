using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.Interaces;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Movimientos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Movimiento
{
    public class AltaMovimiento : IAltaMovimiento
    {
        private IRepositorioMovimientoStock _repoMov;
        private IRepositorioArticulo _repoArt;
        private IRepositorioUsuario _repoUsr;
        private IRepositorioTipoMovimiento _repoTipMov;
        public AltaMovimiento(IRepositorioMovimientoStock repo, IRepositorioArticulo repoArt, IRepositorioUsuario repoUsr, IRepositorioTipoMovimiento repoTipMov)
        {
            _repoMov = repo; _repoArt = repoArt; _repoUsr = repoUsr; _repoTipMov = repoTipMov ;
        }
        public void Crear(MovimientoStockDTO obj)
        {
            if(obj == null)
            {
                throw new Exception("No se puede ingresar algo nulo"); // TODO excepciones
            }
            if(obj.CtdUnidadesXMovimiento <= 0)
            {
                throw new Exception("No se puede realizar un movimiento de cantidades nulas o negativas");
            }
            MovimientoStock movimiento = MovimientoStockMappers.FromDTO(obj, _repoArt, _repoUsr, _repoTipMov);
            _repoMov.Add(movimiento);
        }
    }
}
