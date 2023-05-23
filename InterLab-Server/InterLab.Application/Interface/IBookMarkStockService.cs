using InterLab.Core.Dto;
using InterLab.Core.Models;

namespace InterLab.Application.Interface
{
    public interface IBookMarkStockService
    {
        IEnumerable<StockDto> GetBookmarkStocks(string symbol, string date);
        void SaveBookMarkStock(BookMarkStock bookMarkStock);
    }
}
