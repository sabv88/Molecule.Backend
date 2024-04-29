using MediatR;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Flours.Commands.DeleteFlour;
using Molecule.Application.Interfaces;
using Molecule.Domain;

namespace Molecule.Application.Bouquets.Commands.DeleteBouquet
{
    public class DeleteBouquetCommandHandler : IRequestHandler<DeleteBouquetCommand, Unit>

    {
        private readonly IMoleculeDbContext _dbContext;

        public DeleteBouquetCommandHandler(IMoleculeDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteBouquetCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Bouquets
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Bouquet), request.Id);
            }

            _dbContext.Bouquets.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}