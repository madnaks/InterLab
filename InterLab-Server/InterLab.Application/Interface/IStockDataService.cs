using InterLab.Core.Dto;

namespace InterLab.Application.Interface
{
    public interface IStockService
    {
        Task<IEnumerable<StockDto>> GetStocksBySymbols(IList<string> symbols);
    }
}
