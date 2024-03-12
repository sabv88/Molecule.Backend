using Molecule.Persistence;
using Molecule.Tests.Common;

namespace Notes.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly MoleculeDbContext Context;

        public TestCommandBase()
        {
            Context = FloursContextFactory.Create();
        }

        public void Dispose()
        {
            FloursContextFactory.Destroy(Context);
        }
    }
}