using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.Interaces;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.MovimientoStock;
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
        public AltaMovimiento(IRepositorioMovimientoStock repo, IRepositorioArticulo repoArt)
        {
            _repoMov = repo; _repoArt = repoArt;
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
            MovimientoStock movimiento = MovimientoStockMappers.FromDTO(obj, _repoArt);
            _repoMov.Add(movimiento);
        }
    }
}
