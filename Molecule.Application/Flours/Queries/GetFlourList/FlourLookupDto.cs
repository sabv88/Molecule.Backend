using AutoMapper;
using Molecule.Application.Common.Mappings;
using Molecule.Domain;

namespace Molecule.Application.Flours.Queries.GetFlourList
{
    public class FlourLookupDto : IMapWith<Flour>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Flour, FlourLookupDto>()
                .ForMember(flourDto => flourDto.Id,
                    opt => opt.MapFrom(flour => flour.Id))
                .ForMember(flourDto => flourDto.Name,
                    opt => opt.MapFrom(flour => flour.Name));
        }
    }
}
