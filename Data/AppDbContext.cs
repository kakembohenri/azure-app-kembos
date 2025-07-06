using Microsoft.EntityFrameworkCore;

namespace azure_app_kembos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        // Define DbSets for your entities here, e.g.:
        public DbSet<Person> Persons { get; set; }
    }
   
}
