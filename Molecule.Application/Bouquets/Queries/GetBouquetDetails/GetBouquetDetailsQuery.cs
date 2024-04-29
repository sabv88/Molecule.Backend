using MediatR;

namespace Molecule.Application.Bouquets.Queries.GetBouquetDetails
{
    public class GetBouquetDetailsQuery : IRequest<BouquetDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
