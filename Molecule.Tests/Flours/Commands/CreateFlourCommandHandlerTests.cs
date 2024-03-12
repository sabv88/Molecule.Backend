using Microsoft.EntityFrameworkCore;
using Molecule.Application.Flours.Commands.CreateFlour;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands
{
    public class CreateFlourCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateFlourCommandHandler(Context);
            var flourName = "note name";

            // Act
            var noteId = await handler.Handle(
                new CreateFlourCommand
                {
                    Name = flourName,
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Flours.SingleOrDefaultAsync(note =>
                    note.Id == noteId && note.Name == flourName));
        }
    }
}