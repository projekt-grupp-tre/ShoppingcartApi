﻿using Infrastructure.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingcartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ICartItemService _CartItemService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, ICartItemService cartItemService)
        {
            _shoppingCartService = shoppingCartService;
            _CartItemService = cartItemService;
        }

        [HttpPost]
        public async Task<IActionResult> GetOneProductIntoShoppingCart(ProductDto product)
        {
            var existingShoppingCart = await _shoppingCartService.GetShoppingcartAsync(product.UserEmail);

            if (existingShoppingCart == null)
            {
                var created = await _shoppingCartService.CreateShoppingCartAsync(product.UserEmail);

                if (created != null)
                {
                    var added = await _CartItemService.AddCartItemToShoppingCartAsync(product, created);
                    if (added)
                        return Ok();
                }
            }
            else
            {




            }

            return BadRequest();
        }
    }




    //[HttpGet]
    //public IActionResult GetAll()
    //{

    //	return Ok();
    //}


}

