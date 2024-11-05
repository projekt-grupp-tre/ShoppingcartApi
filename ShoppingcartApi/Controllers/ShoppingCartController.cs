using Infrastructure.Entities;
using Infrastructure.Factories;
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
		[HttpPost]
		public async Task<IActionResult> GetOneProductIntoShoppingCart(ProductDto product)
		{
			try
			{
				// DTO FRÅN SERVICEN FRÅN WEBAPP

				// userid
				// productId
				// quantity			

				//factory 
				 IProductToCartItemFactory.ConvertFromProductToEntity(product);

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
