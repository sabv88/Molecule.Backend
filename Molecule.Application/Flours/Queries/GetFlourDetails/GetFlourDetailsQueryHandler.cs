using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Interfaces;
using Molecule.Domain;


namespace Molecule.Application.Flours.Queries.GetFlourDetails
{
    public class GetFlourDetailsQueryHandler : IRequestHandler<GetFlourDetailsQuery, FlourDetailsVm>
    {
        private readonly IMoleculeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFlourDetailsQueryHandler(IMoleculeDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FlourDetailsVm> Handle(GetFlourDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Flours
                .FirstOrDefaultAsync(flour =>
                flour.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Flour), request.Id);
            }

            return _mapper.Map<FlourDetailsVm>(entity);
        }
    }
}
