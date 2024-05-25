using AutoMapper;
using MiniShop.Frontend.Client.Models;

namespace MiniShop.Frontend.Client.Dtos.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SysParm, SysParmDto>();
            CreateMap<SysParmDto, SysParm>();

            CreateMap<Unit, UnitDto>();
            CreateMap<UnitDto, Unit>();

            CreateMap<Categorie, CategorieDto>();
            CreateMap<CategorieDto, Categorie>();

            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
        }
    }
}
