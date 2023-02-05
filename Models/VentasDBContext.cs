using Microsoft.EntityFrameworkCore;

namespace Softtek.Models
{
    public class VentasDBContext : DbContext
    {
        public VentasDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Ventas> Ventas { get; set; }  

    }
}
