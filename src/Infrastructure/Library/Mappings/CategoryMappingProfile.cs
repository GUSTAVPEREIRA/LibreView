using AutoMapper;
using Core.Library.Models;

namespace Infrastructure.Library.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryResponse>();

        CreateMap<CategoryUpdateRequest, Category>()
            .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
            .ForMember(x => x.Description, x => x.MapFrom(y => y.Description));

        CreateMap<CategoryCreateRequest, Category>()
            .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
            .ForMember(x => x.Id, x => x.Ignore())
            .ForMember(x => x.Description, x => x.MapFrom(y => y.Description));
    }
}