using DealsObserver.Domain.Abstract;
using DealsObserver.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealsObserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly IDealsService _dealsService;

        public DealsController(IDealsService dealsService)
        {
            _dealsService = dealsService;
        }

        [HttpGet("GetAll")]
        public Task<IList<DealDto>> GetAll()
        {
            return _dealsService.GetAll();
        }

        [HttpGet("GetTheMostPopularVehicle")]
        public async Task<IActionResult> GetTheMostPopularVehicle()
        {
            var vehicle = await _dealsService.GetTheMostPopularVehicle();

            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }

        [HttpPost("UploadCsv")]
        public async Task<IActionResult> UploadCsv(IFormFile csv)
        {
            await _dealsService.UploadFromCsv(csv);
            return NoContent();
        }
    }
}
