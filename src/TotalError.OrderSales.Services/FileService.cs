using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;
using System.Linq;
using AutoMapper;

namespace TotalError.OrderSales.Services
{
    public class FileService : IFileService
    {
        private readonly IOrderService _orderService;
        private readonly IItemService _itemService;
        private readonly IRegionService _regionService;
        private readonly ICountryService _countryService;
        private readonly ISaleService _saleService;

        private readonly IMapper _mapper;

        public FileService(IOrderService orderService, IItemService itemService,
            IRegionService regionService, ICountryService countryService,
            ISaleService saleService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
            _itemService = itemService;
            _regionService = regionService;
            _saleService = saleService;
            _countryService = countryService;
        }

        public IEnumerable<OrderCsvDto> ReadFile()
        {
            using (var reader = new StreamReader(@"E:\programing\University\3th\API\CourseWork"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<OrderCsvDto>();

                return records;
            }
        }

        public void SaveNewFileToDb()
        {
            var recordsList = ReadFile().ToList();



            foreach(var order in recordsList)
            {
                _orderService.CreateAsync(_mapper.Map<OrderDto>(order));
                _saleService.CreateAsync(_mapper.Map<SaleDto>(order.Sale));
                _regionService.CreateAsync(_mapper.Map<RegionDto>(order.Country.Region));
                _countryService.CreateAsync(_mapper.Map<CountryDto>(order.Country));
                _itemService.CreateAsync(_mapper.Map<ItemDto>(order.Sale.Item));
            }
        }
    }
}
