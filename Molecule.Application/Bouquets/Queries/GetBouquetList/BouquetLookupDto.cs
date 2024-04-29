using AutoMapper;
using Molecule.Application.Common.Mappings;
using Molecule.Domain;

namespace Molecule.Application.Bouquets.Queries.GetBouquetList
{
    public class BouquetLookupDto : IMapWith<Bouquet>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bouquet, BouquetLookupDto>()
                .ForMember(bouquetDto => bouquetDto.Id,
                    opt => opt.MapFrom(bouquet => bouquet.Id))
                .ForMember(bouquetDto => bouquetDto.Title,
                    opt => opt.MapFrom(bouquet => bouquet.Title));
        }
    }
}