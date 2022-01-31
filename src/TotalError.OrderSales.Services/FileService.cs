using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using System;
using TotalError.OrderSales.Domain;

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

        private async Task SaveNewFileToDbAsync(EntryInfoDto entryInfo)
        {
                await _regionService.CreateAsync(_mapper.Map<RegionDto>(entryInfo.Record.Country.Region));
                await _countryService.CreateAsync(_mapper.Map<CountryDto>(entryInfo.Record.Country));
                await _itemService.CreateAsync(_mapper.Map<ItemDto>(entryInfo.Record.Sale.Item));
                var saleDto = await _saleService.CreateAsync(_mapper.Map<SaleDto>(entryInfo.Record.Sale));
                var orderDto = _mapper.Map<OrderDto>(entryInfo.Record);
                orderDto.SaleId = saleDto.Id;
                orderDto.CreatedOn = entryInfo.CreatedOn;
                await _orderService.CreateAsync(orderDto);
        }

        public async Task ReadFile(string directory)
        {
            var fileEntries = Directory.GetFiles(directory,"*.csv");
            foreach (var file in fileEntries)
            {
                var createdOn = DateTime.ParseExact(Path.GetFileNameWithoutExtension(file), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                if (!_orderService.IsDataRegistered(createdOn))
                {
                    using (var reader = new StreamReader(file))
                    {
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Context.RegisterClassMap<OrderCsvMap>();
                            foreach (var entry in csv.GetRecords<OrderCsvDto>())
                            {
                                var entryInfo = new EntryInfoDto();

                                entryInfo.Record = entry;
                                entryInfo.CreatedOn = DateTime.ParseExact(Path.GetFileNameWithoutExtension(file), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                                await SaveNewFileToDbAsync(entryInfo);
                            }
                        }
                    }
                }
            }

        }
    }
}
