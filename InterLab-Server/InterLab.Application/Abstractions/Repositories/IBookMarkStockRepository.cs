using InterLab.Core.Dto;
using InterLab.Core.Models;

namespace InterLab.Application.Abstractions.Repositories
{
    public interface IBookMarkStockRepository
    {
        IEnumerable<BookMarkStock> GetBookmarkStocks(string symbol, string date);
        void SaveBookMarkStock(BookMarkStock bookMarkStock);
    }
}
