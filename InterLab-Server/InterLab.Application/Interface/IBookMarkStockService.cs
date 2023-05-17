using InterLab.Core.Dto;
using InterLab.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterLab.Application.Interface
{
    public interface IBookMarkStockService
    {
        void SaveBookMarkStock(BookMarkStock bookMarkStock);
    }
}
