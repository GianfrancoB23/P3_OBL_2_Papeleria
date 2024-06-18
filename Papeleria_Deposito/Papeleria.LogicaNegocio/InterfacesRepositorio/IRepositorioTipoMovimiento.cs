using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioTipoMovimiento:IRepositorio<TipoMovimiento>
    {
        public bool ExisteTipoMovimientoXNombre(string nombre);
        public TipoMovimiento GetTipoMovimientoXNombre(string nombre);
    }
}
