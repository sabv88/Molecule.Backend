using AutoMapper;
using Molecule.Application.Bouquets.Queries.GetBouquetList;
using Molecule.Application.Flours.Queries.GetFlourList;
using Molecule.Persistence;
using Notes.Tests.Common;
using Shouldly;

namespace Molecule.Tests.Bouquets.Queries
{
    [Collection("QueryCollection")]
    public class GetBouquetListQueryHandlerTests
    {
        private readonly MoleculeDbContext Context;
        private readonly IMapper Mapper;

        public GetBouquetListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBouquetListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBouquetListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetBouquetListQuery(),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BouquetListVm>();
            result.Bouquets.Count.ShouldBe(4);
        }
    }
}
