﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Interaces
{
    public interface IAlta<T>
    {
        public void Crear(T obj);
    }
}