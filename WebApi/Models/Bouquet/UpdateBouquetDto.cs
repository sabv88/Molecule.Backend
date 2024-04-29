using AutoMapper;
using Molecule.Application.Bouquets.Commands.UpdateBouquet;
using Molecule.Application.Common.Mappings;
using Molecule.Application.Flours.Commands.UpdateFlour;
using Molecule.Application.Flours.Queries.GetFlourDetails;

namespace WebApi.Models.Bouquet
{
    public class UpdateBouquetDto : IMapWith<UpdateBouquetCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<UpdateFlourCommand> Flours { get; set; } = new();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBouquetDto, UpdateBouquetCommand>()
                .ForMember(bouquetCommand => bouquetCommand.Id,
                    opt => opt.MapFrom(flourDto => flourDto.Id))
               .ForMember(bouquetCommand => bouquetCommand.Title,
                    opt => opt.MapFrom(bouquetDto => bouquetDto.Title))
                .ForMember(bouquetCommand => bouquetCommand.Description,
                    opt => opt.MapFrom(bouquetDto => bouquetDto.Description))
                .ForMember(bouquetCommand => bouquetCommand.Flours,
                    opt => opt.MapFrom(bouquetDto => bouquetDto.Flours));
        }
    }
}
