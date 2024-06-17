using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Constrasenia;
using Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Email;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Papeleria.LogicaNegocio.Entidades.ValueObjects.Usuario
{
    [ComplexType]
    public record ContraseniaUsuario : IValidable<ContraseniaUsuario>
    {
        public string Valor { get; set; }
        public ContraseniaUsuario(string contrasenia)
        {
            Valor = contrasenia;
            esValido();
        }
        public ContraseniaUsuario()
        {
            
        }
        //public void esValido(string contrasenia) {
        //    if (Valor == null)
        //    {
        //        throw new ContraseniaNuloException("La contrasenia no puede ser nula.");
        //    }
        //    if (Valor.Length < 6)
        //    {
        //        throw new ContraseniaNoValidoException("La contraseña debe contener un largo minimo de 6 caracteres.");
        //    }
        //    if (!Regex.IsMatch(Valor, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;!])[A-Za-z\d.,;!]+$"))
        //    {
        //        throw new ContraseniaNoValidoException("La contraseña debe contener al menos una letra mayúscula, una minúscula, un dígito y un carácter de puntuación: punto, punto y coma, coma, signo de admiración de cierre.");
        //    }
        //}
        public void esValido()
        {
            if (Valor == null)
            {
                throw new ContraseniaNuloException("La contrasenia no puede ser nula.");
            }
            if (Valor.Length < 6)
            {
                throw new ContraseniaNoValidoException("La contraseña debe contener un largo minimo de 6 caracteres.");
            }
            if (!Regex.IsMatch(Valor, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;!])[A-Za-z\d.,;!]+$"))
            {
                throw new ContraseniaNoValidoException("La contraseña debe contener al menos una letra mayúscula, una minúscula, un dígito y un carácter de puntuación: punto, punto y coma, coma, signo de admiración de cierre.");
            }
        }
        public string Encriptar(string contrasenia)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

