using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Infrastructure.Services
{
	public class ShoppingCartService : IShoppingCartService
	{

		private readonly IShoppingCartRepository _shoppingCartRepository;

		public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
		{
			_shoppingCartRepository = shoppingCartRepository;
		}

		public async Task<ShoppingCartEntity> GetShoppingcartAsync(string userEmail)
		{
			if (!string.IsNullOrEmpty(userEmail))
			{
				var shoppingcart = await _shoppingCartRepository.GetShoppingCartFromDbAsync(userEmail);
				return shoppingcart;
			}
			return null!;
		}


		public async Task<ShoppingCartEntity> CreateShoppingCartAsync(string userEmail)
		{
			var newCart = ShoppingCartFactory.CreateShoppingCartEntity(userEmail);
			var created = await _shoppingCartRepository.CreateShoppingCartAsync(newCart);

			if (created != null)
				return created;

			return null!;
		}

		public Task<ShoppingCartEntity> GetFullShoppingCart(string userEmail)
		{
			if (!string.IsNullOrEmpty(userEmail))
			{
				var result = _shoppingCartRepository.GetFullShoppingCart(userEmail);
				return result;
			}
			return null!;
		}
		public async Task<bool> DeleteShoppingCart(ShoppingCartEntity entity )
		{
			if (entity != null)
			{
				var success = await _shoppingCartRepository.DeleteShoppingCartAsync(entity);

				if (success)
				{
					return true;
				}

			}
			return false;

		}
	}
}
