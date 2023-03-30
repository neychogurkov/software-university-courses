namespace CarDealer
{
    using AutoMapper;
    using DTOs.Export;
    using DTOs.Import;
    using Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDto, Supplier>();

            CreateMap<ImportPartDto, Part>();

            CreateMap<ImportCustomerDto, Customer>();

            CreateMap<ImportSaleDto, Sale>();

            CreateMap<Car, ExportCarDto>();
        }
    }
}
