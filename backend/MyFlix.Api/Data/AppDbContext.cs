using Microsoft.EntityFrameworkCore;
using MyFlix.Api.Models;

namespace MyFlix.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    
    }
}
