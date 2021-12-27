using Microsoft.EntityFrameworkCore;
using RealEstateGraphQL.Database.Models;

namespace RealEstateGraphQL.Database
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options)
        {

        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
