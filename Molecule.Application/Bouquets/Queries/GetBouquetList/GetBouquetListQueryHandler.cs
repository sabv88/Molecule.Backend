using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Molecule.Application.Interfaces;

namespace Molecule.Application.Bouquets.Queries.GetBouquetList
{
    public class GetBouquetListQueryHandler : IRequestHandler<GetBouquetListQuery, BouquetListVm>
    {
        private readonly IMoleculeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBouquetListQueryHandler(IMoleculeDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BouquetListVm> Handle(GetBouquetListQuery request,
            CancellationToken cancellationToken)
        {
            var bouquetQuery = await _dbContext.Bouquets
                .ProjectTo<BouquetLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BouquetListVm { Bouquets = bouquetQuery };
        }
    }
}