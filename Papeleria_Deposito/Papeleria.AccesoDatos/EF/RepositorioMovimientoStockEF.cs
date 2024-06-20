using Empresa.LogicaDeNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Papeleria.AccesoDatos.EF
{
    public class RepositorioMovimientoStockEF : IRepositorioMovimientoStock
    {
        private PapeleriaContext _db;
        private IRepositorioTipoMovimiento _repoTM;
        private IRepositorioArticulo _repoArt;
        private IRepositorioUsuario _repoUsr;
        public RepositorioMovimientoStockEF(PapeleriaContext context, IRepositorioTipoMovimiento repoTM, IRepositorioArticulo repoArt, IRepositorioUsuario repoUsr)
        {
            _db = context; _repoTM = repoTM;
            _repoArt = repoArt;
            _repoUsr = repoUsr;
        }
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

        public int CtdMovimientos()
        {
            return _db.MovimientoStocks.Count();
        }

        public bool EstaEnUsoTipoMovimientoByID(int id)
        {
            if (id == null)
                throw new MovimientoStockNuloException("No puede ser nulo el ID del TipoMovimiento a buscar.");
            try
            {
                var tipMovs = _db.MovimientoStocks.Where(tipMov => tipMov.Movimiento.ID == id);
                return tipMovs != null;
            }
            catch (Exception ex)
            {
                throw new MovimientoStockNoValidoException(ex.Message);
            }
        }

        public bool EstaEnUsoTipoMovimientoByNombre(string nombre)
        {
            if (nombre == null)
                throw new MovimientoStockNuloException("No puede ser nulo el nombre del TipoMovimiento a buscar.");
            try
            {
                var tipMovs = _db.MovimientoStocks.Where(tipMov => tipMov.Movimiento.Nombre.Contains(nombre));
                return tipMovs != null;
            }
            catch (Exception ex)
            {
                throw new MovimientoStockNoValidoException(ex.Message);
            }
        }

        public IEnumerable<MovimientoStock> GetAll()
        {
            var movimientos = _db.MovimientoStocks.Include(a => a.Articulo).Include(b => b.Movimiento).Include(c => c.UsuarioRealizaMovimiento).ToList();
            return movimientos;
        }

        //A) Dados un id de artículo y un tipo de movimiento, todos los movimientos de ese tipo
        //realizados sobre ese artículo.Deberán estar ordenados descendentemente por fecha y en
        //forma ascendente por la cantidad de unidades involucradas en el movimiento Se deberá
        //mostrar todos los datos del movimiento, incluyendo todos los datos de su tipo.
        public IEnumerable<MovimientoStock> GetAllByIDArticulo_y_TipoMovimiento(int idArticulo, string tipoMovimiento)
        {
            if (idArticulo == null)
                throw new MovimientoStockNoValidoException("El ID del articulo por el cual quiere filtrar el movimiento de stock no puede ser nulo.");
            if (tipoMovimiento == null)
                throw new MovimientoStockNoValidoException("El tipo de movimiento por el cual quiere filtrar el movimiento de stock no puede ser nulo.");
            try
            {
                var movimientos = _db.MovimientoStocks.Where(mov => mov.Articulo.ID == idArticulo && mov.Movimiento.Nombre.ToLower().Equals(tipoMovimiento.ToLower()))
                    .Include(mov => mov.Articulo)
                    .Include(mov => mov.UsuarioRealizaMovimiento)
                    .Include(mov => mov.Movimiento)
                    .OrderByDescending(mov => mov.FecHorMovRealizado)
                    .ThenBy(mov => mov.CtdUnidadesXMovimiento)
                    .ToList();
                return movimientos;
            }
            catch (Exception ex)
            {
                throw new MovimientoStockNoValidoException(ex.Message);
            }
        }

        public MovimientoStock GetById(int id)
        {
            if (id == null)
                throw new MovimientoStockNuloException("No puede ser nulo el ID del objeto a buscar.");
            try
            {
                MovimientoStock? movStock = _db.MovimientoStocks.Include(a => a.Articulo).Include(b => b.Movimiento).Include(c => c.UsuarioRealizaMovimiento).FirstOrDefault(art => art.ID == id);
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
            if (obj == null)
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
