

using Empresa.LogicaDeNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades.ValueObjects.Usuario;
using Papeleria.LogicaNegocio.Excepciones.Usuario;
using Papeleria.LogicaNegocio.Excepciones.Usuario.UsuarioExcepcions.Constrasenia;
using Papeleria.LogicaNegocio.InterfacesEntidades;

namespace Empresa.LogicaDeNegocio.Sistema
{
    public abstract class Usuario : IValidable<Usuario>, IEquatable<Usuario>, IEntity
	{
        public int ID { get; set; }
        public EmailUsuario Email{ get; set; }

		public NombreCompleto NombreCompleto{ get; set; }
		public ContraseniaUsuario Contrasenia{ get; set; }

        public Usuario(string email, string nombre, string apellido, string contrasenia)
        {
            this.Email = new EmailUsuario(email);
            this.NombreCompleto = new NombreCompleto(nombre, apellido);
            this.Contrasenia = new ContraseniaUsuario(contrasenia);
            esValido();
        }
        public Usuario()
        {
            
        }
        public bool Equals(Usuario? other)
        {
            if (other == null)
                throw new UsuarioNoValidoExcepcion("Debe incluir el autor a comparar");

            return this.ID == other.ID || this.Email == other.Email;
        }

        public void esValido()
        {
            esValido(this);
        }

        public void esValido(Usuario usuario)
        {
            if(Email == null) {
                throw new UsuarioNoValidoExcepcion("El email no puede ser nulo para crear el usuario.");
            }
            if(NombreCompleto == null) {
                throw new UsuarioNoValidoExcepcion("El nombre y apellido no puede ser nulo para crear el usuario.");
            }
            if(Contrasenia == null) {
                throw new UsuarioNoValidoExcepcion("La contraseņa no puede ser nula para crear el usuario.");
            }
        }
        public virtual void ModificarContraseņa(string contrasenia)
        {
            if (contrasenia == null)
                throw new ContraseniaNuloException("La contraseņa no puede ser nula.");
            this.Contrasenia = new ContraseniaUsuario(contrasenia);
        }

        public virtual void ModificarDatos(Usuario usu) {
            if (usu.Contrasenia == null)
                throw new ContraseniaNuloException("La contraseņa no puede ser nula.");
            if (usu.NombreCompleto == null)
                throw new ContraseniaNuloException("La contraseņa no puede ser nula.");
            this.NombreCompleto = usu.NombreCompleto;
            this.Contrasenia = usu.Contrasenia;
        }
        public virtual void ModificarDatos(EncargadoDeposito usu)
        {
            if (usu.Contrasenia == null)
                throw new ContraseniaNuloException("La contraseņa no puede ser nula.");
            if (usu.NombreCompleto == null)
                throw new ContraseniaNuloException("La contraseņa no puede ser nula.");
            this.NombreCompleto = usu.NombreCompleto;
            this.Contrasenia = usu.Contrasenia;
        }
    }

}

