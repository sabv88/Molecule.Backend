using Notes.Tests.Common;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Flours.Commands.DeleteFlour;
using Molecule.Tests.Common;

namespace Notes.Tests.Notes.Commands
{
    public class DeleteFlourCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteFlourCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteFlourCommand
            {
                Id = FloursContextFactory.FlourIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Flours.SingleOrDefault(flour =>
                flour.Id == FloursContextFactory.FlourIdForDelete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteFlourCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteFlourCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}