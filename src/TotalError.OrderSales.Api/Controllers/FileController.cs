using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Services;

namespace TotalError.OrderSales.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/file")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveFile()
        {
            var fileDirectory = @"E:\programing\University\3th\API\CourseWork\readfiles";
            await _fileService.ReadFile(fileDirectory);
            return NoContent();
        }
    }
}
