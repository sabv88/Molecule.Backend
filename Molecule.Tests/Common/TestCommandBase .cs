using Molecule.Persistence;
using Molecule.Tests.Common;

namespace Notes.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly MoleculeDbContext Context;

        public TestCommandBase()
        {
            Context = MoleculeContextFactory.Create();
        }

        public void Dispose()
        {
            MoleculeContextFactory.Destroy(Context);
        }
    }
}