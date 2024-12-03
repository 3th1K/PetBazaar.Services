using Ethik.Utility.Api.Models;
using Ethik.Utility.Data.Collections;
using Microsoft.AspNetCore.Mvc;
using ProductService.Domain.Interfaces;
using ProductService.Domain.Models;

namespace ProductService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IFoodProductRepository _foodProductRepository;

        public WeatherForecastController(IFoodProductRepository foodProductRepository)
        {
            _foodProductRepository = foodProductRepository;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("hihi")]
        public async Task<IActionResult> A()
        {
            var prods = await _foodProductRepository.GetAllAsync(0, 2, p => p.Price);
            var res = ApiResponse<PagedList<FoodProduct>>.Success(prods.Data);
            return Ok(res);
        }
    }
}