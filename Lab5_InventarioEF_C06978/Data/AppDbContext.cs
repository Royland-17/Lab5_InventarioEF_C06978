using Lab5_InventarioEF_C06978.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5_InventarioEF_C06978.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
    }
}