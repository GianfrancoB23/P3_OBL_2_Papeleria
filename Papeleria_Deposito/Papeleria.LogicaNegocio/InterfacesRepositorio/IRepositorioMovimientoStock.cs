using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioMovimientoStock : IRepositorio<MovimientoStock>
    {
        public bool EstaEnUsoTipoMovimientoByID(int id);
        public bool EstaEnUsoTipoMovimientoByNombre(string nombre);
        public int CtdMovimientos();
        public IEnumerable<MovimientoStock> GetAllByIDArticulo_y_TipoMovimiento(int idArticulo, string tipoMovimiento);
    }
}
