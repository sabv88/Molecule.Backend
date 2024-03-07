using MediatR;
using Microsoft.EntityFrameworkCore;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Interfaces;
using Molecule.Domain;

namespace Molecule.Application.Flours.Commands.UpdateFlour
{
    public class UpdateFlourCommandHandler : IRequestHandler<UpdateFlourCommand, Unit>
    {
        private readonly IMoleculeDbContext _dbContext;

        public UpdateFlourCommandHandler(IMoleculeDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFlourCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Flours.FirstOrDefaultAsync(note =>
                    note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Flour), request.Id);
            }

            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
