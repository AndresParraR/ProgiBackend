using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<FeeType> FeeType { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<VehicleTotal> VehicleTotal { get; set; }
    }
}