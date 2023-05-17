using AutoMapper;
using InterLab.Core.Dto;
using InterLab.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
