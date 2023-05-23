using InterLab.Application.Interface;
using Microsoft.Extensions.Logging;
using AutoMapper;
using InterLab.Core.Models;
using InterLab.Infrastracture;
using InterLab.Core.Dto;

namespace InterLab.Application
{
    public class BookMarkStockService: IBookMarkStockService
    {
        private readonly ILogger<BookMarkStockService> _logger;
        public readonly IMapper _mapper;
        public readonly InterLabDbContext _context;

        public BookMarkStockService(ILogger<BookMarkStockService> logger, IMapper mapper, InterLabDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        
        public IEnumerable<StockDto> GetBookmarkStocks(string symbol, string date)
        {
            var parsedDate = DateTime.Parse(date);

            return _mapper.Map<List<StockDto>>(_context.BookMarkStocks.Where(stock => stock.Ticker == symbol && stock.CreatedDate.Date == parsedDate.Date).ToList());
        }

        public void SaveBookMarkStock(BookMarkStock bookMarkStock)
        {
            try
            {
                _context.BookMarkStocks.AddAsync(bookMarkStock);
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("BookMark Stock Service error {ex}", ex);
                throw new Exception("Exception", ex);
            }
        }
    }
}
