using AutoMapper;
using ShirtCatalog.Application.ViewModel;
using ShirtCatalog.Core.Entities;

namespace ShirtCatalog.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shirt, ShirtDetailsViewModel>().ReverseMap();
        }
    }
}
