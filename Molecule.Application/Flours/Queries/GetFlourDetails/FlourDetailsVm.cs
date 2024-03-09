using AutoMapper;
using Molecule.Application.Common.Mappings;
using Molecule.Domain;

namespace Molecule.Application.Flours.Queries.GetFlourDetails
{
    public class FlourDetailsVm : IMapWith<Flour>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Flour, FlourDetailsVm>()
                .ForMember(flourVm => flourVm.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Name,
                    opt => opt.MapFrom(note => note.Name));
        }
    }
}
