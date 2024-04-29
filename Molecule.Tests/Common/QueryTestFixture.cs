using AutoMapper;
using Molecule.Application.Common.Mappings;
using Molecule.Application.Interfaces;
using Molecule.Persistence;
using Molecule.Tests.Common;

namespace Notes.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public MoleculeDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = MoleculeContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IMoleculeDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            MoleculeContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}