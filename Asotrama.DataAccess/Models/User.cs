namespace Asotrama.DataAccess.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? Name  { get; set; }
        public string? Password { get; set; }
        public string? FirstLastname { get; set; }
        public string? SecondLastName { get; set; }
        public string? Email { get; set;}
        public Role? Role { get; set; }
        public Subsidiary? Subsidiary { get; set; }
        public string? Status { get; set; }
    }
}
