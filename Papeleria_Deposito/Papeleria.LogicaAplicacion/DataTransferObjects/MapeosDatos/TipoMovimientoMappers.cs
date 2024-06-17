using Empresa.LogicaDeNegocio.Entidades;
using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.TipoMovimientos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.TipoMovimiento;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos
{
    public class TipoMovimientoMappers
    {
        public static TipoMovimiento FromDto(TipoMovimientoDTO dto)
        {
            if (dto == null) throw new TipoMovimientoNuloException(nameof(dto));
            return new TipoMovimiento(dto.Nombre);
        }
        public static TipoMovimiento FromDtoUpdate(TipoMovimientoDTO dto)
        {
            if (dto == null) throw new TipoMovimientoNuloException(nameof(dto));
            var tipoMovimiento = new TipoMovimiento(dto.Nombre);
            tipoMovimiento.ID = dto.ID;
            return tipoMovimiento;
        }
        public static TipoMovimientoDTO ToDto(TipoMovimiento tipMov)
        {
            if (tipMov == null) throw new TipoMovimientoNuloException();
            return new TipoMovimientoDTO()
            {
                ID = tipMov.ID,
                Nombre = tipMov.Nombre
            };
        }

        public static IEnumerable<TipoMovimientoDTO> FromLista(IEnumerable<TipoMovimiento> tipoMovimientos)
        {
            if (tipoMovimientos == null)
            {
                throw new TipoMovimientoNuloException("La lista de usuarios no puede ser nula");
            }
            return (IEnumerable<TipoMovimientoDTO>)tipoMovimientos.Select(tipoMovimiento => ToDto(tipoMovimiento));
        }
    }
}

