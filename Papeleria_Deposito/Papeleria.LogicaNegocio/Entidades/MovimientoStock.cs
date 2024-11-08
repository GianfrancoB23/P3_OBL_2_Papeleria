﻿using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaNegocio.Excepciones.MovimientoStock;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class MovimientoStock : IEntity, IValidable<MovimientoStock>
    {
        public int ID { get; set; }
        public DateTime FecHorMovRealizado { get; set; }
        public Articulo Articulo { get; set; }
        public TipoMovimiento Movimiento { get; set; }
        public Usuario UsuarioRealizaMovimiento { get; set; }
        public int CtdUnidadesXMovimiento { get; set; }

        public MovimientoStock(Articulo articulo, TipoMovimiento movimiento, Usuario usuarioRealizaMovimiento, int ctdUnidadesXMovimiento)
        {
            FecHorMovRealizado = DateTime.Now;
            Articulo = articulo;
            Movimiento = movimiento;
            UsuarioRealizaMovimiento = usuarioRealizaMovimiento;
            CtdUnidadesXMovimiento = ctdUnidadesXMovimiento;
        }

        public MovimientoStock()
        {
            
        }

        public void esValido()
        {
            if (Articulo == null)
            { 
                throw new MovimientoStockNuloException("Articulo no puede ser nulo");
            }
            if (Movimiento == null)
            {
                throw new MovimientoStockNuloException("Movimiento no puede ser nulo");
            }
            if (UsuarioRealizaMovimiento == null)
            {
                throw new MovimientoStockNuloException("Usuario no puede ser nulo");
            }
            if (CtdUnidadesXMovimiento == null)
            {
                throw new MovimientoStockNuloException("Cantidad de unidades a mover no puede ser nulo");
            }
        }

        public void ModificarDatos(MovimientoStock obj)
        {
            FecHorMovRealizado = obj.FecHorMovRealizado;
            Articulo = obj.Articulo;
            Movimiento = obj.Movimiento;
            UsuarioRealizaMovimiento = obj.UsuarioRealizaMovimiento;
            CtdUnidadesXMovimiento = obj.CtdUnidadesXMovimiento;
        }

    }
}
