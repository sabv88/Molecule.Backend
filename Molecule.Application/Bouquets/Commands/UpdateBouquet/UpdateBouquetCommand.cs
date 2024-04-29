using MediatR;
using Molecule.Application.Flours.Commands.UpdateFlour;
using Molecule.Application.Flours.Queries.GetFlourList;
using Molecule.Domain;

namespace Molecule.Application.Bouquets.Commands.UpdateBouquet
{
    public class UpdateBouquetCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<FlourLookupDto> Flours { get; set; } = new();

    }
}
