using AutoMapper;
using InterLab.Core.Dto;
using InterLab.Core.Models;

namespace InterLab.Core
{
    public class InterLabProfile : Profile
    {
        public InterLabProfile()
        {
            CreateMap<Stock,StockDto>();
            CreateMap<StockDto,BookMarkStock>().ReverseMap();
        }
    }
}
