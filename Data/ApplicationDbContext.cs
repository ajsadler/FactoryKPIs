using Microsoft.EntityFrameworkCore;

namespace FactoryKPIs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProductionOrder> ProductionOrders { get; set; }
    }
}