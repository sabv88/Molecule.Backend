using MediatR;

namespace Molecule.Application.Flours.Queries.GetFlourDetails
{
    public class GetFlourDetailsQuery : IRequest<FlourDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
