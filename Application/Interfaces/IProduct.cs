
using Application.Dtos.Common;
using Application.Dtos.Product;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProduct : IGenericRepository<Product>
    {
        Task<int> AddProduct(RequestInsertProductDto request);
        Task<GetProductsByFilterDto> GetProductsByFilter(RequestFilterDataDto request);
    }
}
