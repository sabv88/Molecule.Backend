using MediatR;

namespace Molecule.Application.Flours.Commands.DeleteFlour
{
    public class DeleteFlourCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
