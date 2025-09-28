using Microsoft.EntityFrameworkCore;
using ToDoListBackend.Models;

namespace ToDoListBackend.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<ToDoItems> ToDoItems { get; set; }
        public DbSet<Users> Users { get; set; }
    } 
}
