using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulos
{
    public interface IGetArticulo
    {
        ArticuloDTO GetByIdDTO(int id);
        Articulo GetById(int id);
        ArticuloDTO GetArticuloPorCodigo(CodigoProveedorArticulos codigoProveedor);
        IEnumerable<ArticuloDTO> GetArticulosPorNombre(string nombre);
    }
}
