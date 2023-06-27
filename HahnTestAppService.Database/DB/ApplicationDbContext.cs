
using HahnTestAppService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HahnTestAppService.Repository.DB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CarPart> Parts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //CarPart
            modelBuilder.Entity<CarPart>().HasKey(p => p.Id);
            modelBuilder.Entity<CarPart>().Ignore(p => p.AVAILABLE_QUANTITY);
            modelBuilder.Entity<Manufacturer>().HasKey(p => p.Id);
            modelBuilder.Entity<Brand>().HasKey(p => p.Id);
            modelBuilder.Entity<Manufacturer>()
                .HasOne(p => p.Part)
                .WithOne(x => x.Manufacturer)
                .HasForeignKey<Manufacturer>(x => x.PartId);
            modelBuilder.Entity<Brand>()
            .HasOne(s => s.Part)
            .WithMany(g => g.Brands)
            .HasForeignKey(s => s.PartId);


        }
    }
}
