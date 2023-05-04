using InterLab.Application.Interface;
using InterLab.Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterLab.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockDataController : ControllerBase
    {
        private IStockDataService _samplesService;
        public StockDataController(IStockDataService samplesService)
        {
            _samplesService = samplesService;
        }

        [HttpGet]
        public async Task<IEnumerable<Stock>> Get()
        {
            return await _samplesService.GetStocks();
        }
    }
}
