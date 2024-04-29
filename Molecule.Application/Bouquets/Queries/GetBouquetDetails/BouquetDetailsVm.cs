using AutoMapper;
using Molecule.Application.Common.Mappings;
using Molecule.Application.Flours.Queries.GetFlourDetails;
using Molecule.Domain;

namespace Molecule.Application.Bouquets.Queries.GetBouquetDetails
{
    public class BouquetDetailsVm : IMapWith<Bouquet>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<FlourDetailsVm> Flours { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bouquet, BouquetDetailsVm>()
                .ForMember(bouquetVm => bouquetVm.Id,
                    opt => opt.MapFrom(bouquet => bouquet.Id))
                .ForMember(bouquetVm => bouquetVm.Description,
                    opt => opt.MapFrom(bouquet => bouquet.Description))
                .ForMember(bouquetVm => bouquetVm.Flours,
                    opt => opt.MapFrom(bouquet => bouquet.Flours))
                .ForMember(bouquetVm => bouquetVm.Title,
                    opt => opt.MapFrom(bouquet => bouquet.Title));
        }
    }
}