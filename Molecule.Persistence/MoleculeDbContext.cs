using Microsoft.EntityFrameworkCore;
using Molecule.Application.Interfaces;
using Molecule.Domain;
using Molecule.Persistence.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molecule.Persistence
{
    internal class MoleculeDbContext : DbContext, IMoleculeDbContext
    {
        public DbSet<Flour> Flours { get; set; }

        public MoleculeDbContext(DbContextOptions<MoleculeDbContext> dbContextOptions) : base(dbContextOptions) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlourConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
