using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingcartApi.Dtos;
using System.Diagnostics;

namespace ShoppingcartApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingCartController : ControllerBase
	{
		private readonly ShoppingCartService _shoppingCartService;

        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }


        [HttpPost]
		public async Task<IActionResult> GetOneProductIntoShoppingCart(ProductDto product)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var existingShoppingCart = _shoppingCartService.GetShoppingcart(product.UserId);

					if (existingShoppingCart == null)
						_shoppingCartService.CreateShoppingCart();





				}










				// DTO FRÅN SERVICEN FRÅN WEBAPP

				// userid
				// productId
				// quantity			

				//factory 


				// Services				

				// Kontrollera

				//repository
				// CRUD


				return Ok();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				throw;
			}
		}




		[HttpGet]
		public IActionResult GetAll()
		{

			return Ok();
		}


	}
}
