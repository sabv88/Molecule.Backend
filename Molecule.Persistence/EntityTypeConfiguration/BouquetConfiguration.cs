using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Molecule.Domain;

namespace Molecule.Persistence.EntityTypeConfiguration
{
    internal class BouquetConfiguration : IEntityTypeConfiguration<Bouquet>
    {
        public void Configure(EntityTypeBuilder<Bouquet> builder)
        {
            builder.HasKey(Bouquet => Bouquet.Id);
            builder.HasIndex(Bouquet => Bouquet.Id).IsUnique();
        }
    }
}
