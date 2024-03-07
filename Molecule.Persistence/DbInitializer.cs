using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molecule.Persistence
{
    internal class DbInitializer
    {
        public static void Initialize(MoleculeDbContext context)
        { 
            context.Database.EnsureCreated();
        }
    }
}
