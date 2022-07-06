
using Application.Dtos.Cart;
using Application.Dtos.Common;
using Application.Dtos.Product;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICartItem : IGenericRepository<CartItem>
    {
        Task<int> AddCartItem(int id);
        Task<List<GetCartItemsDto>> GetCart();
        Task<int> UpdateCartItem(RequestUpdateCartItemDto Request);
        Task<int> DeleteCartItem(int id);
    }
}
