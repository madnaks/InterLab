using InterLab.Core.Dto;

namespace InterLab.Application.Abstractions.Services
{
    public interface IStockService
    {
        Task<IEnumerable<StockDto>> GetStocksBySymbols(IList<string> symbols);
    }
}
