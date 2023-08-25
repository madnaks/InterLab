using InterLab.Core.Models;

namespace InterLab.Application.Abstractions.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStocksBySymbols(IList<string> symbols);
    }
}
