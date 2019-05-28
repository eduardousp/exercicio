using Microsoft.EntityFrameworkCore;

namespace apibe.Models
{
    public class AllContext : DbContext
    {
        public AllContext(DbContextOptions<AllContext> options)
            : base(options)
        {
        }

        public DbSet<Disco> Discos { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}
