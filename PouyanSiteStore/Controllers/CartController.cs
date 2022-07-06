using Application.Dtos.Cart;
using Application.Dtos.Common;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PouyanSiteStore.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartItem _basket;

        public CartController(ILogger<CartController> logger,ICartItem basket)
        {
            this._basket = basket;
        }

        [HttpPost("AddBasketItem")]
       public async Task<IActionResult> AddCartItemAsync([FromBody]RequestIDDto request)
        {

            var result =await _basket.AddCartItem(request.Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartAsync()
        {
            var result = await _basket.GetCart();
            return Ok(result);
        }
        [HttpPut("UpdateBasketItem")]
        public async Task<IActionResult> UpdateCartItemAsync([FromBody]RequestUpdateCartItemDto Request)
        {
            var result = await _basket.UpdateCartItem(Request);
            return Ok(result);
        }
        [HttpDelete("DeleteBasketItem")]
        public async Task<IActionResult> DeleteCartItemAsync(int id)
        {
            var result = await _basket.DeleteCartItem(id);
            return Ok(result);
        }
  
    }
}
