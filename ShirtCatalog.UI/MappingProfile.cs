using AutoMapper;
using ShirtCatalog.UI.Models;

namespace ShirtCatalog.UI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShirtDetailsViewModel, ShirtViewModel>().ReverseMap();
        }
    }
}
