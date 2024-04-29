using Microsoft.EntityFrameworkCore;
using Molecule.Application.Flours.Commands.CreateFlour;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands
{
    public class CreateFlourCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateFlourCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateFlourCommandHandler(Context);
            var flourName = "flour name";

            // Act
            var flourId = await handler.Handle(
                new CreateFlourCommand
                {
                    Name = flourName,
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Flours.SingleOrDefaultAsync(flour =>
                    flour.Id == flourId && flour.Name == flourName));
        }
    }
}