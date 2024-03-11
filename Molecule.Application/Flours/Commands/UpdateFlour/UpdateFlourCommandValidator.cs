using FluentValidation;

namespace Molecule.Application.Flours.Commands.UpdateFlour
{
    public class UpdateFlourCommandValidator : AbstractValidator<UpdateFlourCommand>
    {
        public UpdateFlourCommandValidator()
        {
            RuleFor(updateFlourCommand => updateFlourCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateFlourCommand => updateFlourCommand.Name)
                .NotEmpty().MaximumLength(250);
        }
    }
}
