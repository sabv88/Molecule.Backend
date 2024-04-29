using MediatR;
using Molecule.Application.Interfaces;
using Molecule.Domain;

namespace Molecule.Application.Bouquets.Commands.CreateBouquet
{
    public class CreateBouquetCommandHandler : IRequestHandler<CreateBouquetCommand, Guid>
    {
        private readonly IMoleculeDbContext _dbContext;

        public CreateBouquetCommandHandler(IMoleculeDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateBouquetCommand request,
            CancellationToken cancellationToken)
        {
            var bouquet = new Bouquet
            {
                Title = request.Title,
                Id = Guid.NewGuid(),
                Flours = request.Flours.Select(flour => new Flour 
                {
                    Id = flour.Id,
                    Name = flour.Name,
                }).ToList(),
                Description = request.Description
            };

            await _dbContext.Bouquets.AddAsync(bouquet, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return bouquet.Id;
        }
    }
}
