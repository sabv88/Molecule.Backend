using FluentValidation;

namespace Molecule.Application.Flours.Commands.DeleteFlour
{
    internal class DeleteFlourCommandValidator : AbstractValidator<DeleteFlourCommand>
    {
        public DeleteFlourCommandValidator()
        {
            RuleFor(deleteFlourCommand => deleteFlourCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
