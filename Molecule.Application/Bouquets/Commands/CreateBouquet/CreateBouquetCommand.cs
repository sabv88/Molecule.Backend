using MediatR;
using Molecule.Application.Flours.Commands.UpdateFlour;
using Molecule.Application.Flours.Queries.GetFlourList;

namespace Molecule.Application.Bouquets.Commands.CreateBouquet
{
    public class CreateBouquetCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<FlourLookupDto> Flours { get; set; } = new();
    }
}