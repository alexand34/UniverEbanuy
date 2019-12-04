using ARoom.Common.Model;
using ARoom.Dto.Dtos;
using AutoMapper;
using System.Linq;

namespace ARoom.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Good, GoodDto>();
            CreateMap<WarehouseZone, WarehouseZoneSimpleDto>();
            CreateMap<Category, CategoryDto>()
                .ForMember(x => x.GoodsCount, opts => opts.MapFrom(t => t.Goods.Count()));
            CreateMap<WarehouseZone, WarehouseZoneDto>();
            CreateMap<Category, CategorySimpleDto>();
        }
    }
}
