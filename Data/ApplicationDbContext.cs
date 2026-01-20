using Microsoft.EntityFrameworkCore;

namespace kASHOP.Data
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=KAShopDB;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }
}
