namespace ProductShop
{
    using AutoMapper;

    using DTOs.Export;
    using DTOs.Import;
    using Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ImportUserDTO, User>();

            CreateMap<ImportProductDTO, Product>();
            CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(a => a.SellerName,
                    opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            CreateMap<ImportCategoryDTO, Category>();

            CreateMap<ImportCategoryProductDto, CategoryProduct>();

        }
    }
}
