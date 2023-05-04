using InterLab.Core.Models;

namespace InterLab.Application.Interface
{
    public interface IStockDataService
    {
        Task<IEnumerable<Stock>> GetStocks();
    }
}
