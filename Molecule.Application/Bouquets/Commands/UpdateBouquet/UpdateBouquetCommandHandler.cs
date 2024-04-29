using MediatR;
using Microsoft.EntityFrameworkCore;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Interfaces;
using Molecule.Domain;

namespace Molecule.Application.Bouquets.Commands.UpdateBouquet
{
    public class UpdateBouquetCommandHandler : IRequestHandler<UpdateBouquetCommand, Unit>
    {
        private readonly IMoleculeDbContext _dbContext;

        public UpdateBouquetCommandHandler(IMoleculeDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateBouquetCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Bouquets.FirstOrDefaultAsync(note =>
                    note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Flour), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Flours = request.Flours.Select(flour => new Flour
            {
                Id = flour.Id,
                Name = flour.Name,
            }).ToList();

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}