using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Buuuullllllllshit WTF is this !!!
            // Mapping Prfiling Configuration For What ????? For Whatttt
            // Finis this fuckn DTO. just type table add function expression and Search with Linq !!!!!
            // Boooriiiiinggg
            CreateMap<Product,ProductToDto>()
            .ForMember(x=>x.ProductBrand, y=>y.MapFrom(z=>z.ProductBrand.Name))
            .ForMember(x=>x.ProductType, y=>y.MapFrom(z=>z.ProductType.Name))
            .ForMember(x=>x.PictureUrl, y=>y.MapFrom<ProductUrlResolver>());
        }
    }
}