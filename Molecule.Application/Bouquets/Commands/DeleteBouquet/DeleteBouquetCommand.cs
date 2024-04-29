using MediatR;

namespace Molecule.Application.Bouquets.Commands.DeleteBouquet
{
    public class DeleteBouquetCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}