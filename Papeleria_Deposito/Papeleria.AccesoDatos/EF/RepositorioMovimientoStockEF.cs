using Empresa.LogicaDeNegocio.Entidades;
using Microsoft.Identity.Client;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.MovimientoStock;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EF
{
    public class RepositorioMovimientoStockEF : IRepositorioMovimientoStock
    {
        private PapeleriaContext _db;
        public RepositorioMovimientoStockEF(PapeleriaContext context) { _db = context; }
        public void Add(MovimientoStock obj)
        {
            if (obj == null)
                throw new MovimientoStockNuloException("No puede ser nulo el objeto a agregar.");
            try
            {
                _db.MovimientoStocks.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new MovimientoStockNoValidoException(ex.Message);
            }
        }

        public IEnumerable<MovimientoStock> GetAll()
        {
            return _db.MovimientoStocks.ToList();
        }

        public MovimientoStock GetById(int id)
        {
            if(id==null)
                throw new MovimientoStockNuloException("No puede ser nulo el ID del objeto a buscar.");
            try
            {
                MovimientoStock? movStock = _db.MovimientoStocks.FirstOrDefault(art => art.ID == id);
                return movStock;
            }
            catch (Exception ex)
            {
                throw new MovimientoStockNoValidoException(ex.Message);
            }
            
        }

        public IEnumerable<MovimientoStock> GetObjectsByID(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            if (id == null)
                throw new MovimientoStockNuloException("No puede ser nulo el ID del objeto a remover.");
            try
            {
                var movStock = _db.MovimientoStocks.FirstOrDefault(u => u.ID == id);
                if (movStock != null)
                {
                    _db.MovimientoStocks.Remove(movStock);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new MovimientoStockNoValidoException(ex.Message);
            }

        }

        public void Remove(MovimientoStock obj)
        {
            if(obj == null)
                throw new MovimientoStockNuloException("No puede ser nulo el OBJETO a remover.");
            try
            {
                _db.MovimientoStocks.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new MovimientoStockNoValidoException(ex.Message);
            }
            
        }

        public void Update(int id, MovimientoStock obj)
        {
            var movStock = _db.MovimientoStocks.FirstOrDefault(u => u.ID == id);

            if (movStock != null)
            {
                try
                {
                    movStock.ModificarDatos(obj);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new MovimientoStockNoValidoException(ex.Message);
                }
            }
            else
            {
                throw new MovimientoStockNuloException("El movimiento de stock no existe.");
            }
        }
    }
}
