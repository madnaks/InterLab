using AutoMapper;
using InterLab.Core.Models;
using InterLab.Core.Dto;
using InterLab.Application.Abstractions.Services;
using InterLab.Application.Abstractions.Repositories;

namespace InterLab.Application
{
    public class BookMarkStockService: IBookMarkStockService
    {
        private readonly IBookMarkStockRepository _bookMarkStockRepository;
        public readonly IMapper _mapper;

        public BookMarkStockService(IMapper mapper, IBookMarkStockRepository bookMarkStockRepository)
        {
            _mapper = mapper;
            _bookMarkStockRepository = bookMarkStockRepository;
        }
        
        public IEnumerable<StockDto> GetBookmarkStocks(string symbol, string date)
        {
            return _mapper.Map<List<StockDto>>(_bookMarkStockRepository.GetBookmarkStocks(symbol,date));
        }

        public void SaveBookMarkStock(BookMarkStock bookMarkStock)
        {
            _bookMarkStockRepository.SaveBookMarkStock(bookMarkStock);
        }
    }
}
