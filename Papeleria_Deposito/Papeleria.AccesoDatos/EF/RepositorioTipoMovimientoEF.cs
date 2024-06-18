using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.MovimientoStock;
using Papeleria.LogicaNegocio.Excepciones.TipoMovimiento;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EF
{
    public class RepositorioTipoMovimientoEF : IRepositorioTipoMovimiento
    {
        private PapeleriaContext _db;
        public RepositorioTipoMovimientoEF(PapeleriaContext context)
        {
            _db = context;
        }

        public void Add(TipoMovimiento obj)
        {
            if (obj == null)
                throw new TipoMovimientoNuloException("No puede ser nulo el objeto a agregar.");
            try
            {
                _db.TiposMovimientos.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNoValidoException(ex.Message);
            }
        }

        public bool ExisteTipoMovimientoXNombre(string nombre)
        {
            TipoMovimiento tipMov = GetTipoMovimientoXNombre(nombre);
            return tipMov != null;
        }

        public IEnumerable<TipoMovimiento> GetAll()
        {
            return _db.TiposMovimientos.ToList();
        }

        public TipoMovimiento GetById(int id)
        {
            if (id == null)
                throw new TipoMovimientoNuloException("No puede ser nulo el ID del objeto a buscar.");
            try
            {
                TipoMovimiento? tipMov = _db.TiposMovimientos.FirstOrDefault(art => art.ID == id);
                return tipMov;
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNoValidoException(ex.Message);
            }
        }

        public IEnumerable<TipoMovimiento> GetObjectsByID(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public TipoMovimiento GetTipoMovimientoXNombre(string nombre)
        {
            if (nombre == null)
                throw new TipoMovimientoNuloException("El nombre ingresado para GetTipoMovimientoXNombre no puede ser nulo.");
            return _db.TiposMovimientos.FirstOrDefault(u => u.Nombre == nombre);
        }

        public void Remove(int id)
        {
            if (id == null)
                throw new TipoMovimientoNuloException("No puede ser nulo el ID del objeto a remover.");
            try
            {
                var tipMov = _db.TiposMovimientos.FirstOrDefault(u => u.ID == id);
                if (tipMov != null)
                {
                    _db.TiposMovimientos.Remove(tipMov);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNoValidoException(ex.Message);
            }
        }

        public void Remove(TipoMovimiento obj)
        {
            if (obj == null)
                throw new TipoMovimientoNuloException("No puede ser nulo el OBJETO a remover.");
            try
            {
                _db.TiposMovimientos.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new TipoMovimientoNoValidoException(ex.Message);
            }
        }

        public void Update(int id, TipoMovimiento obj)
        {
            var movStock = _db.TiposMovimientos.FirstOrDefault(u => u.ID == id);
            if (movStock != null)
            {
                try
                {
                    movStock.ModificarDatos(obj);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new TipoMovimientoNoValidoException(ex.Message);
                }
            }
            else
            {
                throw new TipoMovimientoNuloException("El movimiento de stock no existe.");
            }
        }
    }
}
