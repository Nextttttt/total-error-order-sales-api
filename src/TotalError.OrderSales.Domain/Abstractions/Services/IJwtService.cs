using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Enums;

namespace TotalError.OrderSales.Domain.Abstractions.Services
{
    public interface IJwtService
    {
        public string GenerateJsonWebToken(Role role, Guid userId);
    }
}
