using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApp.Angular.Database
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Reteta> Retetas { get; set; }
        public DbSet<Set_ingrediente> SetIngredientes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }
    }
}
