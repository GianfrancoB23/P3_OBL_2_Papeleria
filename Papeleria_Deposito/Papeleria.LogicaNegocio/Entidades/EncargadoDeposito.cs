﻿using Empresa.LogicaDeNegocio.Sistema;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class EncargadoDeposito : Usuario
    {
        public EncargadoDeposito()
        {
        }

        public EncargadoDeposito(string email, string nombre, string apellido, string contrasenia) : base(email, nombre, apellido, contrasenia)
        {
            this.Email = new EmailUsuario(email);
            this.NombreCompleto = new NombreCompleto(nombre, apellido);
            this.Contrasenia = new ContraseniaUsuario(contrasenia);
            esValido();
        }
        public override void ModificarContraseña(string contrasenia)
        {
            base.ModificarContraseña(contrasenia);
        }
        public override void ModificarDatos(EncargadoDeposito usu)
        {
            base.ModificarDatos(usu);
        } 
        
    }
}
