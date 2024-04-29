using Microsoft.EntityFrameworkCore;
using Molecule.Application.Bouquets.Commands.UpdateBouquet;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Flours.Queries.GetFlourList;
using Molecule.Domain;
using Molecule.Tests.Common;
using Notes.Tests.Common;
using System.Linq;

namespace Molecule.Tests.Bouquets.Commands
{
    public class UpdateBouquetCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateBouquetCommandHandler(Context);
            var updatedTitle = "new title";
            var updatedDescription = "new description";
            var flours = new List<FlourLookupDto>
            {
               new FlourLookupDto
               {
                   Id = Guid.NewGuid(),
                   Name = "Name1",
               },
                new FlourLookupDto
               {
                   Id = Guid.NewGuid(),
                   Name = "Name2",
               },
                 new FlourLookupDto
               {
                   Id = Guid.NewGuid(),
                   Name = "Name3",
               }

            };
            // Act
            await handler.Handle(new UpdateBouquetCommand
            {
                Id = MoleculeContextFactory.BouquetIdForUpdate,
                Title = updatedTitle,
                Description = updatedDescription,
                Flours = flours
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Bouquets.SingleOrDefaultAsync(bouquet =>
                bouquet.Id == MoleculeContextFactory.BouquetIdForUpdate &&
                bouquet.Title == updatedTitle &&
                bouquet.Description == updatedDescription && bouquet.Flours.SequenceEqual(flours.Select(flour => new Flour
                {
                    Id = flour.Id,
                    Name = flour.Name,
                }).ToList())
                ));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateBouquetCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateBouquetCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}