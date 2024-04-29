using Molecule.Application.Bouquets.Commands.DeleteBouquet;
using Molecule.Application.Common.Exceptions;
using Molecule.Tests.Common;
using Notes.Tests.Common;

namespace Molecule.Tests.Bouquets.Commands
{
    public class DeleteBouquetCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteBouquetCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteBouquetCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteBouquetCommand
            {
                Id = MoleculeContextFactory.BouquetIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Bouquets.SingleOrDefault(flour =>
                flour.Id == MoleculeContextFactory.BouquetIdForDelete));
        }

        [Fact]
        public async Task DeleteBouquetCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteBouquetCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteBouquetCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}