using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Molecule.Application.Common.Exceptions;
using Molecule.Application.Flours.Queries.GetFlourDetails;
using Molecule.Application.Interfaces;
using Molecule.Domain;

namespace Molecule.Application.Bouquets.Queries.GetBouquetDetails
{
    public class GetBouquetDetailsQueryHandler : IRequestHandler<GetBouquetDetailsQuery, BouquetDetailsVm>
    {
        private readonly IMoleculeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBouquetDetailsQueryHandler(IMoleculeDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BouquetDetailsVm> Handle(GetBouquetDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Bouquets
                .FirstOrDefaultAsync(bouquet =>
                bouquet.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Bouquet), request.Id);
            }

            return _mapper.Map<BouquetDetailsVm>(entity);
        }
    }
}
