using Microsoft.EntityFrameworkCore;
using Molecule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molecule.Application.Interfaces
{
    public interface IMoleculeDbContext
    {
        DbSet<Flour> Flours { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
