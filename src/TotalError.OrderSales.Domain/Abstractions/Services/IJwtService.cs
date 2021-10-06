using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalError.OrderSales.Domain.Abstractions.Services
{
    public interface IJwtService
    {
        public string GenerateJsonWebToken(Guid userId);
    }
}
