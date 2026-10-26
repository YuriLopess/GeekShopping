using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class PostgresSQLContext : DbContext
    {
        public PostgresSQLContext(DbContextOptions<PostgresSQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}