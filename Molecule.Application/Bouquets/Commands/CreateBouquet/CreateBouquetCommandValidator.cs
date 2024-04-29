using FluentValidation;

namespace Molecule.Application.Bouquets.Commands.CreateBouquet
{
    internal class CreateBouquetCommandValidator : AbstractValidator<CreateBouquetCommand>
    {
        public CreateBouquetCommandValidator()
        {
            RuleFor(createFlourCommand =>
                createFlourCommand.Title).NotEmpty().MaximumLength(50);
            RuleFor(createFlourCommand =>
                createFlourCommand.Description).NotEmpty().MaximumLength(250);
            RuleFor(createFlourCommand =>
                createFlourCommand.Flours).NotEmpty();
        }
    }
}