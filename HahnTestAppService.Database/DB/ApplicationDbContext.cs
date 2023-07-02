
using HahnTestAppService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HahnTestAppService.Repository.DB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CarPart> Parts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<PartType> PartTypes { get; set; }
        public DbSet<PartBrand> PartBrands { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Part

            modelBuilder.Entity<CarPart>().HasKey(p => p.Id);
            modelBuilder.Entity<CarPart>().Ignore(p => p.AVAILABLE_QUANTITY);

            modelBuilder.Entity<CarPart>()
                .HasOne(p => p.PartType)
                .WithMany(x => x.Parts)
                .HasForeignKey(x => x.PartTypeId);
            #endregion
            #region Brand

            modelBuilder.Entity<Brand>().HasKey(p => p.Id);
            #endregion
            #region Manufacturer

            modelBuilder.Entity<Manufacturer>().HasKey(p => p.Id);
            modelBuilder.Entity<CarPart>()
                .HasOne(p => p.Manufacturer)
                .WithMany(x => x.Part)
                .HasForeignKey(x=>x.ManufacturerId);
            #endregion
            #region PartType

            modelBuilder.Entity<PartType>().HasKey(p => p.Id);
            #endregion
            #region PartBrand
            modelBuilder.Entity<PartBrand>().HasKey(sc => new { sc.PartId, sc.BrandId });

            modelBuilder.Entity<PartBrand>()
                .HasOne<CarPart>(sc => sc.Part)
                .WithMany(s => s.partBrands)
                .HasForeignKey(sc => sc.PartId);


            modelBuilder.Entity<PartBrand>()
                .HasOne<Brand>(sc => sc.Brand)
                .WithMany(s => s.partBrands)
                .HasForeignKey(sc => sc.BrandId);
            #endregion
        }
    }
}
