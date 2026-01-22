using Microsoft.EntityFrameworkCore;

namespace kASHOP.Data
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //database production
            optionsBuilder.UseSqlServer("Server=db38630.public.databaseasp.net; Database=db38630; User Id=db38630; Password=yZ-79eH@!D4s; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;  ");
            //Development Database
            //optionsBuilder.UseSqlServer("Server=.;Database=KAShopDB;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }
}
