using AutoMapper;
using Molecule.Application.Common.Mappings;
using Molecule.Application.Flours.Commands.CreateFlour;

namespace Molecule.Backend.Models
{
    public class CreateFlourDto : IMapWith<CreateFlourCommand>
    {
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFlourDto, CreateFlourCommand>()
                .ForMember(flourCommand => flourCommand.Name,
                    opt => opt.MapFrom(flourDto => flourDto.Name));
        }
    }
}
