using FluentValidation;

namespace Molecule.Application.Flours.Queries.GetFlourDetails
{
    public class GetFlourDetailsQueryValidator : AbstractValidator<GetFlourDetailsQuery>
    {
        public GetFlourDetailsQueryValidator()
        {
            RuleFor(flour => flour.Id).NotEqual(Guid.Empty);
        }
    }
}
