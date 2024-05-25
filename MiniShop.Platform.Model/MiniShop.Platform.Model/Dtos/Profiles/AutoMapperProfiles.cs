using AutoMapper;

namespace MiniShop.Platform.Model.Dtos.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RenewPackage, RenewPackageDto>();
            CreateMap<RenewPackageCreateDto, RenewPackage>();
            CreateMap<RenewPackageUpdateDto, RenewPackage>();
        }
    }
}
