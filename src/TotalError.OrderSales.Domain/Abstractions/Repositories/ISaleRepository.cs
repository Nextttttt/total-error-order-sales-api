using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Repositories
{
    public interface ISaleRepository : IBaseRepository<SaleCsvDto>
    {
    }
}
