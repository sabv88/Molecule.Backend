using AutoMapper;
using Molecule.Application.Bouquets.Commands.CreateBouquet;
using Molecule.Application.Common.Mappings;
using Molecule.Application.Flours.Commands.UpdateFlour;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Bouquet
{
    public class CreateBouquetDto : IMapWith<CreateBouquetCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public List<UpdateFlourCommand> Flours { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBouquetDto, CreateBouquetCommand>()
                .ForMember(bouquetCommand => bouquetCommand.Title,
                    opt => opt.MapFrom(bouquetDto => bouquetDto.Title))
                .ForMember(bouquetCommand => bouquetCommand.Description,
                    opt => opt.MapFrom(bouquetDto => bouquetDto.Description))
                .ForMember(bouquetCommand => bouquetCommand.Flours,
                    opt => opt.MapFrom(bouquetDto => bouquetDto.Flours));
        }
    }
}