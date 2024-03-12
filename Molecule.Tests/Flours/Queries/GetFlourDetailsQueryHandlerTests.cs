

using AutoMapper;
using Molecule.Application.Flours.Queries.GetFlourDetails;
using Molecule.Persistence;
using Molecule.Tests.Common;
using Notes.Tests.Common;
using Shouldly;

namespace Molecule.Tests.Flours.Queries
{
    [Collection("QueryCollection")]
    public class GetFlourDetailsQueryHandlerTests
    {
        private readonly MoleculeDbContext Context;
        private readonly IMapper Mapper;

        public GetFlourDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetFlourDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetFlourDetailsQuery
                {
                    Id = Guid.Parse("A88661F1-5516-445E-8C28-BBC2549EDAB8")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<FlourDetailsVm>();
            result.Name.ShouldBe("Name2");
        }
    }
}
