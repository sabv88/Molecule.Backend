using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Molecule.Application.Bouquets.Commands.CreateBouquet;
using Molecule.Application.Flours.Queries.GetFlourList;
using Molecule.Domain;
using Molecule.Persistence;
using Notes.Tests.Common;
using System.Threading;

namespace Molecule.Tests.Bouquets.Commands
{
    public class CreateBouquetrCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateBouquetCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateBouquetCommandHandler(Context);
            var bouquetName = "BouquetName";
            var bouquetDescription = "bouquetDescription";
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
            var bouquetId = await handler.Handle(
                new CreateBouquetCommand
                {
                    Title = bouquetName,
                    Description = bouquetDescription,
                    Flours = flours
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Bouquets.SingleOrDefaultAsync(bouquet =>
                    bouquet.Id == bouquetId && bouquet.Title == bouquetName));
        }
    }
}