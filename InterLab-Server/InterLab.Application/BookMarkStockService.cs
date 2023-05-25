using InterLab.Application.Interface;
using Microsoft.Extensions.Logging;
using AutoMapper;
using InterLab.Core.Models;
using InterLab.Infrastracture;
using InterLab.Core.Dto;
using InterLab.Core.Exceptions;

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
            return _mapper.Map<List<StockDto>>(_context.BookMarkStocks.Where(stock => stock.Ticker == symbol && stock.CreatedDate.Date == DateTime.Parse(date).Date).ToList());
        }

        public void SaveBookMarkStock(BookMarkStock bookMarkStock)
        {
            try
            {
                if(CanSaveBookMark(bookMarkStock))
                {
                    _context.BookMarkStocks.AddAsync(bookMarkStock);
                    _context.SaveChangesAsync();
                }
                else
                {
                    throw new BadRequestException("Vous ne pouvez pas enregistrer deux stocks pour la même société dans un intervalle qui n'a pas dépassé 5 minutes");
                }
            }
            catch (BadRequestException ex)
            {
                _logger.LogError("BookMark Stock Service error => {ex}", ex);
                throw new BadRequestException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("BookMark Stock Service error => {ex}", ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Returns True if there is not one BookMarkStock that has been saved in the last 5 minutes with the same Ticker
        /// </summary>
        /// <param name="bookMarkStock"></param>
        /// <returns>bool</returns>
        private bool CanSaveBookMark(BookMarkStock bookMarkStock)
        {
            return !_context.BookMarkStocks.Any(b => b.Ticker == bookMarkStock.Ticker && (DateTime.Now - b.CreatedDate).TotalMinutes < 5);
        }
    }
}
