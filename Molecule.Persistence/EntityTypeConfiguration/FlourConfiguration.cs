using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Molecule.Domain;

namespace Molecule.Persistence.EntityTypeConfiguration
{
    internal class FlourConfiguration : IEntityTypeConfiguration<Flour>
    {
        public void Configure(EntityTypeBuilder<Flour> builder) 
        { 
            builder.HasKey(Flour=>Flour.Id);
            builder.HasIndex(Flour => Flour.Id).IsUnique();
        }
    }
}
