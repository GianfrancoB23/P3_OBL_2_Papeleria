using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaAplicacion.DataTransferObjects.Dtos.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuarios
{
    public interface IGetUsuario
    {
        UsuarioDTO GetByIdDTO(int id);
        Usuario GetById(int id);
    }
}
