using Microsoft.EntityFrameworkCore;
using parking_banckend_api.Models;


namespace parking_backend_api.Data
{
    public class ParkingLotDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public ParkingLotDbContext(DbContextOptions<ParkingLotDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Vehicle>()
            // .HasOne(b => b.Company) 
            // .WithMany(a => a.Vehiculos) 
            // .HasForeignKey(b => b.CompanyId); 
        }
    }
}
