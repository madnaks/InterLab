using InterLab.Application.Abstractions.Repositories;
using InterLab.Core.Exceptions;
using InterLab.Core.Models;
using Microsoft.Extensions.Logging;

namespace InterLab.Infrastracture.Repositories
{
    public class BookMarkStockRepository : IBookMarkStockRepository
    {
        public readonly InterLabDbContext _context;
        private readonly ILogger<BookMarkStockRepository> _logger;

        public BookMarkStockRepository(InterLabDbContext context, ILogger<BookMarkStockRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<BookMarkStock> GetBookmarkStocks(string symbol, string date)
        {
            return _context.BookMarkStocks.Where(stock => stock.Ticker == symbol && stock.CreatedDate.Date == DateTime.Parse(date).Date).OrderBy(stock => stock.CreatedDate).ToList();
        }

        public void SaveBookMarkStock(BookMarkStock bookMarkStock)
        {
            try
            {
                if (CanSaveBookMark(bookMarkStock))
                {
                    bookMarkStock.CreatedDate = DateTime.Now;
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
                _logger.LogError("BookMarkStockRepository error => {ex}", ex);
                throw new BadRequestException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("BookMarkStockRepository error => {ex}", ex);
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
