using FluentValidation;

namespace Molecule.Application.Flours.Commands.CreateFlour
{
    public class CreateFlourCommandValidator : AbstractValidator<CreateFlourCommand>
    {
        public CreateFlourCommandValidator()
        {
            RuleFor(createFlourCommand =>
                createFlourCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
