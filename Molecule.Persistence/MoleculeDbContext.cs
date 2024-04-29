using Microsoft.EntityFrameworkCore;
using Molecule.Application.Interfaces;
using Molecule.Domain;
using Molecule.Persistence.EntityTypeConfiguration;

namespace Molecule.Persistence
{
    public class MoleculeDbContext : DbContext, IMoleculeDbContext
    {
        public DbSet<Flour> Flours { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }

        public MoleculeDbContext(DbContextOptions<MoleculeDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlourConfiguration());
            modelBuilder.ApplyConfiguration(new BouquetConfiguration());
            modelBuilder.Entity<Bouquet>()
                    .HasMany(e => e.Flours)
                    .WithMany(e => e.Bouquets)
                    .UsingEntity<BouquetFlour>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
