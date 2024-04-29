using Notes.Tests.Common;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Flours.Commands.DeleteFlour;
using Molecule.Tests.Common;

namespace Notes.Tests.Notes.Commands
{
    public class DeleteFlourCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteFlourCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteFlourCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteFlourCommand
            {
                Id = MoleculeContextFactory.FlourIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Flours.SingleOrDefault(flour =>
                flour.Id == MoleculeContextFactory.FlourIdForDelete));
        }

        [Fact]
        public async Task DeleteFlourCommandHandler_FailOnWrongId()
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