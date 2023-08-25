using InterLab.Core.Dto;
using AutoMapper;
using InterLab.Application.Abstractions.Services;
using InterLab.Application.Abstractions.Repositories;

namespace InterLab.Application
{
    public class StockService: IStockService
    {
        public readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;


        public StockService(IMapper mapper, IStockRepository stockRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<StockDto>> GetStocksBySymbols(IList<string> symbols)
        {
            return _mapper.Map<List<StockDto>>(await _stockRepository.GetStocksBySymbols(symbols));
        }
    }
}
