using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.TipoMovimiento;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class TipoMovimiento : IEntity, IValidable<TipoMovimiento>, IEquatable<TipoMovimiento>
    {
        public int ID { get; set; }
        public String Nombre { get; set; }

        public TipoMovimiento(int iD, string nombre)
        {
            Nombre = nombre;
            esValido();
        }

        public TipoMovimiento()
        {
            
        }

        public void esValido()
        {
            if (Nombre == null) {
                throw new TipoMovimientoNoValidoException("Nombre no puede ser nulo.");
            }
        }

        public void ModificarDatos(TipoMovimiento obj)
        { 
            this.Nombre = obj.Nombre;
        }

        public bool Equals(TipoMovimiento? other)
        {
            if (other == null) return false;
            return this.Nombre == other.Nombre;
        }
    }
}
