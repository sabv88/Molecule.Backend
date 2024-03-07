using MediatR;

namespace Molecule.Application.Flours.Commands.UpdateFlour
{
    public class UpdateFlourCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
