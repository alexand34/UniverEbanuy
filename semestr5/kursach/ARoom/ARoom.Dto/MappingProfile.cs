using ARoom.Common.Model;
using ARoom.Dto.Dtos;
using AutoMapper;


namespace ARoom.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Good, GoodDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<WarehouseZone, WarehouseZoneDto>();
        }
    }
}
