using MediatR;
using Molecule.Application.Interfaces;
using Molecule.Domain;

namespace Molecule.Application.Flours.Commands.CreateFlour
{
    public class CreateFlourCommandHandler: IRequestHandler<CreateFlourCommand, Guid>
    {
        private readonly IMoleculeDbContext _dbContext;

        public CreateFlourCommandHandler(IMoleculeDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateFlourCommand request,
            CancellationToken cancellationToken)
        {
            var flour = new Flour
            {
                Name = request.Name,
                Id = Guid.NewGuid()
            };

            await _dbContext.Flours.AddAsync(flour, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return flour.Id;
        }
    }
}
