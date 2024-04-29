using AutoMapper;
using Molecule.Application.Bouquets.Queries.GetBouquetDetails;
using Molecule.Application.Flours.Queries.GetFlourDetails;
using Molecule.Persistence;
using Notes.Tests.Common;
using Shouldly;

namespace Molecule.Tests.Bouquets.Queries
{
    [Collection("QueryCollection")]
    public class GetBouquetDetailsQueryHandlerTests
    {
        private readonly MoleculeDbContext Context;
        private readonly IMapper Mapper;

        public GetBouquetDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBouquetDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBouquetDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetBouquetDetailsQuery
                {
                    Id = Guid.Parse("AC2818E0-FF27-46D7-9183-CC2D39E3130F")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BouquetDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.Description.ShouldBe("Description 2");

        }
    }
}
