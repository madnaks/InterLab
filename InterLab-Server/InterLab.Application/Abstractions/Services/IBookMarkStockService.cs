using InterLab.Core.Dto;
using InterLab.Core.Models;

namespace InterLab.Application.Abstractions.Services
{
    public interface IBookMarkStockService
    {
        IEnumerable<StockDto> GetBookmarkStocks(string symbol, string date);
        void SaveBookMarkStock(BookMarkStock bookMarkStock);
    }
}
