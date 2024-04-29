using AutoMapper;
using Molecule.Application.Flours.Queries.GetFlourList;
using Molecule.Persistence;
using Notes.Tests.Common;
using Shouldly;

namespace Molecule.Tests.Flours.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteListQueryHandlerTests
    {
        private readonly MoleculeDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetFlourListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetFlourListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetFlourListQuery(),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<FlourListVm>();
            result.Flours.Count.ShouldBe(4);
        }
    }
}
