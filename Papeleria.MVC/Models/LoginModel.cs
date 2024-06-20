namespace Papeleria.MVC.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public int Admin { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Contrasenia { get; set; }
        //public string Email { get; set; }
        //public string Contrasenia { get; set; }
    }
}
