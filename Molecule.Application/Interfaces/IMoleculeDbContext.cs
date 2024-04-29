using Microsoft.EntityFrameworkCore;
using Molecule.Domain;

namespace Molecule.Application.Interfaces
{
    public interface IMoleculeDbContext
    {
        DbSet<Flour> Flours { get; set; }
        DbSet<Bouquet> Bouquets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
