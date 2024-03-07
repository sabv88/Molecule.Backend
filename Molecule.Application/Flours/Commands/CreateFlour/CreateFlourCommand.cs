using MediatR;

namespace Molecule.Application.Flours.Commands.CreateFlour
{
    public class CreateFlourCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
