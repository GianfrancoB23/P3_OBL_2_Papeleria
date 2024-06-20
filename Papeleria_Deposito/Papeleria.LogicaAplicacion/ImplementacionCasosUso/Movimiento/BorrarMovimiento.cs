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
    public class BorrarMovimiento : IBorrarMovimiento
    {
        private static IRepositorioMovimientoStock _repo;
        public BorrarMovimiento(IRepositorioMovimientoStock repo) { _repo = repo; }

        public void Remove(int id)
        {
            var movimiento = _repo.GetById(id);
            if (movimiento == null)
            {
                throw new Exception("Movimiento no puede ser nulo");
            }
            try
            {
                _repo.Remove(movimiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); // TODO proper exception
            }

        }
        public void Remove(MovimientoStock obj)
        {
            if (obj != null)
            {
                throw new Exception("Movimiento no puede ser nulo");
            }
            try
            {
                _repo.Remove(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); // TODO proper exception
            }

        }
    }
}
