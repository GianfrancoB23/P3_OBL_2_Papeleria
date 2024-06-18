using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Email;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.Excepciones.TipoMovimiento;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.TipoMovimientos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.TipoMovimientos;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.TipoMovimientos
{
    public class AltaTipoMovimiento : IAltaTiposMovimientos
    {
        private IRepositorioTipoMovimiento _repoTipoMovimiento;

        public AltaTipoMovimiento(IRepositorioTipoMovimiento repo)
        {
            _repoTipoMovimiento = repo;
        }

        public void Ejecutar(TipoMovimientoDTO dto)
        {
            if (dto == null)
                throw new TipoMovimientoNuloException("No han llegado datos.");

            bool emailExistente = _repoTipoMovimiento.ExisteTipoMovimientoXNombre(dto.Nombre);
            if (emailExistente)
            {
                throw new TipoMovimientoNoValidoException("El nombre del tipo de movimiento ya está en uso.");
            }
            else
            {
                TipoMovimiento tipMov = TipoMovimientoMappers.FromDto(dto);
                _repoTipoMovimiento.Add(tipMov);
            }
        }
    }
}
