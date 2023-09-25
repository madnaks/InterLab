using InterLab.Application.Abstractions.Services;
using InterLab.Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InterLab.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IStockService _stockService;

        public StockController(IStockService samplesService) => _stockService = samplesService;

        [HttpPost("GetStocksBySymbols")]
        public async Task<IEnumerable<StockDto>> GetStocksBySymbols([FromBody] IList<string> symbols)
        {
            return await _stockService.GetStocksBySymbols(symbols);
        }
    }
}
