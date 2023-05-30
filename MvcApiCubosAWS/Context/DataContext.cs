using Microsoft.EntityFrameworkCore;
using MvcApiCubosAWS.Models;

namespace MvcApiCubosAWS.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cubo> Cubos { get; set; }
    }
}
