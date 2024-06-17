using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos
{
    public interface IBorrarTipoMovimiento
    {
        void Ejecutar(int id);
        void Ejecutar(TipoMovimiento articulo);
    }
}
