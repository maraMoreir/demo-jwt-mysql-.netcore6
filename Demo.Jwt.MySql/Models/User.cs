namespace Demo.Jwt.MySql.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}


// dotnet ef migrations add NomeDaMigracao
// dotnet ef database update
