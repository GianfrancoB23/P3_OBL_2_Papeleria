namespace Papeleria.MVC.Models
{
    public class LoginToken
    {
        public int UserId { get; set; } 
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
    }
}
