using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Models;

namespace TotalError.OrderSales.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("country/OrderCollection")]
        public async Task<IActionResult> GetSummeryByCountry([FromQuery] SummaryRequestModel model)
        {
            return Ok(await _orderService.GetOrdersByCountryAsync(model));
        }

        [HttpGet]
        [Route("region/OrderCollection")]
        public async Task<IActionResult> GetSummeryByRegion([FromQuery] SummaryRequestModel model)
        {
            return Ok(await _orderService.GetOrdersByRegionAsync(model));
        }

        [HttpGet]
        [Route("date/OrderCollection")]
        public async Task<IActionResult> GetSummeryByOrderDate([FromQuery] SummaryRequestModel model)
        {
            return Ok(await _orderService.GetOrdersByOrderDateAsync(model));
        }
    }
}
