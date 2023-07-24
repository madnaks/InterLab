using AutoMapper;
using InterLab.Application.Interface;
using InterLab.Core.Dto;
using InterLab.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterLab.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookMarkStockController : ControllerBase
    {
        private IBookMarkStockService _bookMarkStockService;
        private IMapper _mapper;

        public BookMarkStockController(IBookMarkStockService bookMarkStockService, IMapper mapper)
        {
            _bookMarkStockService = bookMarkStockService;
            _mapper = mapper;
        }

        [HttpGet("GetBookmarkStocks/{symbol}/{date}")]
        public IEnumerable<StockDto> GetBookmarkStocks(string symbol, string date)
        {
            return _bookMarkStockService.GetBookmarkStocks(symbol, date);
        }

        [HttpPost("SaveBookMarkStock")]
        public IActionResult SaveStock([FromBody] StockDto stockDto)
        {
            var bookMarkStock = _mapper.Map<BookMarkStock>(stockDto);
            _bookMarkStockService.SaveBookMarkStock(bookMarkStock);
            return Ok();
        }
    }
}
