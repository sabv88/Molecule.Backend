using FluentValidation;
using Molecule.Application.Flours.Queries.GetFlourDetails;

namespace Molecule.Application.Bouquets.Queries.GetBouquetDetails
{
    public class GetBouquetDetailsQueryValidator : AbstractValidator<GetFlourDetailsQuery>
    {
        public GetBouquetDetailsQueryValidator()
        {
            RuleFor(bouquet => bouquet.Id).NotEqual(Guid.Empty);
        }
    }
}
