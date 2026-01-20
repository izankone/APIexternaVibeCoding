using Microsoft.EntityFrameworkCore;
using APIExternaVibeCoding.Models;

namespace APIExternaVibeCoding.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Estas son las tablas que se crearán en SQLite
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}