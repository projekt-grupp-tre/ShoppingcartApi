using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingcartApi.Controllers
{
	[Route("/cart")]
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
		[Route("/cart/add")]
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
				var cartItemList = await _CartItemService.GetAllCartItemsAsync(product, existingShoppingCart.Id);

				var result = await _CartItemService.CheckExistingCartForItems(cartItemList, product);
				if (result != null)
				{
					return Ok();

				}
				else
				{
					var addedItem = await _CartItemService.AddCartItemToShoppingCartAsync(product, existingShoppingCart);
					if (addedItem)
					{
						return Ok();
					}
				}
			}
			return BadRequest();
		}

		[HttpDelete]
		[Route("/cart/remove-one-item")]
		public async Task<IActionResult> DeleteOneProductFromShoppingCart(ProductDto product)
		{
			var shoppingCart = await _shoppingCartService.GetFullShoppingCart(product.UserEmail);

			if (shoppingCart != null)
			{
				var removed = await _CartItemService.DeleteCartItemFromShoppingCart(shoppingCart.CartItems!.ToList(), product);

				if (removed)
					return Ok(shoppingCart);
			}
			return BadRequest();
		}

		[HttpDelete]
		[Route("/cart/delete-cart")]
		public async Task<IActionResult> DeleteShoppingCart(string userEmail)
		{
			var shoppingCart = await _shoppingCartService.GetFullShoppingCart(userEmail);

			if (shoppingCart != null)
			{
				var removed = await _shoppingCartService.DeleteShoppingCart(shoppingCart);
				if (removed)
					return Ok();
			}
			return BadRequest();
		}

		[HttpGet]
		public async Task<IActionResult> GetShoppingCart(string userEmail)
		{
			if(userEmail != null)
			{
				var result = await _shoppingCartService.GetFullShoppingCart(userEmail);

				if(result != null)
				{
					return Ok(result);
				}
			}
			return BadRequest();

		}
	}

}

