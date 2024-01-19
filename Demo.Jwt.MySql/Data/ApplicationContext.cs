using Microsoft.EntityFrameworkCore;
using Demo.Jwt.MySql.Models;

namespace Demo.Jwt.MySql.Data
{
    public class ApplicationContext : DbContext
    {
        private DbSet<User> users;

        public DbSet<User> GetUsers()
        {
            return users;
        }

        public void SetUsers(DbSet<User> value)
        {
            users = value;
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
               public DbSet<User>? Users { get; set; }
    }
}
