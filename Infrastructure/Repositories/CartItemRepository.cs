using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class CartItemRepository : ICartItemRepository
	{
		private readonly DataContext _dataContext;
		private readonly ShoppingCartRepository _shoppingCart;
		public CartItemRepository(DataContext dataContext) {
			_dataContext = dataContext;
		}

		public async Task<CartItemEntity> CreateCartItemAsync(CartItemEntity entity,ShoppingCartEntity shoppingCartEntity)
		{
			try
			{
				if (entity != null)
				{
					var shoppingCartExists = await _dataContext.ShoppingCarts.FindAsync(entity.ShoppingCartId);

					if (shoppingCartExists != null)
					{
						_dataContext.CartItems.Add(entity);
						await _dataContext.SaveChangesAsync();
						return entity;
					}

					else
					{
						await _shoppingCart.CreateShoppingCartAsync(shoppingCartEntity);

						_dataContext.CartItems.Add(entity);
						await _dataContext.SaveChangesAsync();
						return entity;

					}

				}
				

				return null;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				throw;
			}
			
		}
		



		//public Task<CartItemEntity> CreateCartItemAsync(IProductDto productDto)
		//{
		//	var entity = _IProductToCartItemFactory.ConvertFromProductToEntity(productDto);

		//	_dataContext.AddAsync(entity);
		//	_dataContext.SaveChangesAsync();
		//	return entity;
		//}
	}
}
