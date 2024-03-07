using MediatR;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Interfaces;
using Molecule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molecule.Application.Flours.Commands.DeleteFlour
{
    public class DeleteFlourCommandHandler : IRequestHandler<DeleteFlourCommand, Unit>

    {
        private readonly IMoleculeDbContext _dbContext;

        public DeleteFlourCommandHandler(IMoleculeDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteFlourCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Flours
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Flour), request.Id);
            }

            _dbContext.Flours.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
