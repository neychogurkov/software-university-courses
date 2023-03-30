namespace CarDealer
{
    using System.Globalization;
    
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Data;
    using DTOs.Export;
    using DTOs.Import;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string suppliersJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //string result = ImportSuppliers(context, suppliersJson);

            //string partsJson = File.ReadAllText(@"../../../Datasets/parts.json");
            //string result = ImportParts(context, partsJson);

            //string carsJson = File.ReadAllText(@"../../../Datasets/cars.json");
            //string result = ImportCars(context, carsJson);

            //string customersJson = File.ReadAllText(@"../../../Datasets/customers.json");
            //string result = ImportCustomers(context, customersJson);

            //string salesJson = File.ReadAllText(@"../../../Datasets/sales.json");
            //string result = ImportSales(context, salesJson);

            //Console.WriteLine(result);

            File.WriteAllText(@"../../../Results/ordered-customers.json", GetOrderedCustomers(context));

            File.WriteAllText(@"../../../Results/toyota-cars.json", GetCarsFromMakeToyota(context));

            File.WriteAllText(@"../../../Results/local-suppliers.json", GetLocalSuppliers(context));

            File.WriteAllText(@"../../../Results/cars-and-parts.json", GetCarsWithTheirListOfParts(context));

            File.WriteAllText(@"../../../Results/customers-total-sales.json", GetTotalSalesByCustomer(context));

            File.WriteAllText(@"../../../Results/sales-discounts.json", GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDto[] supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportPartDto[] partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson)
                .Where(p => context.Suppliers
                    .Select(s => s.Id)
                    .Contains(p.SupplierId))
                .ToArray();

            Part[] parts = mapper.Map<Part[]>(partDtos);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            List<Car> cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance,
                };

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    car.PartsCars.Add(new PartCar() { Car = car, PartId = partId });
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCustomerDto[] customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            Customer[] customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSaleDto[] saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            Sale[] sales = mapper.Map<Sale[]>(saleDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            ExportCarDto[] carDtos = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .AsNoTracking()
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(carDtos, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    PartsCount = c.Parts.Count
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("F2")
                    })
                })
                .ToArray();


            return JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Select(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
                })
                .AsNoTracking()
                .ToArray();

            var customersWithTotalSpentMoney = customers.Select(c => new
            {
                c.FullName,
                c.BoughtCars,
                SpentMoney = c.SpentMoney.Sum()
            })
            .OrderByDescending(c => c.SpentMoney)
            .ThenByDescending(c => c.BoughtCars)
            .ToArray();


            return JsonConvert.SerializeObject(customersWithTotalSpentMoney,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver
                });
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("f2"),
                    price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)).ToString("f2")
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}