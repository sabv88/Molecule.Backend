

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Molecule.Application.Interfaces;

namespace Molecule.Application.Flours.Queries.GetFlourList
{
    public class GetFlourListQueryHandler : IRequestHandler<GetFlourListQuery, FlourListVm>
    {
        private readonly IMoleculeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFlourListQueryHandler(IMoleculeDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FlourListVm> Handle(GetFlourListQuery request,
            CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Flours
                .ProjectTo<FlourLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FlourListVm { Flours = notesQuery };
        }
    }
}
