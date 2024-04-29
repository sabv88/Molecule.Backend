using Microsoft.EntityFrameworkCore;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Flours.Commands.UpdateFlour;
using Molecule.Tests.Common;
using Notes.Tests.Common;


namespace Molecule.Tests.Flours.Commands
{
    public class UpdateFlourCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateFlourCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateFlourCommandHandler(Context);
            var updatedName = "new name";

            // Act
            await handler.Handle(new UpdateFlourCommand
            {
                Id = MoleculeContextFactory.FlourIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Flours.SingleOrDefaultAsync(flour =>
                flour.Id == MoleculeContextFactory.FlourIdForUpdate &&
                flour.Name == updatedName));
        }

        [Fact]
        public async Task UpdateFlourCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateFlourCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateFlourCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}