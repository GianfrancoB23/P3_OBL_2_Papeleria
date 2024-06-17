using Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Nombre;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papeleria.LogicaNegocio.Entidades.ValueObjects.Usuario
{
    [ComplexType]
    public record NombreCompleto : IValidable<NombreCompleto>
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }

        public NombreCompleto(string nombre, string apellido)
        {
            Nombre = FormatearInicialesMayuscula(nombre);
            Apellido = FormatearInicialesMayuscula(apellido);
            esValido();
        }
        //public void esValido(string nombre, string apellido) {
        //    if (nombre == null || apellido == null)
        //    {
        //        throw new NombreNuloException("El nombre o apellido no pueden ser nulos.");
        //    }
        //    if (nombre.Length <= 2 && !nombre.Any(c => char.IsDigit(c)))
        //    {
        //        throw new NombreNoValidoException($"{nombre}: no es un nombre valido.");
        //    }
        //    if (apellido.Length <= 2 && !apellido.Any(c => char.IsDigit(c)))
        //    {
        //        throw new NombreNoValidoException($"{apellido}: no es un apellido valido.");
        //    }
        //    if (!Regex.IsMatch(nombre, @"^[a-zA-Z]+([' -]?[a-zA-Z]+)*$"))
        //    {
        //        throw new NombreNoValidoException($"{nombre}: no es un nombre valido.");
        //    }
        //    if (!Regex.IsMatch(apellido, @"^[a-zA-Z]+([' -]?[a-zA-Z]+)*$"))
        //    {
        //        throw new NombreNoValidoException($"{apellido}: no es un apellido valido.");
        //    }
        //}
        public static string FormatearInicialesMayuscula(string texto)
        {
            string[] palabras = texto.Split(' ');
            for (int i = 0; i < palabras.Length; i++)
            {
                if (palabras[i].Length > 0)
                {
                    palabras[i] = char.ToUpper(palabras[i][0]) + palabras[i].Substring(1);
                }
            }
            return string.Join(" ", palabras);
        }
        public void esValido()
        {
            if (Nombre == null || Apellido == null) {
                throw new NombreNuloException("El nombre o apellido no pueden ser nulos.");
            }
            if (Nombre.Length <= 2 && !Nombre.Any(c => char.IsDigit(c))){ 
                throw new NombreNoValidoException($"{Nombre}: no es un nombre valido.");
            }
            if (Apellido.Length <= 2 && !Apellido.Any(c => char.IsDigit(c)))
            {
                throw new NombreNoValidoException($"{Apellido}: no es un apellido valido.");
            }
            if (!Regex.IsMatch(Nombre, @"^[a-zA-Z]+([' -]?[a-zA-Z]+)*$")){
                throw new NombreNoValidoException($"{Nombre}: no es un nombre valido.");
            }
            if (!Regex.IsMatch(Apellido, @"^[a-zA-Z]+([' -]?[a-zA-Z]+)*$")){
                throw new NombreNoValidoException($"{Apellido}: no es un apellido valido.");
            }
        }
    }

}

