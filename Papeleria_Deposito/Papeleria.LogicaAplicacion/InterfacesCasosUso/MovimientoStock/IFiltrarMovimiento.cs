﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.MovimientoStock
{
    public interface IFiltrarMovimiento
    {
        bool ExisteTipoMovimientoEnMovimientoByNombre(string nombre);
        bool ExisteTipoMovimientoEnMovimientoByID(int id);
    }
}