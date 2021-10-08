using System;

namespace TotalError.OrderSales.Domain.Enums
{
    [Flags]
    public enum Role
    {
        Owner = 1,
        Staff = 2,
        Volunteer = 4
    }
}
