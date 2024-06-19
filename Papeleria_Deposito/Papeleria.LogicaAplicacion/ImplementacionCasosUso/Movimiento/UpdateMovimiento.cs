using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.Interaces;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.MovimientoStock;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Movimiento
{
    public class UpdateMovimiento : IUpdateMovimiento
    {
        private IRepositorioMovimientoStock _repo;
        private IRepositorioArticulo _repoArt;
        private IRepositorioUsuario _repoUsr;
        public UpdateMovimiento(IRepositorioMovimientoStock repo, IRepositorioArticulo repoArt, IRepositorioUsuario repoUsr)
        {
            _repo = repo;
            _repoArt = repoArt;
            _repoUsr = repoUsr;
        }
        public void Update(int id, MovimientoStockDTO obj)
        {
            if (obj == null) { throw new Exception("Articulo modificado no puede ser nulo"); } // TODO exception handler
            try
            {
                var mov = MovimientoStockMappers.FromDTOUpdate(obj, _repoArt, _repoUsr);
                _repo.Update(id, mov);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
