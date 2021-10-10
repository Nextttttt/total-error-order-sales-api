using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;
using System.Linq;

namespace TotalError.OrderSales.Services
{
    public class FileService : IFileService
    {
        private readonly IOrderService _orderService;

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
                _orderService.CreateAsync(order);
            }
        }
    }
}
