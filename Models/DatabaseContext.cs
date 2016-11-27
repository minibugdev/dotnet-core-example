using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace UserService.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public List<Role> Roles { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}