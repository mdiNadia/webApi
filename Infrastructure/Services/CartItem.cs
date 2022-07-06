using Application.Dtos.Cart;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CartItem : GenericRepository<Domain.Entities.CartItem>, ICartItem
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProduct _product;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public CartItem(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IProduct product, IUserAccessor userAccessor, IMapper mapper) : base(context, configuration)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._product = product;
            this._userAccessor = userAccessor;
        
            this._mapper = mapper;
        }
        public async Task<List<GetCartItemsDto>> GetCart() {
            var user = await _userAccessor.GetCurrentUserAsync();
            var cartItems = await GetQueryList()
                .AsNoTracking()
                .Include(c=>c.Product)
                .Where(c => c.CartStatus == 0 && c.UserId == user.Id).ToListAsync();
            var cartInfo = new List<GetCartItemsDto>();
            foreach (var item in cartItems)
            {
                cartInfo.Add(new GetCartItemsDto() { Id=item.Id,ProductId=item.ProductId,Image="",Price=item.Product.Price,Title=item.Product.Title,Qty=item.Quantity,SumPrice= item.Product.Price * item.Quantity});
            }
            return cartInfo;

        }
        public async Task<int> AddCartItem(int id)
        {
            var user = await _userAccessor.GetCurrentUserAsync();
         
            var cartItem = GetQueryList().Include(c=>c.User).SingleOrDefault(
                c => c.CartStatus == 0 && c.UserId == user.Id
                && c.ProductId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new Domain.Entities.CartItem
                {
                    CartStatus = 0,
                    UserId = user.Id,
                    ProductId = id,
                    Product = _product.GetQueryList().SingleOrDefault(
                    p => p.Id == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                Insert(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            await SaveEntityChangeAsync();
            return 200;
        }

        public async Task<int> UpdateCartItem(RequestUpdateCartItemDto Request)
        {
            var cartItem =await GetQueryList().Where(c=>c.Id == Request.ItemId).FirstOrDefaultAsync();
            cartItem.Quantity = Request.ItemQty;
            await SaveEntityChangeAsync();
            return 200;
        }

        public async Task<int> DeleteCartItem(int id)
        {
            var cartItem = await GetQueryList().FirstOrDefaultAsync(c => c.Id == id);
            Delete(cartItem);
            await SaveEntityChangeAsync();
            return id;
        }
        //public string GetCartIdAsync()
        //{
        //    if (_httpContextAccessor.HttpContext.Session.Get("cart") == null)
        //    {
        //        Guid tempCartId = Guid.NewGuid();
        //        _httpContextAccessor.HttpContext.Session.SetString("cart", tempCartId.ToString());
        //    }

        //    return _httpContextAccessor.HttpContext.Session.GetString("cart");

        //}

    }
}
