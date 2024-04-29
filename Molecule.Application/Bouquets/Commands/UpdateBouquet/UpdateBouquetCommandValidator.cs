using FluentValidation;

namespace Molecule.Application.Bouquets.Commands.UpdateBouquet
{
    public class UpdateBouquetCommandValidator : AbstractValidator<UpdateBouquetCommand>
    {
        public UpdateBouquetCommandValidator()
        {
            RuleFor(updateBouquetCommand => updateBouquetCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateBouquetCommand => updateBouquetCommand.Title)
                .NotEmpty().MaximumLength(50);
            RuleFor(updateBouquetCommand => updateBouquetCommand.Description)
                .NotEmpty().MaximumLength(250);
            RuleFor(updateBouquetCommand => updateBouquetCommand.Flours)
                .NotEmpty();
        }
    }
}
