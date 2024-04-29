using FluentValidation;

namespace Molecule.Application.Bouquets.Commands.DeleteBouquet
{
    internal class DeleteBouquetCommandValidator : AbstractValidator<DeleteBouquetCommand>
    {
        public DeleteBouquetCommandValidator()
        {
            RuleFor(deleteBouquetCommand => deleteBouquetCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
