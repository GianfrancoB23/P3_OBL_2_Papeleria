﻿using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.MovimientoStock;
using Papeleria.LogicaAplicacion.DataTransferObjects.MapeosDatos;
using Papeleria.LogicaAplicacion.InterfacesCasoDeUsoGeneral;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Movimientos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Movimiento
{
    public class BuscarMovimiento : IGetMovimiento
    {

        private IRepositorioMovimientoStock _repoMov;
        private IRepositorioArticulo _repoArt;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioTipoMovimiento _repoTipoMovimiento;
        public BuscarMovimiento(IRepositorioMovimientoStock repo, IRepositorioArticulo repoArt, IRepositorioUsuario repoUsuario, IRepositorioTipoMovimiento repoTipoMovimiento)
        {
            _repoMov = repo; _repoArt = repoArt;
            _repoUsuario = repoUsuario;
            _repoTipoMovimiento = repoTipoMovimiento;
        }
        public MovimientoStock Get(int id)
        {
            return _repoMov.GetById(id);
        }

        public IEnumerable<MovimientoStockDTO> GetAll()
        {
            var movimientos = _repoMov.GetAll();
            if (movimientos == null || movimientos.Count() == 0)
            {
                throw new Exception("No hay autores registrados");
            }
            return MovimientoStockMappers.FromLista(movimientos);
        }

        public MovimientoStockDTO GetByDTO(int id)
        {
            var movimiento = _repoMov.GetById(id);
            if (movimiento == null)
            {
                throw new Exception("Articulo no encontrado con el ID especificado"); // Handler de exception
            }
            var ret = MovimientoStockMappers.ToDto(movimiento);
            return ret;
        }
    }
}
