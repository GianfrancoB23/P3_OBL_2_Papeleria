using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaNegocio.Excepciones.MovimientoStock;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
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
        public EncargadoDeposito UsuarioRealizaMovimiento { get; set; }
        public int CtdUnidadesXMovimiento { get; set; }

        public MovimientoStock(DateTime fecHorMovRealizado, Articulo articulo, TipoMovimiento movimiento, EncargadoDeposito usuarioRealizaMovimiento, int ctdUnidadesXMovimiento)
        {
            FecHorMovRealizado = fecHorMovRealizado;
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
                throw new MovimientoStockNoValidoException("");
            }
        }

    }
}
