using AutoMapper;
using Molecule.Application.Common.Mappings;
using Molecule.Application.Flours.Commands.UpdateFlour;

namespace Molecule.Backend.Models
{
    public class UpdateFlourDto: IMapWith<UpdateFlourCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateFlourDto, UpdateFlourCommand>()
                .ForMember(flourCommand => flourCommand.Id,
                    opt => opt.MapFrom(flourDto => flourDto.Id))
                .ForMember(flourCommand => flourCommand.Name,
                    opt => opt.MapFrom(flourDto => flourDto.Name));
        }
    }
}
